using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private Vector2 screenBounds;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cam.transform.position.z));
    }
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, viewPos.x, screenBounds.x * -1);
        viewPos.y = Mathf.Clamp(viewPos.y, viewPos.y, screenBounds.y * -1);
        transform.position = viewPos;
    }
}
