using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovableObject : MonoBehaviour
{
    Rigidbody2D rb;

    public float torqueLimit = 5;

    private List<int> ignoreIDs = new List<int>();

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ObjectMover.waveDelegate -= OnWave;
        ObjectMover.waveDelegate += OnWave;
    }
    private void OnWave(Vector2 position, float force, float range, AnimationCurve waveStrenghCurve, float distance, int id)
    {
        if (ignoreIDs.Contains(id))
            return;
        if (Vector2.Distance(position, transform.position) > distance)
            return;
        Wave(position, force, range, waveStrenghCurve);
        ignoreIDs.Add(id); // MUST CHANGE LATER
    }
    private void Wave(Vector2 position, float force, float range, AnimationCurve waveStrenghCurve)
    {
        float strengh = GetCorrectValue(position, range, waveStrenghCurve);
        float pushForce = strengh * force;
        Vector2 direction = (Vector2)transform.position - position;
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

    private float GetCorrectValue(Vector2 position, float range, AnimationCurve waveStrenghCurve)
    {
        float distance = Vector2.Distance(position, transform.position);
        float t = Mathf.InverseLerp(range, 0, distance);
        return waveStrenghCurve.Evaluate(t);
    }
}
