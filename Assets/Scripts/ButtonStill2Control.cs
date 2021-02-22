using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStill2Control : MonoBehaviour
{
    public CharacterControll cc;
    public Attack attack;
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
        }
    }

    private void Update()
    {
        if (isInEffect)
        {
            effectTimer -= Time.deltaTime;

            //Effect
            attack.attackDamage = 4f;

            if (effectTimer <= 0)
            {
                effectTimer = 5f;
                isInEffect = false;

                attack.attackDamage = 1f;
            }
        }
    }
}
