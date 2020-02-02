using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollower : MonoBehaviour
{
    Camera cam;
    GameStateTracker gameStateTracker;

    public Transform followee;
    public float speed;

    public Vector2 topBottomBoundaries;

    private bool going = false;
    private float sideScrollerProgressionX = -30;
    private float zPos;

    private void Awake()
    {
        cam = GetComponent<Camera>();
        zPos = transform.position.z;
    }
    private void Start()
    {
        gameStateTracker = GameObject.Find("GM").GetComponent<GameStateTracker>();
    }

    private void Update()
    {
        if (going)
            sideScrollerProgressionX = cam.ViewportToWorldPoint(Vector3.up).x;
        if (sideScrollerProgressionX >= followee.position.x)
        {
            gameStateTracker.Dead();
        }
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
        Vector3 curPos = transform.position;
        targetPosition.x = targetPosition.x < sideScrollerProgressionX + half_x ? sideScrollerProgressionX + half_x : targetPosition.x;

        targetPosition.y = targetPosition.y < topBottomBoundaries.x + half_y ? topBottomBoundaries.x + half_y : targetPosition.y;
        targetPosition.y = targetPosition.y > topBottomBoundaries.y - half_y ? topBottomBoundaries.y - half_y : targetPosition.y;
        transform.position = Vector3.Slerp(curPos, (Vector3)targetPosition + Vector3.forward * zPos, step);
    }

    public void StartCamera() => going = true;
    public void StopCamera() => going = false;
}