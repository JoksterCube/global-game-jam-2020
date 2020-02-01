using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTracker : MonoBehaviour
{
    private GameState gameState;
    //public HealthSystem hpSystem;
    

    private void Start()
    {
        
        gameState = GameObject.Find("GM").GetComponent<GameState>();
        //hpSystem = GameObject.Find("GM").GetComponent<HealthTracker>().healthSystem;
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
            //hpSystem.Damage(33);

            //Debug.Log(hpSystem.GetHealth());
            /*if(hpSystem.GetHealth()==0)
            {
                
            }*/

        }
    }
}
