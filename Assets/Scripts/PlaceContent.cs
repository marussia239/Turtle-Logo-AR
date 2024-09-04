using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceContent : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public GraphicRaycaster raycaster;
    public GameObject figurePrefab;

    private GameObject spawnedFigure;

    private Camera arCamera;

    private void Start() {

        arCamera = Camera.main;

        if (figurePrefab != null)
        {
            figurePrefab.SetActive(false);
        }
    }

    private void Update() {

        if (Input.GetMouseButtonDown(0) && !IsClickOverUI()) {

            List<ARRaycastHit> hitPoints = new List<ARRaycastHit>();
            raycastManager.Raycast(Input.mousePosition, hitPoints, TrackableType.Planes);

            if (hitPoints.Count > 0) {
                Pose pose = hitPoints[0].pose;

                if (figurePrefab != null)
                {
                    figurePrefab.SetActive(true);

                    figurePrefab.SetActive(true);
                    figurePrefab.transform.position = pose.position;
                    figurePrefab.transform.rotation = pose.rotation;

                    TurtleController turtleController = figurePrefab.GetComponent<TurtleController>();
                    if (turtleController != null)
                    {
                        turtleController.ResetLine();
                    }

                    Vector3 direction = arCamera.transform.position - figurePrefab.transform.position;
                    direction.y = 0;
                    figurePrefab.transform.rotation = Quaternion.LookRotation(-direction);
                }

            }
        }
    }

    bool IsClickOverUI() {
        PointerEventData data = new PointerEventData(EventSystem.current) {
            position = Input.mousePosition
        };
        List<RaycastResult> results = new List<RaycastResult>();
        raycaster.Raycast(data, results);
        return results.Count > 0;
    }
}
