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

    public void VICTORY()
    {
        VicScreen.transform.position = new Vector3(0, 0, -1);
        VicScreen.SetActive(true);
        Debug.Log("W");
    }
    public void DEFEAT()
    {
        DefScreen.transform.position = new Vector3(0, 0, -1);
        DefScreen.SetActive(true);
        Debug.Log("L");
    }

}
