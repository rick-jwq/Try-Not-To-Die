using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Attack : MonoBehaviour
{
  public Enemy target;
  public RewardEnemy rewardTarget;

  public GameObject[] Enemyarry;

  private CharacterControll cc;

  private float penalty_timer = 1f;
  private bool allowAttack = true;

  private Animator animator;
  private bool punchleft = false;

  public GameObject beam;
  public GameObject wrongBeam;

  public static Attack instance;

  private void Start()
  {
    instance = this;
    cc = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControll>();
    animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
  }
  void Update()
  {
    if (!allowAttack)
    {
      penalty_timer -= Time.deltaTime;
      if (penalty_timer <= 0f)
      {
        allowAttack = true;
        penalty_timer = 1f;
      }
    }

    if (GlobalStaticVars.GameStart && allowAttack)
    {
      //Enemyarry is an array with all exsiting enemy on map.
      Enemyarry = GameObject.FindGameObjectsWithTag("Enemy");

      if (Enemyarry.Length > 0)
      {
        target = Enemyarry[0].GetComponent<Enemy>();
        if (!target)
        {
          rewardTarget = Enemyarry[0].GetComponent<RewardEnemy>();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
          if (punchleft)
          {
            animator.SetTrigger("punch");
            punchleft = !punchleft;
          }
          else
          {
            animator.SetTrigger("punch1");
            punchleft = !punchleft;
          }
          attack(1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
          if (punchleft)
          {
            animator.SetTrigger("punch");
            punchleft = !punchleft;
          }
          else
          {
            animator.SetTrigger("punch1");
            punchleft = !punchleft;
          }
          attack(4);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
          if (punchleft)
          {
            animator.SetTrigger("punch");
            punchleft = !punchleft;
          }
          else
          {
            animator.SetTrigger("punch1");
            punchleft = !punchleft;
          }
          attack(2);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
          if (punchleft)
          {
            animator.SetTrigger("punch");
            punchleft = !punchleft;
          }
          else
          {
            animator.SetTrigger("punch1");
            punchleft = !punchleft;
          }
          attack(3);
        }
      }
    }

  }

  void attack(int way)
  {
    // if the enemy array is not empty or its first int is equal to our attack direction
    if (target && (target.arrayOfInts.Count > 0))
    {
      if (target.isReverse? target.arrayOfInts[0] == 5 - way : target.arrayOfInts[0] == way)
      {
        Instantiate(beam, new Vector3(0.1f, 1, 5), Quaternion.identity);
        target.arrayOfInts.RemoveAt(0);
        target.TakeDamage(cc.attack);
        cc.attackTotal += 1;
        cc.attackCorrect += 1;
      }
      else
      {
        if (GlobalStaticVars.inTutorial) return;
        Instantiate(wrongBeam, new Vector3(0.1f, 1, 5), Quaternion.identity);
        allowAttack = false;
      }
    }
    else if (rewardTarget && (rewardTarget.arrayOfInts.Count > 0))
    {
      if (rewardTarget.arrayOfInts[0] == way)
      {
        Instantiate(beam, new Vector3(0.1f, 1, 5), Quaternion.identity);
        rewardTarget.arrayOfInts.RemoveAt(0);
        rewardTarget.TakeDamage(cc.attack);
        cc.attackTotal += 1;
        cc.attackCorrect += 1;
      }
      else
      {
        if (GlobalStaticVars.inTutorial) return;
        Instantiate(wrongBeam, new Vector3(0.1f, 1, 5), Quaternion.identity);
        allowAttack = false;
      }
    }
    else
    {
      cc.attackTotal += 1;
    }
  }
}