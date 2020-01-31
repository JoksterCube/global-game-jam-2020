using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovableObject : MonoBehaviour
{
    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        ObjectMover.waveDelegate -= OnWave;
        ObjectMover.waveDelegate += OnWave;
    }

    private void OnWave(Vector2 position, float force, float range)
    {
        Vector2 curPosition = transform.position;
        float distance = Vector2.Distance(position, curPosition);
        if (distance >= range)
            return;
        float strengh = Mathf.InverseLerp(range, 0, distance);
        float pushForce = strengh * force;
        Vector2 direction = curPosition - position;
        Push(direction, pushForce);
    }

    private void Push(Vector2 direction, float multiplier)
    {
        Vector2 force = direction.normalized * multiplier;

        Debug.Log(force);
        rb.AddForce(force);
    }
}
