using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGround : MonoBehaviour
{
    // Start is called before the first frame update
    public float movingSpeed = 5f;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-1,0,0) * Time.deltaTime * movingSpeed);
    }
}
