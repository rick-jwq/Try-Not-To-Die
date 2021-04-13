using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    public CharacterControll cc;
    public GameObject YinEnemy;
    public GameObject YangEnemy;
    public GameObject RewardEnemy;
    public GameObject NeutralEnemy;
    public GameObject ReverseEnemy;

    public float diffChangeTime = 30f;
    public float startHP;
    public float startMS;
    public float startSpawnTime = 3f;
    public float HPincrement = 1f;
    public float MSincrement = 1f;
    public float spawnTimeDecrement = 0.5f;


    private float spawnTimer = 0f;
    private float yinSpawnChance;
    private float timer = 0f;
    private float curHP;
    private float curMS;
    private float curSpawnTime;

    public static EnemyGeneration instance;

    public int enemysGenerated { get; set; } = 0;

    public bool isGenerating { get; set; }

    public GameObject GameState;

    // Start is called before the first frame update
    void Start()
    {
        startHP = GlobalStaticVars.enemyHP;
        startMS = GlobalStaticVars.enemyMS;
        curHP = startHP;
        curMS = startMS;
        curSpawnTime = startSpawnTime;

        yinSpawnChance = cc.yin;

        isGenerating = true;

        instance = this;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        //if(timer >= diffChangeTime)
        //{
        //    timer = 0f;

        //    if(curHP < 5f)
        //    {
        //        curHP += HPincrement;
        //    }
        //    if(curMS < 5f)
        //    {
        //        curMS += MSincrement;
        //    }
        //    if(curSpawnTime > 1f)
        //    {
        //        curSpawnTime -= spawnTimeDecrement;
        //    }
        //    yinSpawnChance = cc.yin;
        //}

        spawnTimer += Time.deltaTime;
        if(spawnTimer >= curSpawnTime)
        {
            EnemyCreate();
            spawnTimer = 0f;
        }
    }

    void EnemyCreate()
    {
        if (!isGenerating) 
        {
            return;
        }
        float randomValue = Random.Range(0f, 1f);
        if (randomValue < 0.05f)
        {
            GameObject enemy = Instantiate(RewardEnemy, new Vector3(25, 1, 5), Quaternion.identity);
            isGenerating = false;
            return;
        }
        if (randomValue < 0.15f)
        {
            GameObject enemy = Instantiate(NeutralEnemy, new Vector3(25, 1, 5), Quaternion.identity);
            enemy.GetComponent<Enemy>().setHP(curHP);
            enemy.GetComponent<Enemy>().setMS(curMS);
            enemysGenerated++;
        }
        else if (randomValue < 0.30f || randomValue > 0.15f)
        {
            GameObject enemy = Instantiate(ReverseEnemy, new Vector3(25, 1, 5), Quaternion.identity);
            enemy.GetComponent<Enemy>().setHP(curHP);
            enemy.GetComponent<Enemy>().setMS(curMS);
            enemysGenerated++;
        }
        else if (Random.Range(0f, 100f) < yinSpawnChance)
        {
            GameObject enemy = Instantiate(YinEnemy, new Vector3(25, 1, 5), Quaternion.identity);
            enemy.GetComponent<Enemy>().setHP(curHP);
            enemy.GetComponent<Enemy>().setMS(curMS);
            enemysGenerated++;
        }
        else
        {
            GameObject enemy = Instantiate(YangEnemy, new Vector3(25, 1, 5), Quaternion.identity);
            enemy.GetComponent<Enemy>().setHP(curHP);
            enemy.GetComponent<Enemy>().setMS(curMS);
            enemysGenerated++;
        }
    }

    public float getCurMS()
    {
        return curMS;
    }
}
