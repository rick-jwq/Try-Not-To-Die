using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_slow : Skill
{
    private CharacterControll cc;
    private EnemyGeneration eg;

    private float slowspeed=1f;


    public GameObject[] enemys;
    private float slowTimer = 5f;
    private bool isSlowing = false;

    private void Start()
    {
        cc = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControll>();
        eg = GameObject.FindGameObjectWithTag("GlobalControl").GetComponent<EnemyGeneration>();
    }
    public override void Cast()
    {
        if (cc.storedYin>=Yincost && cc.storedYang>=Yangcost)
        {
            cc.ChangeStoredYin(-Yincost);
            cc.ChangeStoredYang(-Yangcost);
            isSlowing = true;
            cc.usedSkill1 += 1;
        }
    }

    private void Update()
    {
        if(isSlowing)
        {
            slowTimer -= Time.deltaTime;

            //Effect
            enemys = GameObject.FindGameObjectsWithTag("Enemy");

            int i;
            for(i = 0; i < enemys.Length; i++)
            {
                Enemy enemyScript = enemys[i].GetComponent<Enemy>();
                if(enemyScript)
                {
                    enemyScript.movingSpeed = slowspeed;
                }

            }

            if(slowTimer <= 0)
            {
                slowTimer = 5f;
                isSlowing = false;

                enemys = GameObject.FindGameObjectsWithTag("Enemy");

                for (i = 0; i < enemys.Length; i++)
                {
                    enemys[i].GetComponent<Enemy>().movingSpeed = eg.getCurMS();
                }
            }
        }
    }
}
