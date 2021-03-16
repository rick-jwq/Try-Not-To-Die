using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    public GameState gg;
    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void BackToHome(bool sendAnalytics)
    {
        if(sendAnalytics)
            gg.analysis(2);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);       
        GlobalStaticVars.skills = new List<GameObject>();
    }
}
