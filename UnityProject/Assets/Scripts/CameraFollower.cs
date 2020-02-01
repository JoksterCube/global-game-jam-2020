using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollower : MonoBehaviour
{
    Camera cam;

    public Transform followee;
    public float speed;

    [Header("Corners")]
    public Vector2 topLeftCorner;
    public Vector2 bottomRightCorner;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        if (followee is null)
            return;

        float step = 1 / speed * Time.deltaTime;

        Vector2 topLeft = cam.ViewportToWorldPoint(Vector3.up);
        Vector2 bottomRight = cam.ViewportToWorldPoint(Vector3.right);
        float x = Mathf.Abs(bottomRight.x - topLeft.x);
        float y = Mathf.Abs(topLeft.y - bottomRight.y);
        float half_x = x / 2;
        float half_y = y / 2;

        Vector2 targetPosition = followee.position;
        targetPosition.x = targetPosition.x < topLeftCorner.x + half_x ? topLeftCorner.x + half_x : targetPosition.x;
        targetPosition.x = targetPosition.x > bottomRightCorner.x - half_x ? bottomRightCorner.x - half_x : targetPosition.x;
        targetPosition.y = targetPosition.y > topLeftCorner.y - half_y ? topLeftCorner.y - half_y : targetPosition.y;
        targetPosition.y = targetPosition.y < bottomRightCorner.y + half_y ? bottomRightCorner.y + half_y : targetPosition.y;
        transform.position = Vector3.Slerp((Vector2)transform.position, targetPosition, step) + Vector3.forward * transform.position.z;
    }

}
