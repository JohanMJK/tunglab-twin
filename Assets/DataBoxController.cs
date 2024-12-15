using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class DataBoxController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public ITopicContainer topicContainer;
    public TextMeshProUGUI headerLabel;
    public TextMeshProUGUI runningValueLabel;
    public TextMeshProUGUI processValueLabel;
    public TextMeshProUGUI alarmValueLabel;
    public TextMeshProUGUI numAlarmsValueLabel;
    public TextMeshProUGUI unitLabel;

    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;

    void Start()
    {
        //if (topicContainer.Running) { runningValueLabel.text = "Yes"; }
        //else { runningValueLabel.text = "No"; }
        //if (topicContainer.AlarmActive) { alarmValueLabel.text = "Yes"; }
        //else { alarmValueLabel.text = "No"; }

        //processValueLabel.text = topicContainer.ProcessValue.ToString();
        //numAlarmsValueLabel.text = topicContainer.NumAlarms.ToString();
        
        //unitLabel.text = topicContainer.Unit;
        //headerLabel.text = topicContainer.Description;

        rectTransform = GetComponent<RectTransform>();
        //canvas = GameObject.Find("MainUICanvas").GetComponent<Canvas>();
        canvas = GetComponentInParent<Canvas>();
        //canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Make the UI element interactable while dragging
        //canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //if (canvas == null)
        //    return;

        // Update the position of the UI element
        Vector2 movePosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out movePosition
        );

        rectTransform.anchoredPosition = movePosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Re-enable raycasting when dragging is finished
        //canvasGroup.blocksRaycasts = true;
    }

}
