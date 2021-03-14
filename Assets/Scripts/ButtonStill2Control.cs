using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStill2Control : MonoBehaviour
{
    public CharacterControll cc;
    private int YinConsume=0;
    private int YangConsume=3;

    private bool isInEffect = false;
    private float effectTimer = 5f;
    public void UseStill2()
    {
        if (cc.storedYin >= YinConsume && cc.storedYang >= YangConsume)
        {
            cc.ChangeStoredYin(-YinConsume);
            cc.ChangeStoredYang(-YangConsume);
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
