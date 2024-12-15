using UnityEngine;
using UnityEngine.EventSystems;
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
            cursorInputForLook = cursorLocked;
            
            if (cursorLocked) { Cursor.lockState = CursorLockMode.Locked; }
            else { Cursor.lockState = CursorLockMode.None; }
            
            Cursor.visible = !cursorLocked;
        }
    }

    void ModeButtonListener()
    {
        cam1Active = !cam1Active;
        cam2Active = !cam2Active;
        cam1.SetActive(cam1Active);
        cam2.SetActive(cam2Active);
        if (cam1Active)
        {
            cam1.tag = "MainCamera";
            cam2.tag = "Untagged";
        }
        else
        {
            cam2.tag = "MainCamera";
            cam1.tag = "Untagged";
        }
        RenderSettings.fog = cam1Active;
        EventSystem.current.SetSelectedGameObject(null);
    }
}
