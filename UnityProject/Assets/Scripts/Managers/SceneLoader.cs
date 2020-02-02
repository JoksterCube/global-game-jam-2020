using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int menuSceneIndex = 0;
    public int gameSceneIndex = 1;

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void PlayGame() => LoadScene(gameSceneIndex);
    public void PlayMenu() => LoadScene(menuSceneIndex);
}
