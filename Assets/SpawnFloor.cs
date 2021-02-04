using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFloor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Floor;
    public bool destroy = false;

    private void OnTriggerEnter(Collider other)
    {
        if(destroy)
        {
            Destroy(transform.parent.gameObject);
        }
        else
        {
            float new_x = transform.position.x + 20f;
            Instantiate(Floor, new Vector3(new_x, transform.position.y, transform.position.z), Quaternion.identity);
        }
    }
}
