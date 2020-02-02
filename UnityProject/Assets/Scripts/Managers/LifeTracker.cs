using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GameStateTracker))]
public class LifeTracker : MonoBehaviour
{
    public Image dangerWrapper;
    public Image dangerIndicator;

    private GameStateTracker gameStateTracker;

    public float fadeTime = 1;

    [Range(0, 1)]
    public float regenerationSpeed = .1f;
    [Range(0, 1)]
    public float losingSpeed = .2f;

    public float delayUntilRegeneration = 1;

    private float currentFade = 0;
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
        ((RectTransform)dangerIndicator.transform).localScale = (1 - currentDanger) * Vector3.one;
    }

    private void LateUpdate()
    {
        float step = 1 / fadeTime * Time.deltaTime;
        if (currentDanger <= 0)
            currentFade = Mathf.Clamp01(currentFade - step);
        else if (currentDanger > 0)
            currentFade = Mathf.Clamp01(currentFade + step);

        dangerWrapper.color = new Color(dangerWrapper.color.r, dangerWrapper.color.g, dangerWrapper.color.b, currentFade);
        dangerIndicator.color = new Color(dangerIndicator.color.r, dangerIndicator.color.g, dangerIndicator.color.b, currentFade);
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
