using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public float speed = 3.0f;
    // Start is called before the first frame update
    void Awake()
    {
        transform.position = new Vector3(8,Random.Range(-100,100) * 0.01f,-2);
        speed = Random.Range(100,300) * 0.03f;
    }
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        Vector3 position = transform.position;
        position.x=position.x - speed * Time.deltaTime;
        transform.position=position;
        if (position.x < -8)
        {
            Destroy(gameObject);
        }
    }
    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject);
        }
    }
}
