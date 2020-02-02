using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateTracker : MonoBehaviour
{
    public enum GameStates { Normal, Menu, Lose, Victory, Exit }
    private GameStates currentState;

    public Canvas canvas;
    public Image image;

    public void Dead()
    {
        currentState = GameStates.Lose;
    }
}
