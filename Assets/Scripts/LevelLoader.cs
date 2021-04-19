using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelLoader : MonoBehaviour
{

    public void LoadLevel()
    {

        if(GlobalStaticVars.level == 1)
        {
            GlobalStaticVars.enemyHP = 30f;
            GlobalStaticVars.enemyMS = 2f;
            GlobalStaticVars.enemyNumber = 10;
            GlobalStaticVars.LevelTime = 0;
            GlobalStaticVars.tutorialTime = 0;
            GlobalStaticVars.GameStart = true;
            SceneManager.LoadScene(1);       
        }
        if (GlobalStaticVars.level == 2)
        {
            GlobalStaticVars.enemyHP = 50f;
            GlobalStaticVars.enemyMS = 2.5f;
            GlobalStaticVars.enemyNumber = 20;
            GlobalStaticVars.LevelTime = 0;
            GlobalStaticVars.tutorialTime = 0;
            GlobalStaticVars.GameStart = true;
            SceneManager.LoadScene(1);
        }
        if (GlobalStaticVars.level == 3)
        {
            GlobalStaticVars.enemyHP = 100f;
            GlobalStaticVars.enemyMS = 3f;
            GlobalStaticVars.enemyNumber = 30;
            GlobalStaticVars.LevelTime = 0;
            GlobalStaticVars.tutorialTime = 0;
            GlobalStaticVars.GameStart = true;
            SceneManager.LoadScene(1);
        }
    }

    public void SetLevel(int level)
    {
        GlobalStaticVars.level = level;
    }
}
