using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickRegistration : MonoBehaviour
{
    public Camera cam;
    public Vector2 Coordinates()
    {
        var mousePos = Input.mousePosition;
        Vector2 p = cam.ScreenToWorldPoint(mousePos);

        return p;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Koordinatės:"+Coordinates());
        }
    }
}
