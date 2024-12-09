using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

public class TopicContainer
{
    public string SystemName { get; set; }
    public string Description { get; set; }
    public int DeviceNo { get; set; }
    public int ChannelNo { get; set; }
    public string SignalType { get; set; }
    public string Unit { get; set; }
    public string Range { get; set; }
    public float AHH { get; set; }
    public float AH { get; set; }
    public float AL { get; set; }
    public float ALL { get; set; }
    public int NumAlarmsLimit { get; set; }
    public string Tag { get; set; }
    public string Topic { get; set; }
    public int TopicID { get; set; }
    public bool Running { get; set; }
    public float ProcessValue { get; set; }
    public bool AlarmActive { get; set; }
    public int NumAlarms { get; set; }
    public bool NumAlarmsAboveLimit { get; set; }
    public string Timestamp { get; set; }
    public bool IsLive { get; set; }
    public CustomFoldout customFoldout { get; set; }


    public TopicContainer(string systemName, string topic, int topicID, int deviceNo, int channelNo,
                         string description, string signalType, string unit, string range   ,
                         float ahh, float ah, float al, float all, int numAlarmsLimit, string tag, bool running,
                         float processValue, bool alarmActive, int numAlarms, bool numAlarmsAboveLimit, bool isLive)
    {
        SystemName = systemName;
        Topic = topic;
        TopicID = topicID;
        DeviceNo = deviceNo;
        ChannelNo = channelNo;
        Description = description;
        SignalType = signalType;
        Unit = unit;
        Range = range;
        AHH = ahh;
        AH = ah;
        AL = al;
        ALL = all;
        NumAlarmsLimit = numAlarmsLimit;
        Tag = tag;
        Running = running;
        ProcessValue = processValue;
        AlarmActive = alarmActive;    
        NumAlarms = numAlarms;
        NumAlarmsAboveLimit = numAlarmsAboveLimit;
        IsLive = isLive;
    }

    public TopicContainer(string systemName, string topic, int topicID, int deviceNo, int channelNo,
                         string description, string signalType, string unit, string range,
                         float ahh, float ah, float al, float all, int numAlarmsLimit, string tag, bool isLive)
    {
        SystemName = systemName;
        Topic = topic;
        TopicID = topicID;
        DeviceNo = deviceNo;
        ChannelNo = channelNo;
        Description = description;
        SignalType = signalType;
        Unit = unit;
        Range = range;
        AHH = ahh;
        AH = ah;
        AL = al;
        ALL = all;
        NumAlarmsLimit = numAlarmsLimit;
        Tag = tag;
        IsLive = isLive;
    }

    public List<string> GetStaticData()
    {
        return new List<string>
        {
            $"Description: {Description}",
            $"Device No.: {DeviceNo}",
            $"Channel No.: {ChannelNo}",
            $"Signal Type: {SignalType}",
            $"Unit: {Unit}",
            $"Range: {Range}",
            $"AHH: {AHH}",
            $"AH: {AH}",
            $"AL: {AL}",
            $"ALL: {ALL}",
            $"Alarm Number Threshold: {NumAlarmsLimit}",
            $"Tag: {Tag}",
            $"Topic: {Topic}",
            $"Topic ID: {TopicID}"
        };
    }

    public List<Label> GetStaticDataLabels()
    {
        var labels = new List<Label>
    {
        new Label($"Tag: {Tag}"),
        new Label($"Device No.: {DeviceNo}"),
        new Label($"Channel No.: {ChannelNo}"),
        new Label($"Signal Type: {SignalType}"),
        new Label($"Unit: {Unit}"),
        new Label($"Range: {Range}"),
        new Label($"AHH: {AHH}"),
        new Label($"AH: {AH}"),
        new Label($"AL: {AL}"),
        new Label($"ALL: {ALL}"),
        new Label($"Alarm Number Threshold: {NumAlarmsLimit}"),
        new Label($"Topic: {Topic}"),
        new Label($"Topic ID: {TopicID}")
    };
        return labels;
    }

    public List<string> GetLiveData()
    {
        return new List<string>
    {
        $"Description: {Description}",
        $"Running: {Running}",
        $"Process Value: {ProcessValue}",
        $"Alarm Active: {AlarmActive}",
        $"Number of Alarms: {NumAlarms}"
    };
    }

    public CustomFoldout ToFoldout()
    {
        var foldout = new CustomFoldout
        {
            text = $"{Description}",
            value = false
        };

        if (AlarmActive)
        {
            foldout.style.color = new StyleColor(Color.red);
        }
        else if (NumAlarmsAboveLimit)
        {
            foldout.style.color = new StyleColor(Color.yellow);
        }
        else
        {
            foldout.style.color = new StyleColor(Color.black);
        }

        foldout.Add(new Label($"Tag: {Tag}"));
        foldout.Add(new Label($"Device No.: {DeviceNo}"));
        foldout.Add(new Label($"Channel No.: {ChannelNo}"));
        foldout.Add(new Label($"Signal Type: {SignalType}"));
        foldout.Add(new Label($"Unit: {Unit}"));
        foldout.Add(new Label($"Range: {Range}"));
        foldout.Add(new Label($"AHH: {AHH}"));
        foldout.Add(new Label($"AH: {AH}"));
        foldout.Add(new Label($"AL: {AL}"));
        foldout.Add(new Label($"ALL: {ALL}"));
        foldout.Add(new Label($"Alarm Number Threshold: {NumAlarmsLimit}"));
        foldout.Add(new Label($"Topic: {Topic}"));
        foldout.Add(new Label($"Topic ID: {TopicID}"));

        return foldout;
    }

    public void SetLiveData(bool running = false, float processValue = (float)0.0, bool alarmActive = false, int numAlarms = 0, bool numAlarmsAboveLimit = false)
    {
        Running = running;
        ProcessValue = processValue;
        AlarmActive = alarmActive;
        NumAlarms = numAlarms;
        NumAlarmsAboveLimit = numAlarmsAboveLimit;

        if (customFoldout != null)
        {
            if (AlarmActive)
            {
                customFoldout.style.color = new StyleColor(Color.red);
            }
            else if (NumAlarmsAboveLimit)
            {
                customFoldout.style.color = new StyleColor(Color.yellow);
            }
            else
            {
                customFoldout.style.color = new StyleColor(Color.black);
            }
        }
    }
}

