using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTracker : MonoBehaviour
{
    private GameState gameState;

    private void Start()
    {
        gameState = GameObject.Find("GM").GetComponent<GameState>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            gameState?.VICTORY();

        }
        if (collision.gameObject.tag == "Enemy")
        {
            gameState?.DEFEAT();
        }
    }
}
