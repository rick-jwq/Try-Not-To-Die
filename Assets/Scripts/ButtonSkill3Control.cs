using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSkill3Control : MonoBehaviour
{
    public CharacterControll cc;
    public int skillNum = 3;
    private int YinConsume = 3;
    private int YangConsume = 3;

    public bool isVisible = false;

    void update()
    {
/*        if (cc.skills.Contains(skillNum))
        {
            isVisible = true;
        }*/
    }

    public void UseSkill3()
    {
        if (!isVisible) return;

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