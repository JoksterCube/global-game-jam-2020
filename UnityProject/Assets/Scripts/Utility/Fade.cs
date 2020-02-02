using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Image fadeImage;

    public float fadeSpeed = 5;
    [Range(0, 1)]
    public int startFade = 1;
    public bool fadeOnStart = true;

    private bool fadeIn = false;
    private float currentFade = 0;

    private void Awake()
    {
        fadeImage = GetComponent<Image>();
        currentFade = startFade;
        if (fadeOnStart)
            fadeIn = startFade == 1;
    }

    private void Update()
    {
        float step = (1 / fadeSpeed);
        if (currentFade < 1 && !fadeIn)
        {
            currentFade += Time.deltaTime * step;
        }
        else if (currentFade > 0 && fadeIn)
        {
            currentFade -= Time.deltaTime * step;
        }
        currentFade = Mathf.Clamp01(currentFade);
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, currentFade);
    }

    public void FadeIn() => fadeIn = true;
    public void FadeOut() => fadeIn = false;
}
