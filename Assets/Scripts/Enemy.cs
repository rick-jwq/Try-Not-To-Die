using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    public float knockOutForce = 20f;
    public float movingSpeed = 3f;

    //one move kills one hp
    [SerializeField] float hp = 4f;
    [SerializeField] float damageAmount = 1f;

    //array contains all the attack moves player have to make
    public List<int> arrayOfInts;



    public int level;

    private CharacterControll cc;

    public GameObject EnemyBar;
    private GameObject canvas;
    public bool isTracked = false;

    private GameObject barInstance;

    void Start()
    {
        arrayOfInts = new List<int>();
        cc = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControll>();
        GenerateMoves();

        canvas = GameObject.FindGameObjectWithTag("Canvas");
        barInstance = Instantiate(EnemyBar);
        barInstance.transform.SetParent(canvas.transform,false);
        barInstance.GetComponent<EnemyHPBar>().Track(gameObject);
        barInstance.GetComponent<EnemyHPBar>().UpdateArrows();
    }

    // Update is called once per frame
    void Update()
    {
        //keep enemy moving left.
        transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * movingSpeed);
        if (hp <= 0f)
        {
            Destroy(gameObject);
            Destroy(barInstance.gameObject);
        }

    }

    public void TakeDamage()
    {
        hp = hp - damageAmount;
        barInstance.GetComponent<EnemyHPBar>().UpdateArrows();
    }

    // method to generate moves. 
    //1:up
    //2:down
    //3:left
    //4:right
    private void GenerateMoves()
    {

        for (int i = 0; i < hp; i++)
        {
            arrayOfInts.Add(Random.Range(1, 5));
        }
    }




    private void OnMouseDown()
    {
        hp -= 1f;
    }

    public float getHP()
    {
        return hp;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            cc.ChangeHealth(-20);
            Destroy(gameObject);
            Destroy(barInstance.gameObject);
        }
    }
}
