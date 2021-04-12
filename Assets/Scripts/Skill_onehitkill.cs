using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skill_onehitkill : Skill
{
    //private CharacterControll cc;

    private bool isInEffect = false;
    private float effectTimer = 5f;
    private bool hasUpgraded = false;

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
            isInEffect = true;

            if(!hasUpgraded)
            {
                cc.upgradeAttack(999);
                hasUpgraded = true;
            }

            cc.usedSkill2 += 1;
        }
    }

    private void Update()
    {
        base.onUpdate();
        if (isInEffect)
        {
            effectTimer -= Time.deltaTime;

            //Effect

            if (effectTimer <= 0)
            {
                effectTimer = 5f;
                isInEffect = false;
                hasUpgraded = false;

                cc.upgradeAttack(-999);
            }
        }
    }
}
