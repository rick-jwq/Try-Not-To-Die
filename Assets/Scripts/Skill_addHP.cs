using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skill_addHP : Skill
{
    //private CharacterControll cc;
    private float addHPvalue = 10;
    private void Start()
    {
        base.onStart();
        /*if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            cc = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControll>();
        }*/
    }
    public override void Cast()
    {
        if (cc.storedYin >= Yincost && cc.storedYang >= Yangcost)
        {
            cc.ChangeStoredYin(-Yincost);
            cc.ChangeStoredYang(-Yangcost);
            cc.usedSkill4 += 1;

            cc.ChangeHealth(addHPvalue);
        }
    }
    private void Update()
    {
        base.onUpdate();
    }
}