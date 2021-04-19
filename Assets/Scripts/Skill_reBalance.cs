using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skill_reBalance : Skill
{
    private bool isInEffect = false;
    private float effectTimer = 5f;

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
            isInEffect = true;

            cc.usedSkill5 += 1;

            cc.reBalance();
        }
    }
    private void Update()
    {
        base.onUpdate();
        if (isInEffect)
        {
            effectTimer -= Time.deltaTime;
            cc.reBalance();
            //Effect

            if (effectTimer <= 0)
            {
                effectTimer = 5f;
                isInEffect = false;
            }
        }
    }
}
