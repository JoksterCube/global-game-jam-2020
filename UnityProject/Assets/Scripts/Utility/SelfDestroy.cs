using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    public Transform target;
    public float destroyThreshold = 15;

    private void FixedUpdate()
    {
        if (target is null) return;
        if (target.position.x - transform.position.x >= destroyThreshold)
            Destroy(gameObject);
    }
}
