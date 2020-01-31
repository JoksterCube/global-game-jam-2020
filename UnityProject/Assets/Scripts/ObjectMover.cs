using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public delegate void OnWaveDelegate(Vector2 position, float force, float range);
    public static OnWaveDelegate waveDelegate;

    public float force = 10;
    public float range = 10;
    //public int rippleCount = 3;

    public void StartWaveAtPosition(Vector2 position)
    {
            waveDelegate(position, force, range);
    }
}
