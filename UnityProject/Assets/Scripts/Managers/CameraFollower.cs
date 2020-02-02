using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollower : MonoBehaviour
{
    Camera cam;

    public Transform followee;
    public float speed;

    public Vector2 topBottomBoundaries;

    public float sideScrollerSpeed = 1;
    private float sideScrollerProgressionX = -10;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        sideScrollerProgressionX += speed * Time.deltaTime;
    }

    private void LateUpdate()
    {
        if (followee is null)
            return;

        float step = speed * Time.deltaTime;

        Vector2 topLeft = cam.ViewportToWorldPoint(Vector3.up);
        Vector2 bottomRight = cam.ViewportToWorldPoint(Vector3.right);
        float x = Mathf.Abs(bottomRight.x - topLeft.x);
        float y = Mathf.Abs(topLeft.y - bottomRight.y);
        float half_x = x / 2;
        float half_y = y / 2;

        Vector2 targetPosition = followee.position;
        //targetPosition.x = targetPosition.x < sideScrollerProgressionX + half_x ? sideScrollerProgressionX + half_x : targetPosition.x;

        targetPosition.y = targetPosition.y < topBottomBoundaries.x + half_y ? topBottomBoundaries.x + half_y : targetPosition.y;
        targetPosition.y = targetPosition.y > topBottomBoundaries.y - half_y ? topBottomBoundaries.y - half_y : targetPosition.y;
        transform.position = Vector3.Slerp((Vector2)transform.position, targetPosition, step) + Vector3.forward * transform.position.z;
    }

}