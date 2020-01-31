using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public int RippleCount { get; set; }
    public float RippleDelay { get; set; }

    ObjectMover objectMover;

    public Transform ripple;


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
                Ripple();
                nextWaveTime = Time.time + RippleDelay;
                RippleCount--;
            }
        }
        else
            Destroy(gameObject);
    }

    private void Ripple()
    {
        objectMover.Wave(transform.position);

    }
}
