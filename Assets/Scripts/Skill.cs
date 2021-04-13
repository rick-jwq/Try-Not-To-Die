using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Skill : MonoBehaviour
{
    // Start is called before the first frame update
    public int level = 1;
    public string skill_name;
    public int Yincost;
    public int Yangcost;
    protected CharacterControll cc;
    protected GameObject Tutorial;

    public virtual void Cast()
    {

    }
    protected void onStart()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            cc = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControll>();
            Tutorial = GameObject.FindGameObjectWithTag("Canvas").transform.Find("SkillTutorial").gameObject;
        }
    }
    protected void onUpdate()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 && !GlobalStaticVars.hasViewedSkillTutorial && !GlobalStaticVars.skipTutorial && cc.storedYin >= Yincost && cc.storedYang >= Yangcost)
        {
            Time.timeScale = 0;
            Tutorial.SetActive(true);
            GlobalStaticVars.inTutorial = true;
            GlobalStaticVars.hasViewedSkillTutorial=true;
        }
    }
}
