using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ripple : MonoBehaviour
{
    private float range;
    private float time;
    private AnimationCurve curve;
    private ObjectMover objectMover;

    private float timeSinceStart = 0;

    private void Awake()
    {
        transform.localScale = Vector3.zero;
    }
    private void Update()
    {
        if (timeSinceStart > time)
            Stop();
        float scale = GetNewScale(timeSinceStart);
        UpdateRipple(scale);
        objectMover.Wave(transform.position, scale, gameObject.GetInstanceID());
        timeSinceStart += Time.deltaTime;
    }
    public void SetValues(float range, float time, AnimationCurve curve, ObjectMover objectMover)
    {
        this.range = range;
        this.time = time;
        this.curve = curve;
        this.objectMover = objectMover;
    }
    private float GetNewScale(float progress)
    {
        float t = Mathf.InverseLerp(0, time, progress);
        float ct = curve.Evaluate(t);
        return ct * range * 2;
    }
    private void UpdateRipple(float scale) => transform.localScale = Vector3.one * scale;
    private void Stop() => Destroy(gameObject);
}
