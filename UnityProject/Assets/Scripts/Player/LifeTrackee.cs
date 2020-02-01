using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTrackee : MonoBehaviour
{
    private LifeTracker lifeTracker;

    private void Start()
    {
        lifeTracker = GameObject.Find("GM").GetComponent<LifeTracker>();
    }

    private void UpdateDangerMeter()
    {
        lifeTracker.UpdateDanger();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
            UpdateDangerMeter();
    }
}
