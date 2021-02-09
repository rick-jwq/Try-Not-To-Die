using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public float speed = 5f;
    // Start is called before the first frame update

    private CharacterControll cc;
    void Awake()
    {
        transform.position = new Vector3(Random.Range(15, 30), 1, Random.Range(2, 7));
    }
    void Start()
    {
        cc = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControll>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * speed);
        if (transform.position.x < -8)
        {
            Destroy(gameObject);
        }
    }
    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Destroy(gameObject);
            cc.ChangeThirst(20);
        }
    }
}
