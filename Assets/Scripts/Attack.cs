using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Attack : MonoBehaviour
{
    public Enemy target;

    public GameObject[] Enemyarry;
    void Update()
    {
        //Enemyarry is an array with all exsiting enemy on map.
        Enemyarry = GameObject.FindGameObjectsWithTag("Enemy");
        if(Enemyarry.Length > 0)
        {
            target = Enemyarry[0].GetComponent<Enemy>();
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

    void attackUp()
    {
        // if the enemy array is not empty or its first int is equal to our attack direction
        if ((target.arrayOfInts.Count > 0) && (target.arrayOfInts[0] == 1))
        {
            target.arrayOfInts.RemoveAt(0);
            target.TakeDamage();
        }


    }
    void attackDown()
    {
        if ((target.arrayOfInts.Count > 0) && (target.arrayOfInts[0] == 2))
        {
            target.arrayOfInts.RemoveAt(0);
            target.TakeDamage();
        }
    }
    void attackRight()
    {
        if ((target.arrayOfInts.Count > 0) && (target.arrayOfInts[0] == 3))
        {
            target.arrayOfInts.RemoveAt(0);
            target.TakeDamage();
        }
    }

    void attackLeft()
    {
        if ((target.arrayOfInts.Count > 0) && (target.arrayOfInts[0] == 4))
        {
            target.arrayOfInts.RemoveAt(0);
            target.TakeDamage();
        }
    }


}