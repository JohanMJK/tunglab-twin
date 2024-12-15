using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ListItemPrefabController : MonoBehaviour
{
    public ITopicContainer topicContainer;
    //public GameObject dataBoxPrefab;


    void Start()
    {
        //this.GetComponentInParent<UnityEngine.UI.Button>().onClick.AddListener(OnClickListener);
        InvokeRepeating(nameof(Refresh), 0f, 2f);
    }

    void Update()
    {
        
    }

    private void Refresh()
    {
        if (topicContainer.AlarmActive)
        {
            this.GetComponentInParent<Image>().color = new Color(0.6f, 0f, 0f, 1f);
        }
        else if (topicContainer.NumAlarmsAboveLimit)
        {
            this.GetComponentInParent<Image>().color = new Color(0.7f, 0.6f, 0f, 1f);
        }
        else
        {
            this.GetComponentInParent<Image>().color = new Color(0.6f, 0.6f, 0.6f, 1f);
        }
    }

    //void OnClickListener()
    //{
    //    GameObject instantiatedDataBox = Instantiate(dataBoxPrefab);
    //    instantiatedDataBox.GetComponent<DataBoxController>().topicContainer = topicContainer;
    //    EventSystem.current.SetSelectedGameObject(null);
    //}
}
