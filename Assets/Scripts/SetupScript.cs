using UnityEngine;

public class SetupScript : MonoBehaviour
{
    void Start()
    {
        RenderSettings.fogMode = FogMode.Linear;
        RenderSettings.fogStartDistance = 50.0f;
        RenderSettings.fogEndDistance = 100.0f;
    }
}
