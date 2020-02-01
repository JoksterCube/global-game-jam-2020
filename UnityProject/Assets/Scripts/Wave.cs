using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    private int rippleCount;
    private float rippleTime;
    private float rippleDelay;
    private float rippleRange;
    private AnimationCurve waveStrenghCurve;

    ObjectMover objectMover;
    AudioManager audioManager;
    AudioSource audioSource;

    public Ripple ripplePrefab;
    private float nextWaveTime = 0;

    private float audioEnd = float.MaxValue;

    private void Awake()
    {
        objectMover = GetComponentInParent<ObjectMover>();
        audioSource = GetComponent<AudioSource>();
        audioManager = FindObjectsOfType<AudioManager>()?[0];
    }

    public void Start()
    {
        AudioClip clip = audioManager.GetRippleSound();
        audioSource.clip = clip;
        audioSource.Play();
        audioEnd = Time.time + clip.length;
    }

    public void Update()
    {
        if (waveStrenghCurve is null)
            return;
        if (rippleCount > 0)
        {
            if (nextWaveTime <= Time.time)
            {
                Ripple();
                nextWaveTime = Time.time + rippleDelay;
                rippleCount--;
            }
        }
        else if (audioEnd <= Time.time)
            Destroy(gameObject, rippleTime);
    }

    public void SetValues(int rippleCount, float rippleTime, float rippleDelay, float rippleRange, AnimationCurve waveStrenghCurve)
    {
        this.rippleCount = rippleCount;
        this.rippleTime = rippleTime;
        this.rippleDelay = rippleDelay;
        this.rippleRange = rippleRange;
        this.waveStrenghCurve = waveStrenghCurve;
    }
    private void Ripple()
    {
        Ripple ripple = Instantiate(ripplePrefab, transform.position, Quaternion.identity, transform) as Ripple;
        ripple.SetValues(rippleRange, rippleTime, waveStrenghCurve, objectMover);
    }
}
