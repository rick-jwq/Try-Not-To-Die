using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public float speed = 5f;

    private CharacterControll cc;
    // Start is called before the first frame update
    void Awake()
    {
        transform.position = new Vector3(Random.Range(15, 30),1, Random.Range(2, 7));
    }
    void Start()
    {
        cc = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControll>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.x = position.x - speed * Time.deltaTime;
        transform.position = position;
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
            cc.ChangeHunger(10);
        }
    }
}
