using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Attack : MonoBehaviour
{
    public Enemy target;
    public RewardEnemy rewardTarget;

    public GameObject[] Enemyarry;

    public CharacterControll cc;

    private float penalty_timer = 1f;
    private bool allowAttack = true;
    void Update()
    {
        if(!allowAttack)
        {
            penalty_timer -= Time.deltaTime;
            if(penalty_timer <= 0f)
            {
                allowAttack = true;
                penalty_timer = 1f;
            }
        }

        if (GlobalStaticVars.GameStart && allowAttack){
        //Enemyarry is an array with all exsiting enemy on map.
        Enemyarry = GameObject.FindGameObjectsWithTag("Enemy"); 

        if(Enemyarry.Length > 0)
        {
            target = Enemyarry[0].GetComponent<Enemy>();
            if(!target)
            {
                rewardTarget = Enemyarry[0].GetComponent<RewardEnemy>();
            }


            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                attackUp();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                attackDown();
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                attackRight();
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                attackLeft();
            }
        }
        }

    }

    void attackUp()
    {
        // if the enemy array is not empty or its first int is equal to our attack direction
        if (target && (target.arrayOfInts.Count > 0))
        {
            if(target.arrayOfInts[0] == 1)
            {
                target.arrayOfInts.RemoveAt(0);
                target.TakeDamage(cc.attack);
                cc.attackTotal += 1;
                cc.attackCorrect += 1;
            }
            else
            {
                allowAttack = false;
            }
        }
        else if (rewardTarget && (rewardTarget.arrayOfInts.Count > 0))
        {
            if (rewardTarget.arrayOfInts[0] == 1)
            {
                rewardTarget.arrayOfInts.RemoveAt(0);
                rewardTarget.TakeDamage(cc.attack);
                cc.attackTotal += 1;
                cc.attackCorrect += 1;
            }
            else
            {
                allowAttack = false;
            }
        }
        else
        {
            cc.attackTotal += 1;
        }
    }
    void attackDown()
    {
        if (target && (target.arrayOfInts.Count > 0))
        {
            if (target.arrayOfInts[0] == 2)
            {
                target.arrayOfInts.RemoveAt(0);
                target.TakeDamage(cc.attack);
                cc.attackTotal += 1;
                cc.attackCorrect += 1;
            }
            else
            {
                allowAttack = false;
            }
        }
        else if (rewardTarget && (rewardTarget.arrayOfInts.Count > 0))
        {
            if (rewardTarget.arrayOfInts[0] == 2)
            {
                rewardTarget.arrayOfInts.RemoveAt(0);
                rewardTarget.TakeDamage(cc.attack);
                cc.attackTotal += 1;
                cc.attackCorrect += 1;
            }
            else
            {
                allowAttack = false;
            }
        }
        else
        {
            cc.attackTotal += 1;
        }
    }
    void attackRight()
    {
        if (target && (target.arrayOfInts.Count > 0))
        {
            if (target.arrayOfInts[0] == 3)
            {
                target.arrayOfInts.RemoveAt(0);
                target.TakeDamage(cc.attack);
                cc.attackTotal += 1;
                cc.attackCorrect += 1;
            }
            else
            {
                allowAttack = false;
            }
        }
        else if (rewardTarget && (rewardTarget.arrayOfInts.Count > 0))
        {
            if (rewardTarget.arrayOfInts[0] == 3)
            {
                rewardTarget.arrayOfInts.RemoveAt(0);
                rewardTarget.TakeDamage(cc.attack);
                cc.attackTotal += 1;
                cc.attackCorrect += 1;
            }
            else
            {
                allowAttack = false;
            }
        }
        else
        {
            cc.attackTotal += 1;
        }
    }

    void attackLeft()
    {
        if (target && (target.arrayOfInts.Count > 0))
        {
            if (target.arrayOfInts[0] == 4)
            {
                target.arrayOfInts.RemoveAt(0);
                target.TakeDamage(cc.attack);
                cc.attackTotal += 1;
                cc.attackCorrect += 1;
            }
            else
            {
                allowAttack = false;
            }
        }
        else if (rewardTarget && (rewardTarget.arrayOfInts.Count > 0))
        {
            if (rewardTarget.arrayOfInts[0] == 4)
            {
                rewardTarget.arrayOfInts.RemoveAt(0);
                rewardTarget.TakeDamage(cc.attack);
                cc.attackTotal += 1;
                cc.attackCorrect += 1;
            }
            else
            {
                allowAttack = false;
            }
        }
        else
        {
            cc.attackTotal += 1;
        }
    }


}