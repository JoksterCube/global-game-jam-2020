using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GameStateTracker))]
public class LifeTracker : MonoBehaviour
{
    public Image dangerIndicator;

    private GameStateTracker gameStateTracker;

    [Range(0,1)]
    public float regenerationSpeed = .1f;
    [Range(0, 1)]
    public float losingSpeed = .2f;

    public float delayUntilRegeneration = 1;

    private float currentDanger = 0;
    private float nextRegeneration = 0;
    private bool hasHappenedThisFixedFrame = false;
    private void Awake()
    {
        gameStateTracker = GetComponent<GameStateTracker>();
    }
    private void Update()
    {
        if (nextRegeneration <= Time.time)
        {
            if (currentDanger > 0)
                currentDanger -= regenerationSpeed * Time.deltaTime;
        }
        currentDanger = Mathf.Clamp01(currentDanger);
        dangerIndicator.fillAmount = currentDanger;
    }
    private void FixedUpdate()
    {
        hasHappenedThisFixedFrame = false;
    }
    public void UpdateDanger()
    {
        if (!hasHappenedThisFixedFrame)
        {
            hasHappenedThisFixedFrame = true;
            nextRegeneration = Time.time + delayUntilRegeneration;
            currentDanger += losingSpeed * Time.fixedDeltaTime;
            if (currentDanger >= 1)
                Dead();
        }
    }

    private void Dead()
    {
        gameStateTracker.Dead();
    }
}
