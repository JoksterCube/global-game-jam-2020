using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameState : MonoBehaviour
{
    public GameObject VicScreen;
    public GameObject DefScreen;
    public AudioSource DefSound;
    public AudioSource VicSound;
    //bool m_Play;
    // Start is called before the first frame update
    void Start()
    {
        //DefSound = GetComponent<AudioSource>();
        //VicSound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void VICTORY()
    {
        VicScreen.transform.position = new Vector3(0, 0, -9);
        VicScreen.SetActive(true);
        //VicSound.Play();
        Debug.Log("W");
    }
    public void DEFEAT()
    {
        DefScreen.transform.position = new Vector3(0, 0, -9);
        DefScreen.SetActive(true);
        //DefSound.Play();
        Debug.Log("L");
    }

}
