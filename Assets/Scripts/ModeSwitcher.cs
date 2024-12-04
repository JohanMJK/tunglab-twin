using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeSwitcher : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;

    public Button modeButton;
    
    public static bool cursorLocked;
    public static bool cursorInputForLook;

    private bool cam1Active;
    private bool cam2Active;

    void Start()
    {
        cam1Active = true;
        cam2Active = false;
        cam1.SetActive(cam1Active);
        cam2.SetActive(cam2Active);
        RenderSettings.fog = cam1Active;
        
        cursorLocked = true;
        cursorInputForLook = true;
        Cursor.visible = false;

        modeButton.onClick.AddListener(ModeButtonListener);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            cursorLocked = !cursorLocked;
            cursorInputForLook = !cursorInputForLook;
            Cursor.visible = !cursorInputForLook;

            //Debug.Log("M pressed");
        }
    }

    void ModeButtonListener()
    {
        cam1Active = !cam1Active;
        cam2Active = !cam2Active;
        cam1.SetActive(cam1Active);
        cam2.SetActive(cam2Active);
        RenderSettings.fog = cam1Active;

        Debug.Log("Button pressed");
    }
}
