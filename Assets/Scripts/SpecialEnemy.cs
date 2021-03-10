using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float movingSpeed = 2f;

    // addon is the addon for players. 
    public int addon = 0;
    public List<int> arrayOfInts;

    private CharacterControll cc;
    void Start()
    {
        arrayOfInts = new List<int>();
        cc = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControll>();
        GenerateMoves();
    }

    // Update is called once per frame
    void Update()
    {
        //keep moving left
        transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * movingSpeed);
    }

    //take tamage
    public void TakeDamage(float attackDamage)
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            DestroySelf();
        }
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
        //This is the place we add 
    }

    private void GenerateMoves()
    {

        for (int i = 0; i < 300; i++)
        {
            arrayOfInts.Add(Random.Range(1, 5));
        }
    }
}
