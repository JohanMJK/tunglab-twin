using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.fogMode = FogMode.Linear;
        RenderSettings.fogStartDistance = 50.0f;
        RenderSettings.fogEndDistance = 100.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
