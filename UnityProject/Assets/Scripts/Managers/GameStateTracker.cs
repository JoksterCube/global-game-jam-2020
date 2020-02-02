using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateTracker : MonoBehaviour
{
    public enum GameStates { Normal, Menu, Lose, Victory, Exit }
    private GameStates currentState = GameStates.Normal;

    public Canvas canvas;
    public GameObject deathPanel;
    public Fade fade;

    public AudioManager audioManager;

    public float delay = 3;


    private bool deathHasStarted = false;
    private void Update()
    {
        if (currentState == GameStates.Lose && !deathHasStarted)
            StartDeath();
    }

    private void StartDeath()
    {
        deathHasStarted = true;
        audioManager.PlayDeath();
        fade.FadeOut();
        Invoke("ShowDeathPanel", delay);
    }

    public void Dead()
    {
        currentState = GameStates.Lose;
    }

    private void ShowDeathPanel()
    {
        deathPanel.SetActive(true);
    }
}
