using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurtleFacts : MonoBehaviour
{
    public List<string> randomFacts;

    public Text bubbleText;
    public Image bubble;

    public float minTime = 5;
    public float maxTime = 10;
    public float delay;

    public float initialWait = 5;

    [Range(0, 1)]
    public float alpha = .75f;
    public float fadeTime = .5f;

    private float nextMessageTime = float.MaxValue;

    private List<int> usedIndexes = new List<int>();
    private bool showBubble = false;
    private float currentFade = 0;
    private float stopShowingMessage = float.MaxValue;
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

        float step = 1 / fadeTime * Time.deltaTime;

        currentFade = Mathf.Clamp01(currentFade + (showBubble ? step : -step));

        bubbleText.color = new Color(bubbleText.color.r, bubbleText.color.g, bubbleText.color.b, currentFade * alpha);
        bubble.color = new Color(bubble.color.r, bubble.color.g, bubble.color.b, currentFade * alpha);

        if(showBubble && stopShowingMessage <= Time.time)
            showBubble = false;
    }


    private void ShowMessage()
    {
        if (randomFacts.Count == usedIndexes.Count)
            return;
        int index;
        do
        {
            index = Random.Range(0, randomFacts.Count);
        } while (usedIndexes.Contains(index));
        usedIndexes.Add(index);
        string message = randomFacts[index];

        bubbleText.text = message;
        stopShowingMessage = Time.time + delay;
        showBubble = true;
    }
}
