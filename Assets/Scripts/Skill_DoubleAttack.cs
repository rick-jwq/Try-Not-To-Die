using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skill_DoubleAttack : Skill
{
    private CharacterControll cc;

    private bool isInEffect = false;
    private float effectTimer = 5f;
    private bool hasUpgraded = false;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            cc = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControll>();
        }
    }
    public override void Cast()
    {
        if (cc.storedYin >= Yincost && cc.storedYang >= Yangcost)
        {
            cc.ChangeStoredYin(-Yincost);
            cc.ChangeStoredYang(-Yangcost);
            isInEffect = true;
            cc.usedSkill6 += 1;

            if (!hasUpgraded)
            {
                cc.upgradeAttack(cc.attack);
                hasUpgraded = true;
            }
        }
    }

    private void Update()
    {
        if (isInEffect)
        {
            effectTimer -= Time.deltaTime;

            //Effect


            if (effectTimer <= 0)
            {
                effectTimer = 5f;
                isInEffect = false;
                hasUpgraded = false;

                cc.upgradeAttack(-cc.attack / 2);
            }
        }
    }
}
