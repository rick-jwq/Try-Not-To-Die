using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGeneration : MonoBehaviour
{
    public GameObject foodPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FoodCreat",2f,5f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FoodCreat()
    {
            float x = Random.Range (15,30);
            float y =1;
            float z =Random.Range (2,7);
            GameObject Food = Instantiate(foodPrefab);
            Food.transform.position = new Vector3(x, y, z);
    }
}
