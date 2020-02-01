using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public delegate void OnWaveDelegate(Vector2 position, float force, float range, AnimationCurve waveStrenghCurve, float distance, int id);
    public static OnWaveDelegate waveDelegate;

    public float force = 10;
    public float range = 10;
    public int rippleCount = 3;
    public float rippleTime = 3;
    public float rippleDelay = 1;
    public AnimationCurve waveStrenghCurve = AnimationCurve.EaseInOut(0,0,1,1);

    public Wave prefab;

    public void StartWaveAtPosition(Vector2 position)
    {
        Wave wave = Instantiate(prefab, position, Quaternion.identity, transform) as Wave;
        wave.SetValues(rippleCount, rippleTime, rippleDelay, range, waveStrenghCurve);
    }

    public void Wave(Vector2 position, float distance, int id) => waveDelegate(position, force, range, waveStrenghCurve, distance, id);
}
