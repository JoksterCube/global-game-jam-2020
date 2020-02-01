using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RandomMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public float amplitude = 1;
    public float torque = 5;
    public float force = 5;
    public float threshold = .5f;
    public float maxPause = 1;
    public float minPause = .5f;

    private Vector2 pivotPoint;
    private float nextAdjust = 0;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        pivotPoint = transform.position;
    }

    private void FixedUpdate()
    {
        if (nextAdjust <= Time.time)
        {
            Move();
            Rotate();
            nextAdjust = Time.time + Random.Range(minPause, maxPause);
        }
    }

    private void Move()
    {
        Vector2 direction = Vector2.zero;
        if (Vector2.Distance(transform.position, pivotPoint) <= threshold * amplitude)
            direction = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1)).normalized;
        else
            direction = (pivotPoint - (Vector2)transform.position).normalized;
        rb.AddForce(direction * Random.Range(0, force));
    }

    private void Rotate() => rb.AddTorque(Random.Range(-torque, torque));
}
