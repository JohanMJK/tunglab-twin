using UnityEngine;
using UnityEngine.UIElements;

public class CustomFoldout : Foldout
{
    private ITopicContainer _container;
    public int TopicID { get; set; }

    public CustomFoldout(ITopicContainer container, int topicID, string v_text) 
    { 
        _container = container;
        TopicID = topicID;
        text = v_text;
        value = false;
    }

    public CustomFoldout(string v_text, Color color)
    {
        text = v_text;
        style.color = color;
        value = false;
    }

    public void Refresh()
    {
        if (_container.AlarmActive)
        {
            this.style.color = Color.red;
        }
        else if (_container.NumAlarmsAboveLimit)
        {
            this.style.color = Color.yellow;
        }
        else
        {
            this.style.color = Color.black;
        }
    }
}
