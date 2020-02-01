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
        rectTransform.localPosition = proportionalPosition - uiOffset + offset;
    }
}
