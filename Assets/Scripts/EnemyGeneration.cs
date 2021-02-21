using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("EnemyCreate", 2f, 2f);
    }

    void EnemyCreate()
    {
        GameObject enemy = Instantiate(enemyPrefab, new Vector3(20, 1, 5), Quaternion.identity);
        Destroy(enemy, 10f);
    }
}
