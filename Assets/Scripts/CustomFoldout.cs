using UnityEngine;
using UnityEngine.UIElements;


public class CustomFoldout : Foldout
{
    public int TopicID { get; set; }

    public CustomFoldout() { }

    public CustomFoldout(int topicID, string v_text, Color color)
    {
        TopicID = topicID;
        text = v_text;
        style.color = color;
        value = false;
    }

    public CustomFoldout(string v_text, Color color)
    {
        text = v_text;
        style.color = color;
        value = false;
    }
}
