using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodWaterGenerator : MonoBehaviour
{
    public GameObject Food;
    public GameObject Water;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(obj);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        int flag = Random.Range(1,100);
        if (flag > 98)
        {
            Instantiate(Food);
        }
        if (flag < 3)
        {
            Instantiate(Water);
        }
    }
}
