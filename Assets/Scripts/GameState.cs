using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{

    public static GameState instance;

    public GameObject Tutorial;
    public GameObject GameWinScreen;

    private void Start()
    {
        instance = this;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if( scene.buildIndex == 1 && !GlobalStaticVars.hasViewedTutorial)
        {
            Time.timeScale = 0;
            Tutorial.SetActive(true);
            GlobalStaticVars.hasViewedTutorial = true;
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void Win()
    {
        Time.timeScale = 0;
        GameWinScreen.SetActive(true);
    }
}
