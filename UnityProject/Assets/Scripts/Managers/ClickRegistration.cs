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
    private bool dead = false;
    private void Awake()
    {
        objectMover = GetComponent<ObjectMover>();
        cameraFollower = cam.GetComponent<CameraFollower>();
    }

    private void Update()
    {
        if (dead) return;


        if (Input.GetKeyDown(KeyCode.Mouse0))
            Actions(Input.mousePosition);
        else if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; ++i)
            {
                Touch touch = Input.GetTouch(i);
                if (touch.phase == TouchPhase.Began)
                    Actions(touch.position);
            }
        }
    }

    private void Actions(Vector2 inputPosition)
    {
        if (first)
        {
            cameraFollower.StartCamera();
            first = false;
        }
        Vector2 wavePosition = Coordinates(inputPosition);
        if (log)
            Debug.Log("Koordinatės:" + wavePosition);
        objectMover.StartWaveAtPosition(wavePosition);
    }

    public Vector2 Coordinates(Vector2 screenPos) => cam.ScreenToWorldPoint(screenPos);

    public void Dead() => dead = true;
}
