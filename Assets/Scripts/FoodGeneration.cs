using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGeneration : MonoBehaviour
{
    public GameObject foodPrefab;
    public GameObject waterPrefab;
    public float ChanceToSpawn = 0.4f;
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

            if(Random.Range(0f, 1f) > 0.5f)
            {
                GameObject food = Instantiate(foodPrefab, new Vector3(x, y, z), Quaternion.identity);
                Destroy(food, 10f);
            }
            else
            {
                GameObject water = Instantiate(waterPrefab, new Vector3(x, y, z), Quaternion.identity);
                Destroy(water, 10f);
            }
        }
    }
}
