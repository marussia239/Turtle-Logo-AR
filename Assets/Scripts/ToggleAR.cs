using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ToggleAR : MonoBehaviour
{
    public ARPlaneManager planeManager;
    public ARPointCloudManager pointCloudManager;

    public void OnValueChanged(bool isOn) {

        VisualizePlanes(isOn);
        VisualizePoints(isOn);
    }

    private void VisualizePlanes(bool active) {

        planeManager.enabled = active;
        foreach (ARPlane plane in planeManager.trackables) {
            plane.gameObject.SetActive(active);
        }
    }

    private void VisualizePoints(bool active)  {

        pointCloudManager.enabled = active;
        foreach (ARPointCloud point in pointCloudManager.trackables)
        {
            point.gameObject.SetActive(active);
        }
    }
}
