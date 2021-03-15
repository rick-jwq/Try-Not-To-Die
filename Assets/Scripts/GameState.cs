using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class GameState : MonoBehaviour
{
    public CharacterControll cc;
    public static GameState instance;

    public GameObject Tutorial;
    public GameObject GameWinScreen;
    public GameObject GameEndScreen;

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

    public void analysis(int state)
    {
        AnalyticsResult Attributes = Analytics.CustomEvent(
            "Attributes",
                new Dictionary<string, object>{
                    {"playerAttack", GlobalStaticVars.playerAttack},
                    {"playerHP", GlobalStaticVars.playerHP},
                    {"playerPoints", GlobalStaticVars.playerPoints},
                }
                );
        Debug.Log("analyticsResult1:" + Attributes);
        Debug.Log("playerAttack:" + GlobalStaticVars.playerAttack);
        Debug.Log("playerHP:" + GlobalStaticVars.playerHP);
        Debug.Log("playerPoints:" + GlobalStaticVars.playerPoints);

        Debug.Log("level:" + GlobalStaticVars.level);

        Debug.Log("killedYang:" + cc.killedYang);
        Debug.Log("killedYin:" + cc.killedYin);

        Debug.Log("damageYang:" + cc.damageYang);
        Debug.Log("damageYin:" + cc.damageYin);

        Debug.Log("attackTotal:" + cc.attackTotal);
        Debug.Log("attackCorrect:" + cc.attackCorrect);

        Debug.Log("usedYin:" + cc.usedYin);
        Debug.Log("usedYang:" + cc.usedYang);

        Debug.Log("LevelTime:" + GlobalStaticVars.LevelTime);

        Debug.Log("usedSkill1:" + cc.usedSkill1);
        Debug.Log("usedSkill2:" + cc.usedSkill2);
        Debug.Log("usedSkill3:" + cc.usedSkill3);

        if(GlobalStaticVars.level == 1)
        {
            AnalyticsResult level1Monster = Analytics.CustomEvent(
                "level1Monster",
                    new Dictionary<string, object>{
                        {"killedYin", cc.killedYin},
                        {"killedYang", cc.killedYang},
                        {"damageYin", cc.damageYin},
                        {"damageYang", cc.damageYang},
                        {"attackTotal", cc.attackTotal},
                        {"attackCorrect", cc.attackCorrect},
                    }
                    );
            Debug.Log("analyticsResult2:" + level1Monster);
        }
        if(GlobalStaticVars.level == 2)
        {
            AnalyticsResult level2Monster = Analytics.CustomEvent(
                "level2Monster",
                    new Dictionary<string, object>{
                        {"killedYin", cc.killedYin},
                        {"killedYang", cc.killedYang},
                        {"damageYin", cc.damageYin},
                        {"damageYang", cc.damageYang},
                        {"attackTotal", cc.attackTotal},
                        {"attackCorrect", cc.attackCorrect},
                    }
                    );
            Debug.Log("analyticsResult2:" + level2Monster);
        }
        if(GlobalStaticVars.level == 3)
        {
            AnalyticsResult level3Monster = Analytics.CustomEvent(
                "level3Monster",
                    new Dictionary<string, object>{
                        {"killedYin", cc.killedYin},
                        {"killedYang", cc.killedYang},
                        {"damageYin", cc.damageYin},
                        {"damageYang", cc.damageYang},
                        {"attackTotal", cc.attackTotal},
                        {"attackCorrect", cc.attackCorrect},
                    }
                    );
            Debug.Log("analyticsResult2:" + level3Monster);
        }


        if(GlobalStaticVars.level == 1)
        {
            AnalyticsResult level1 = Analytics.CustomEvent(
                "level1",
                    new Dictionary<string, object>{
                        {"isPass", state},
                        {"usedYin", cc.usedYin},
                        {"usedYang", cc.usedYang},
                        {"usedSkill1", cc.usedSkill1},
                        {"usedSkill2", cc.usedSkill2},
                        {"usedSkill3", cc.usedSkill3}, 
                        {"LevelTime", GlobalStaticVars.LevelTime}, 
                    }
                    );
            Debug.Log("analyticsResult2:" + level1);
        }
        if(GlobalStaticVars.level == 2)
        {
            AnalyticsResult level2 = Analytics.CustomEvent(
                "level2",
                    new Dictionary<string, object>{
                        {"isPass", state},
                        {"usedYin", cc.usedYin},
                        {"usedYang", cc.usedYang},
                        {"usedSkill1", cc.usedSkill1},
                        {"usedSkill2", cc.usedSkill2},
                        {"usedSkill3", cc.usedSkill3}, 
                        {"LevelTime", GlobalStaticVars.LevelTime}, 
                    }
                    );
            Debug.Log("analyticsResult2:" + level2);
        }
        if(GlobalStaticVars.level == 3)
        {
            AnalyticsResult level3 = Analytics.CustomEvent(
                "level3",
                    new Dictionary<string, object>{
                        {"isPass", state},
                        {"usedYin", cc.usedYin},
                        {"usedYang", cc.usedYang},
                        {"usedSkill1", cc.usedSkill1},
                        {"usedSkill2", cc.usedSkill2},
                        {"usedSkill3", cc.usedSkill3}, 
                        {"LevelTime", GlobalStaticVars.LevelTime}, 
                    }
                    );
            Debug.Log("analyticsResult2:" + level3);
        }
    }


    public void Win()
    {
        Time.timeScale = 0;
        GameWinScreen.SetActive(true); 
        GlobalStaticVars.GameStart = false;
        analysis(1);


    }

    public void Lose()
    {
        Time.timeScale = 0;
        GameEndScreen.SetActive(true); 
        GlobalStaticVars.GameStart = false;
        analysis(0);
    }
}
