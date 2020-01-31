using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    ObjectMover objectMover;

    public int RippleCount { get; set; }
    public float RippleDelay { get; set; }

    private float nextWaveTime = 0;
    private void Awake()
    {
        objectMover = GetComponentInParent<ObjectMover>();
    }

    public void Update()
    {
        if (RippleCount > 0)
        {
            if (nextWaveTime <= Time.time)
            {
                objectMover.Wave(transform.position);
                nextWaveTime = Time.time + RippleDelay;
                RippleCount--;
            }
        }
        else
            Destroy(gameObject);
    }
}
