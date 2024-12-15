using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScrollableList : MonoBehaviour
{
    public string systemName;
    public UnityEngine.UI.Button listItemPrefab;
    public Transform contentParent;


    void Start()
    {
        PopulateLists();
    }

    private async void PopulateLists()
    {
        await DatabaseManager.PopulateListsDone();
        try
        {
            foreach (var container in DatabaseManager.LiveContainers)
            {
                if (container.SystemName == systemName)
                {
                    Button instantiatedButton = Instantiate(listItemPrefab, contentParent.transform);
                    instantiatedButton.GetComponentInChildren<TextMeshProUGUI>().text = container.Description;
                    instantiatedButton.GetComponent<ListItemPrefabController>().topicContainer = container;
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error populating list: {ex.Message}");
        }
    }

    private void Update()
    {   
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
    }
}