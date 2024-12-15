using MySqlConnector;
using UnityEngine;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Text;
using UnityEditor.Search;


public static class DatabaseManager
{
    public static List<TopicContainer> StaticContainers;
    public static List<TopicContainer> LiveContainers;
    public static List<string> SystemNames;

    private static bool populateListsDone;

    //public static string connectionString = "Server=127.0.0.1;Database=Gruppe4;User ID=root;Password=password;";
    public static string connectionString;

    public static async Task<Task> PopulateLists()
    {
        populateListsDone = false;
        StaticContainers = new List<TopicContainer>();
        LiveContainers = new List<TopicContainer>();
        SystemNames = new List<string>();

        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();
                //Debug.Log("Database initialization connection successful.");

                string query = @"SELECT * FROM tunglabdata_static LEFT JOIN tunglabdata_live
                                    ON (tunglabdata_static.topic_id = tunglabdata_live.topic_id) 
                                    WHERE tunglabdata_live.topic_id IS NULL
                                    LIMIT 1000";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    var reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        string sysName = (reader["systemname"] as string) ?? "UNKNOWN";
                        if (!SystemNames.Contains(sysName)) { SystemNames.Add(sysName); }

                        StaticContainers.Add(new TopicContainer(
                        systemName: sysName,
                        topic: (reader["topic"] as string) ?? "N/A",
                        topicID: (reader["topic_id"] as int?) ?? 0,
                        deviceNo: (reader["deviceno"] as int?) ?? 0,
                        channelNo: (reader["channelno"] as int?) ?? 0,
                        description: (reader["description"] as string) ?? "N/A",
                        signalType: (reader["signaltype"] as string) ?? "N/A",
                        unit: (reader["unit"] as string) ?? "N/A",
                        range: (reader["range"] as string) ?? "N/A",
                        ahh: (float)((reader["ahh"] as float?) ?? 0.0),
                        ah: (float)((reader["ah"] as float?) ?? 0.0),
                        al: (float)((reader["al"] as float?) ?? 0.0),
                        all: (float)((reader["all"] as float?) ?? 0.0),
                        numAlarmsLimit: (reader["numalarms_limit"] as int?) ?? 0,
                        tag: (reader["tag"] as string) ?? "",
                        isLive: false
                        ));
                    }
                }
            }
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string query = @"SELECT * FROM tunglabdata_live LEFT JOIN tunglabdata_static 
                        ON (tunglabdata_live.topic_id = tunglabdata_static.topic_id)
                        LIMIT 1000";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    var reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        string sysName = (reader["systemname"] as string) ?? "UNKNOWN";
                        if (!SystemNames.Contains(sysName)) { SystemNames.Add(sysName); }

                        LiveContainers.Add(new TopicContainer(
                        systemName: sysName,
                        topic: (reader["topic"] as string) ?? "N/A",
                        topicID: (reader["topic_id"] as int?) ?? 0,
                        deviceNo: (reader["deviceno"] as int?) ?? 0,
                        channelNo: (reader["channelno"] as int?) ?? 0,
                        description: (reader["description"] as string) ?? "N/A",
                        signalType: (reader["signaltype"] as string) ?? "N/A",
                        unit: (reader["unit"] as string) ?? "N/A",
                        range: (reader["range"] as string) ?? "N/A",
                        ahh: (float)((reader["ahh"] as float?) ?? 0.0),
                        ah: (float)((reader["ah"] as float?) ?? 0.0),
                        al: (float)((reader["al"] as float?) ?? 0.0),
                        all: (float)((reader["all"] as float?) ?? 0.0),
                        numAlarmsLimit: (reader["numalarms_limit"] as int?) ?? 0,
                        tag: (reader["tag"] as string) ?? "",
                        running: (((reader["running"] as int?) ?? 0) == 1),
                        processValue: (float)((reader["processvalue"] as float?) ?? 0.0),
                        alarmActive: (((reader["alarm"] as int?) ?? 0) == 1),
                        numAlarms: (reader["numalarms"] as int?) ?? 0,
                        numAlarmsAboveLimit: (((reader["numalarms_above_lim"] as int?) ?? 0) == 1),
                        isLive: true
                        ));
                    }
                }
            }
        }
        catch (MySqlException e)
        {
            Debug.LogError($"Database error: {e.Message}");
        }
        populateListsDone = true;
        return Task.CompletedTask;
    }

    public static async Task<Task> UpdateLiveData()
    {
        using (var connection = new MySqlConnection(connectionString))
        {
            try
            {
                string query = @"
                        SELECT *
                        FROM tunglabdata_live
                        WHERE topic_id = @topic_id
                        LIMIT 1";

                foreach (TopicContainer container in LiveContainers)
                {
                    await connection.OpenAsync();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@topic_id", container.TopicID);
                        
                        var reader = await command.ExecuteReaderAsync();
                        while (await reader.ReadAsync())
                        {
                            //Debug.Log("Database update connection successful.");
                            container.SetLiveData(
                                    running: (((reader["running"] as int?) ?? 0) == 1),
                                    processValue: (float)((reader["processvalue"] as float?) ?? 0.0),
                                    alarmActive: (((reader["alarm"] as int?) ?? 0) == 1),
                                    numAlarms: (reader["numalarms"] as int?) ?? 0,
                                    numAlarmsAboveLimit: (((reader["numalarms_above_lim"] as int?) ?? 0) == 1)
                                );
                        }
                    }
                    await connection.CloseAsync();
                }
            }
            catch (MySqlException ex)
            {
                Debug.LogError($"Database error: {ex.Message}");
            }
            return Task.CompletedTask;
        }
    }

    public static async Task<Task> PopulateListsDone()
    {
        while (!populateListsDone)
        {
            await Task.Delay(500);
        }
        return Task.CompletedTask;
    }

    public static bool TestConnection()
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                Debug.LogError($"Database error: {ex.Message}");
                return false;
            }
        }
    }
}
