using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DataBoxManager : MonoBehaviour
{

    public UIDocument uiDocument;
    private ListView listView;
    
    void Start()
    {
        //var rootElement = uiDocument.rootVisualElement;
        //listView = rootElement.Q<ListView>("DataListView");

        //listView.Add(new Label("test"));
        //listView.Add(new Label("test"));
        //listView.Add(new Label("test"));
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(Camera.main.transform);
        //transform.Rotate(0, 180, 0);
    }

    //void PopulateListView(ListView listView)
    //{
    //    var liveDataLabels = GetLiveData();

    //    foreach (var label in liveDataLabels)
    //    {
    //        scrollView.Add(label);
    //    }
    //}
}
