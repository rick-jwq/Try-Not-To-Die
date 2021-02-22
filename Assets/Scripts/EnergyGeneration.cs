using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyGeneration : MonoBehaviour
{
    public float ChanceToSpawn = 0.4f;
    public GameObject yinPrefab;
    public GameObject yangPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("EnergySpawn",2f,4f);
    }

    void EnergySpawn()
    {
        if(Random.Range(0f,1f) > 1f - ChanceToSpawn)
        {
            float x = Random.Range(1, 15);
            float y = 1;
            float z = Random.Range(2, 7);

            if (Random.Range(0f, 1f) > 0.5f)
            {
                GameObject energy = Instantiate(yinPrefab, new Vector3(x, y, z), Quaternion.identity);
                Destroy(energy, 10f);
            }
            else
            {
                GameObject energy = Instantiate(yangPrefab, new Vector3(x, y, z), Quaternion.identity);
                Destroy(energy, 10f);
            }
        }
    }
}
