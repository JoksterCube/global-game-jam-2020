using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickRegistration : MonoBehaviour
{
    public Camera cam;
    public bool log = false;

    private ObjectMover objectMover;
    private void Awake()
    {
        objectMover = GetComponent<ObjectMover>();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
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
