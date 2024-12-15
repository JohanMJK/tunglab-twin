using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
using System.Text;

public class UIManager : MonoBehaviour
{
    public UnityEngine.UI.Button settingsButton;
    public UnityEngine.UI.Button closeSettingsButton;
    public UnityEngine.UI.Button connectButton;
    public GameObject settingsPanel;
    public UIDocument uiDocument;

    public TMP_InputField serverField;
    public TMP_InputField databaseField;
    public TMP_InputField userIDField;
    public TMP_InputField passwordField;

    private ScrollView scrollView;
    private List<CustomFoldout> headerFoldouts;
    private List<CustomFoldout> liveFoldouts;


    void Start()
    {
        settingsPanel.SetActive(false);
        settingsButton.onClick.AddListener(SettingsButtonListener);
        closeSettingsButton.onClick.AddListener(CloseSettingsButtonListener);
        connectButton.onClick.AddListener(ConnectButtonListener);

        var rootElement = uiDocument.rootVisualElement;
        var parentElement = rootElement.Q<VisualElement>("LeftVisualElement");
        scrollView = parentElement.Q<ScrollView>("SystemsListScrollView");
    }

    void Update()
    {

    }

    private void PopulateScrollView()
    {
        headerFoldouts = new List<CustomFoldout>();
        liveFoldouts = new List<CustomFoldout>();

        foreach (string systemName in DatabaseManager.SystemNames)
        {
            var foldout = new CustomFoldout(systemName, Color.black);
            scrollView.Add(foldout);
            headerFoldouts.Add(foldout);
        }

        foreach (CustomFoldout foldout in headerFoldouts)
        {
            foreach (TopicContainer container in DatabaseManager.LiveContainers)
            {
                if (container.SystemName == foldout.text)
                {
                    foldout.Add(container.Foldout);
                    liveFoldouts.Add(container.Foldout);
                }
            }
        }

        foreach (CustomFoldout foldout in headerFoldouts)
        {
            foreach (TopicContainer container in DatabaseManager.StaticContainers)
            {
                if (container.SystemName == foldout.text)
                {
                    foldout.Add(container.Foldout);
                }
            }
        }
    }

    private void RefreshScrollView()
    {
        foreach (CustomFoldout foldout in liveFoldouts)
        {
            foldout.Refresh();
        }
    }

    private async void GetDataUpdateRepeating()
    {
        await DatabaseManager.UpdateLiveData();
    }

    void SettingsButtonListener()
    {
        settingsPanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
    }

    void CloseSettingsButtonListener()
    {
        settingsPanel.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
    }

    async void ConnectButtonListener()
    {
        DatabaseManager.connectionString = $"Server={serverField.text};Database={databaseField.text};" +
                                        $"User ID={userIDField.text};Password={passwordField.text};";
        
        if (DatabaseManager.TestConnection()) 
        {
            Debug.Log("Connected.");
            await DatabaseManager.PopulateLists();
            PopulateScrollView();
            await DatabaseManager.UpdateLiveData();
            InvokeRepeating(nameof(GetDataUpdateRepeating), 2f, 2f);
            InvokeRepeating(nameof(RefreshScrollView), 2f, 2f);
        }
        else {Debug.Log("Failed to connect.");}
        EventSystem.current.SetSelectedGameObject(null);
    }
}