using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using TMPro;

public class ScrollableList : MonoBehaviour
{
    public string SystemName;
    public GameObject listItemPrefab;
    public GameObject listItemPrefabYellow;
    public GameObject listItemPrefabRed;
    public GameObject dataBoxPrefab;
    public Transform contentParent;

    void Start()
    {
        PopulateLists();
    }

    private async void PopulateLists()
    {
        await DatabaseManager.PopulateListsDone();

        var contentContainer = contentParent.GetComponent<VerticalLayoutGroup>();
        var textFinderButton = GetComponent<ListItemPrefabButton>();

        try
        {
            foreach (var container in DatabaseManager.LiveTopicContainers)
            {
                if (container.SystemName == SystemName)
                {
                    GameObject listItem;
                    if (container.AlarmActive) { listItem = Instantiate(listItemPrefabRed, contentParent.transform); }
                    else if (container.NumAlarmsAboveLimit) { listItem = Instantiate(listItemPrefabYellow, contentParent.transform); }
                    else { listItem = Instantiate(listItemPrefab, contentParent.transform); }

                    var label = listItem.GetComponent<TextMeshProUGUI>();
                    label.text = container.Description;
                    label.fontSize = 7;
                    label.color = Color.black;

                    Debug.Log($"Added: {container.Description}");   
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error populating list: {ex.Message}");
        }
    }

    void OnListItemClicked(string item)
    {
        Debug.Log($"Clicked: {item}");

        //var dataBox = Instantiate(dataBoxPrefab);

        //dataBox.name = $"DataBox_{item}";
        //dataBox.transform.position = Vector3.zero;
    }

    private void Update()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
    }
}