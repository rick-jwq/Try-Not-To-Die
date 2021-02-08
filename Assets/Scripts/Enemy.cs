using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    public float knockOutForce = 20f;
    public float movingSpeed = 3f;
    private float hp = 100f;
    private Rigidbody rb;

    private CharacterControll cc;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cc = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControll>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * movingSpeed);

        if (hp <= 0f)
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            cc.ChangeHealth(-20);
            Destroy(gameObject, 1f);
        }
    }
}
