using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float ChanceToSpawn = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("EnemyCreate", 2f, 5f);
    }

    void EnemyCreate()
    {
        if (Random.Range(0f, 1f) > 1f - ChanceToSpawn)
        {
            float x = Random.Range(15, 30);
            float y = 1;
            float z = Random.Range(2, 7);

            GameObject enemy = Instantiate(enemyPrefab, new Vector3(x, y, z), Quaternion.identity);
            Destroy(enemy, 10f);
        }
    }
}
