using UnityEngine;
using UnityEngine.UIElements;

public interface ITopicContainer
{
    public bool AlarmActive { get; }
    public bool NumAlarmsAboveLimit { get; }
    public string Description { get; }
    public bool Running { get; }
    public float ProcessValue { get; }
    public int NumAlarms { get; }
    public string Unit {  get; }
}


public class TopicContainer : ITopicContainer
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
    
   
    private CustomFoldout _foldout;
    public CustomFoldout Foldout 
    { 
        get
        {
            if (AlarmActive)
            {
                _foldout.style.color = Color.red;
            }
            else if (NumAlarmsAboveLimit)
            {
                _foldout.style.color = Color.yellow;
            }
            else
            {
                _foldout.style.color = Color.black;
            }
            return _foldout;
        }
    }

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

        _foldout = new CustomFoldout(this, topicID, description);

        _foldout.Add(new Label($"Tag: {Tag}"));
        _foldout.Add(new Label($"Device No.: {DeviceNo}"));
        _foldout.Add(new Label($"Channel No.: {ChannelNo}"));
        _foldout.Add(new Label($"Signal Type: {SignalType}"));
        _foldout.Add(new Label($"Unit: {Unit}"));
        _foldout.Add(new Label($"Range: {Range}"));
        _foldout.Add(new Label($"AHH: {AHH}"));
        _foldout.Add(new Label($"AH: {AH}"));
        _foldout.Add(new Label($"AL: {AL}"));
        _foldout.Add(new Label($"ALL: {ALL}"));
        _foldout.Add(new Label($"Alarm Number Threshold: {NumAlarmsLimit}"));
        _foldout.Add(new Label($"Topic: {Topic}"));
        _foldout.Add(new Label($"Topic ID: {TopicID}"));
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

        _foldout = new CustomFoldout(this, topicID, description);

        _foldout.Add(new Label($"Tag: {Tag}"));
        _foldout.Add(new Label($"Device No.: {DeviceNo}"));
        _foldout.Add(new Label($"Channel No.: {ChannelNo}"));
        _foldout.Add(new Label($"Signal Type: {SignalType}"));
        _foldout.Add(new Label($"Unit: {Unit}"));
        _foldout.Add(new Label($"Range: {Range}"));
        _foldout.Add(new Label($"AHH: {AHH}"));
        _foldout.Add(new Label($"AH: {AH}"));
        _foldout.Add(new Label($"AL: {AL}"));
        _foldout.Add(new Label($"ALL: {ALL}"));
        _foldout.Add(new Label($"Alarm Number Threshold: {NumAlarmsLimit}"));
        _foldout.Add(new Label($"Topic: {Topic}"));
        _foldout.Add(new Label($"Topic ID: {TopicID}"));
    }

    public void SetLiveData(bool running = false, float processValue = (float)0.0, bool alarmActive = false, int numAlarms = 0, bool numAlarmsAboveLimit = false)
    {
        Running = running;
        ProcessValue = processValue;
        AlarmActive = alarmActive;
        NumAlarms = numAlarms;
        NumAlarmsAboveLimit = numAlarmsAboveLimit;
    }
}

