using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateTracker : MonoBehaviour
{
    public enum GameStates { Normal, Menu, Lose, Victory, Exit }
    private GameStates currentState;

    public void Dead()
    {
        currentState = GameStates.Lose;
    }
}
