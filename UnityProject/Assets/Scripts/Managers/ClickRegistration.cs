using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectMover))]
public class ClickRegistration : MonoBehaviour
{
    public Camera cam;
    public bool log = false;

    private bool first = true;

    private CameraFollower cameraFollower;
    private ObjectMover objectMover;
    private void Awake()
    {
        objectMover = GetComponent<ObjectMover>();
        cameraFollower = cam.GetComponent<CameraFollower>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (first)
            {
                cameraFollower.StartCamera();
                first = false;
            }
            Vector2 wavePosition = Coordinates();
            if (log)
                Debug.Log("Koordinatės:" + wavePosition);
            objectMover.StartWaveAtPosition(wavePosition);
        }
    }

    public Vector2 Coordinates()
    {
        var mousePos = Input.mousePosition;
        Vector2 p = cam.ScreenToWorldPoint(mousePos);

        return p;
    }

}
