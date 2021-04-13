using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float movingSpeed = 2f;

    public int reward = 0;
    public List<int> arrayOfInts;

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
        barInstance = Instantiate(EnemyBar, new Vector3(1000, 1000, 1000), Quaternion.identity);
        barInstance.transform.SetParent(canvas.transform, false);
        barInstance.GetComponent<RewardEnemyBar>().Track(gameObject);
        barInstance.GetComponent<RewardEnemyBar>().UpdateArrows();
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
        arrayOfInts.Add(Random.Range(1, 5));
        barInstance.GetComponent<RewardEnemyBar>().UpdateArrows();
        reward += 1;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            DestroySelf();
            cc.rewardPoints(reward);
            EnemyGeneration.instance.isGenerating = true;
        }
    }

    public void DestroySelf()
    {
        gameObject.GetComponent<Animator>().SetBool("Die", true);
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.tag = "Untagged";
        Destroy(gameObject, 1f);
        Destroy(barInstance.gameObject, 1f);
    }

    private void GenerateMoves()
    {

        for (int i = 0; i < 3; i++)
        {
            arrayOfInts.Add(Random.Range(1, 5));
        }
    }

    public float getHP()
    {
        return 99999;
    }


    public float getHPpercent()
    {
        return 1;
    }

}
