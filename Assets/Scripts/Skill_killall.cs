﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skill_killall : Skill
{
    //private CharacterControll cc;
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
            cc.usedSkill3 += 1;

            GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

            int i;
            for (i = 0; i < enemys.Length; i++)
            {
                enemys[i].GetComponent<Enemy>().DestroySelf();
            }
        }
    }
    private void Update()
    {
        base.onUpdate();
    }
}