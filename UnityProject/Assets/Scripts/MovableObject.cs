using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovableObject : MonoBehaviour
{
    Rigidbody2D rb;

    public float torqueLimit = 5;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        ObjectMover.waveDelegate -= OnWave;
        ObjectMover.waveDelegate += OnWave;
    }

    private void OnWave(Vector2 position, float force, float range, AnimationCurve waveStrenghCurve)
    {
        Vector2 curPosition = transform.position;
        float distance = Vector2.Distance(position, curPosition);
        if (distance >= range)
            return;
        float t = Mathf.InverseLerp(range, 0, distance);
        float strengh = waveStrenghCurve.Evaluate(t);
        float pushForce = strengh * force;
        Vector2 direction = curPosition - position;
        Push(direction, pushForce);
        Rotate(strengh);
    }

    private void Push(Vector2 direction, float multiplier)
    {
        Vector2 force = direction.normalized * multiplier;
        rb.AddForce(force);
    }

    private void Rotate(float strengh)
    {
        float torque = Random.Range(-torqueLimit, torqueLimit) * strengh;
        rb.AddTorque(torque);
    }
}
