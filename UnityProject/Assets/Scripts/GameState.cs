using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameState : MonoBehaviour
{
    public GameObject VicScreen;
    public GameObject DefScreen;
    public HealthBar hpBar;
    //public HealthSystem hpSystem;
    
    // Start is called before the first frame update
    void Start()
    {
        HealthSystem hpSystem = new HealthSystem(100);
        hpBar.Setup(hpSystem);
        Debug.Log("Health:" + hpSystem.GetHealth());
        hpSystem.Damage(30);
        Debug.Log("Health:" + hpSystem.GetHealth());
        hpSystem.Heal(20);
        Debug.Log("Health:" + hpSystem.GetHealth());


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void VICTORY()
    {
        VicScreen.transform.position = new Vector3(0, 0, -9);
        
        
        
        Debug.Log("W");
    }
    public void DEFEAT()
    {
        DefScreen.transform.position = new Vector3(0, 0, -9);
        
        
        Debug.Log("L");
    }

}
