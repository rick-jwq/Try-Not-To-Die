using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStill1Control : MonoBehaviour
{
    public CharacterControll cc;
    public EnemyGeneration eg;

    private int YinConsume=3;
    private int YangConsume=0;
    private float slowspeed=1f;


    public GameObject[] enemys;
    private float slowTimer = 5f;
    private bool isSlowing = false;
    public void UseStill1()
    {
        if (cc.storedYin>=YinConsume && cc.storedYang>=YangConsume)
        {
            cc.ChangeStoredYin(-YinConsume);
            cc.ChangeStoredYang(-YangConsume);
            isSlowing = true;
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
                enemys[i].GetComponent<Enemy>().movingSpeed = slowspeed;
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
