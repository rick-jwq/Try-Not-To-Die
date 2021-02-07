using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    public float knockOutForce = 20f;
    private float hp = 100f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0f)
        {
            rb.AddForce(transform.forward * knockOutForce);
            Destroy(gameObject, 2f);
        }
    }

    private void OnMouseDown()
    {
        hp -= 10f;
    }

    public float getHP()
    {
        return hp;
    }
}
