using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListItemPrefabController : MonoBehaviour
{
    private Color color;
    public ITopicContainer topicContainer;


    void Start()
    {
        InvokeRepeating(nameof(Refresh), 0f, 2f);
    }

    void Update()
    {
        
    }

    private void Refresh()
    {
        if (topicContainer.AlarmActive)
        {
            this.GetComponentInParent<Image>().color = Color.red;
        }
        else if (topicContainer.NumAlarmsAboveLimit)
        {
            this.GetComponentInParent<Image>().color = Color.yellow;
        }
        else
        {
            this.GetComponentInParent<Image>().color = Color.gray;
        }
    }
}
