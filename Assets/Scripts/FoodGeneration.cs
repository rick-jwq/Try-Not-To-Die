using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGeneration : MonoBehaviour
{
    public GameObject foodPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FoodCreat",0.1f,2f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FoodCreat()
    {
            float x = Random.Range (5,30);
            float y =0;
            float z =Random.Range (2,7);
            GameObject Food = Instantiate(foodPrefab);
            Food.transform.position = new Vector3(x, y, z);
    }
}
