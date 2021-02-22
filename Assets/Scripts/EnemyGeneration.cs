using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    public GameObject YinEnemy;
    public GameObject YangEnemy;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("EnemyCreate", 2f, 2f);
    }

    void EnemyCreate()
    {
        if (Random.Range(0f, 1f) > 0.5f)
        {
            GameObject enemy = Instantiate(YinEnemy, new Vector3(25, 1, 5), Quaternion.identity);
            Destroy(enemy, 10f);
        }
        else
        {
            GameObject enemy = Instantiate(YangEnemy, new Vector3(25, 1, 5), Quaternion.identity);
            Destroy(enemy, 10f);
        }
    }
}
