using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameState : MonoBehaviour
{
    public GameObject VicScreen;
    public GameObject DefScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            VICTORY();
        }
        if(collision.gameObject.tag == "Enemy")
        {
            DEFEAT();
        }
    }
    void VICTORY()
    {
        VicScreen.transform.position = new Vector3(0, 0, -1);
        Debug.Log("W");
    }
    void DEFEAT()
    {
        DefScreen.transform.position = new Vector3(0, 0, -1);
        Debug.Log("L");
    }
    
}
