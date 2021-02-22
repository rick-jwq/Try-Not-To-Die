using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSkill3Control : MonoBehaviour
{
    public CharacterControll cc;

    private int YinConsume = 3;
    private int YangConsume = 3;

    public void UseSkill3()
    {
        if (cc.storedYin >= YinConsume && cc.storedYang >= YangConsume)
        {
            cc.ChangeStoredYin(-YinConsume);
            cc.ChangeStoredYang(-YangConsume);

            GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

            int i;
            for (i = 0; i < enemys.Length; i++)
            {
                enemys[i].GetComponent<Enemy>().DestroySelf();
            }
        }
    }
}