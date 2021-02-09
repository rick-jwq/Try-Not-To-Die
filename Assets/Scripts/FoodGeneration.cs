using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGeneration : MonoBehaviour
{
    public float ChanceToSpawn = 0.4f;
    public GameObject foodPrefab;
    public float ChanceToSpawnFood = 0.5f;
    public GameObject waterPrefab;
    public float ChanceToSpawnWater = 0.3f;
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FoodCreat",2f,5f);
    }

    void FoodCreat()
    {
        if(Random.Range(0f,1f) > 1f - ChanceToSpawn)
        {
            float x = Random.Range(15, 30);
            float y = 1;
            float z = Random.Range(2, 7);

            float roll = Random.Range(0f, 1f);
            if (roll > 1f - ChanceToSpawnFood)
            {
                GameObject food = Instantiate(foodPrefab, new Vector3(x, y, z), Quaternion.identity);
                Destroy(food, 10f);
            }
            else if (roll > 1f - ChanceToSpawnFood - ChanceToSpawnWater)
            {
                GameObject water = Instantiate(waterPrefab, new Vector3(x, y, z), Quaternion.identity);
                Destroy(water, 10f);
            }
            else
            {
                GameObject enemy = Instantiate(enemyPrefab, new Vector3(x, y, 5), Quaternion.identity);
                Destroy(enemy, 10f);
            }
        }
    }
}
