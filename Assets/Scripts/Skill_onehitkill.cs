using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_onehitkill : Skill
{
    private CharacterControll cc;

    private bool isInEffect = false;
    private float effectTimer = 5f;

    private void Start()
    {
        cc = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControll>();
    }
    public override void Cast()
    {
        if (cc.storedYin >= Yincost && cc.storedYang >= Yangcost)
        {
            cc.ChangeStoredYin(-Yincost);
            cc.ChangeStoredYang(-Yangcost);
            isInEffect = true;
            cc.usedSkill2 += 1;
        }
    }

    private void Update()
    {
        if (isInEffect)
        {
            effectTimer -= Time.deltaTime;

            //Effect
            cc.upgradeAttack(99);

            if (effectTimer <= 0)
            {
                effectTimer = 5f;
                isInEffect = false;

                cc.upgradeAttack(-99);
            }
        }
    }
}
