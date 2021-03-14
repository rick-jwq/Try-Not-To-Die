using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelLoader : MonoBehaviour
{

    public void LoadLevel(int level_number)
    {

        if(level_number == 1)
        {
            GlobalStaticVars.level = 1;
            GlobalStaticVars.enemyHP = 3f;
            GlobalStaticVars.enemyMS = 2f;
            GlobalStaticVars.LevelTime = 0;
            GlobalStaticVars.GameStart = true;
            SceneManager.LoadScene(1);       
        }
        if (level_number == 2)
        {
            GlobalStaticVars.level = 2;
            GlobalStaticVars.enemyHP = 5f;
            GlobalStaticVars.enemyMS = 2.5f;
            GlobalStaticVars.LevelTime = 0;
            GlobalStaticVars.GameStart = true;
            SceneManager.LoadScene(1);
        }
        if (level_number == 3)
        {
            GlobalStaticVars.level = 3;
            GlobalStaticVars.enemyHP = 10f;
            GlobalStaticVars.enemyMS = 3f;
            GlobalStaticVars.LevelTime = 0;
            GlobalStaticVars.GameStart = true;
            SceneManager.LoadScene(1);
        }
    }
}
