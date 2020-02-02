using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleFacts : MonoBehaviour
{
    public List<string> randomFacts;

    public List<string> meaningfulThoughts;
    public float minTime=5;
    public float maxTime=10;
    public float delay;

    public float initialWait = 5;

    private float nextMessageTime = 0;

    private void Awake()
    {
        nextMessageTime = Time.time + initialWait;
    }

    private void Update()
    {
        if (nextMessageTime <= Time.time)
        {
            ShowMessage();
            nextMessageTime = Time.time + Random.Range(minTime, maxTime) + delay;
        }
    }


    private void ShowMessage()
    {
        Debug.Log("Interesting fact about turtle");
    }
}
