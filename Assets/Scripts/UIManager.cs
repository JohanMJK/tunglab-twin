using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public UIDocument uiDocument;
    private ScrollView scrollView;
    private List<CustomFoldout> foldoutsList;
    private List<CustomFoldout> liveSubFoldoutsList;

    async void Start()
    {
        var rootElement = uiDocument.rootVisualElement;
        var parentElement = rootElement.Q<VisualElement>("LeftVisualElement");  
        scrollView = parentElement.Q<ScrollView>("SystemsListScrollView");
        await DatabaseManager.PopulateLists();
        PopulateScrollView();
        await DatabaseManager.UpdateLiveData();
        InvokeRepeating(nameof(GetDataUpdateRepeating), 2f, 2f);
    }

    void Update()
    {

    }

    private void PopulateScrollView()
    {
        foldoutsList = new List<CustomFoldout>();
        liveSubFoldoutsList = new List<CustomFoldout>();

        foreach (string item in DatabaseManager.SystemNamesList)
        {
            var foldout = new CustomFoldout(item, Color.black);
            scrollView.Add(foldout);
            foldoutsList.Add(foldout);
        }

        foreach (Foldout foldout in foldoutsList)
        {
            foreach (TopicContainer container in DatabaseManager.StaticTopicContainers.Concat(DatabaseManager.LiveTopicContainers))
            {
                if (container.SystemName == foldout.text)
                {
                    var subFoldout = container.ToFoldout();
                    foldout.Add(subFoldout);
                    if (container.IsLive) { liveSubFoldoutsList.Add(subFoldout); }
                }
            }
        }
    }

    private async void GetDataUpdateRepeating()
    {
        await DatabaseManager.UpdateLiveData();
    }
}
