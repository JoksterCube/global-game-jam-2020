using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class TrackCanvasItem : MonoBehaviour
{
    private Canvas canvas;
    private Camera cam;
    private RectTransform rectTransform;
    private RectTransform canvasRectTransform;

    public Transform target;
    public Vector2 offset;

    public bool useSlerp = false;
    public float speed = 1;

    private Vector2 uiOffset;
    private void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
        canvasRectTransform = canvas.GetComponent<RectTransform>();
        rectTransform = GetComponent<RectTransform>();
    }
    private void Start()
    {
        cam = Camera.main;
        uiOffset = new Vector2((float)canvasRectTransform.sizeDelta.x / 2f, (float)canvasRectTransform.sizeDelta.y / 2f);
    }
    private void Update()
    {
        MoveToTargetPosition();

    }

    private void MoveToTargetPosition()
    {
        Vector2 targetPosition = target.position;
        Vector2 viewportPosition = cam.WorldToViewportPoint(targetPosition);
        Vector2 proportionalPosition = new Vector2(viewportPosition.x * canvasRectTransform.sizeDelta.x, viewportPosition.y * canvasRectTransform.sizeDelta.y);
        Vector2 pos = proportionalPosition - uiOffset + offset;
        if (useSlerp)
            rectTransform.localPosition = Vector3.Slerp(rectTransform.localPosition, pos, speed * Time.deltaTime);
        else
            rectTransform.localPosition = pos;
    }
}
