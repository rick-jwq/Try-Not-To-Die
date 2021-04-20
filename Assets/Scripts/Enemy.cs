using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Enemy : MonoBehaviour
{
  // Start is called before the first frame update
  public float movingSpeed = 2f;
  public bool isYin = false;
  public bool isReverse = false;
  public bool isFlashy = false;

  //one move kills one hp
    public float max_hp { get; set; }
  public float hp { get; set; } = 4f;

  //array contains all the attack moves player have to make
  public List<int> arrayOfInts;



  public int level;

  private CharacterControll cc;

  public GameObject EnemyBar;
  private GameObject canvas;
  public bool isTracked = false;

  private GameObject barInstance;

  private AudioSource audiosource;
  private GameObject EnemyTutorial;
  private GameObject ReverseEnemyTutorial;
  private GameObject FlashyEnemyTutorial;
  private GameObject YYBarTutorial;

  private float flashyTimer = 0f;

  void Start()
  {
    arrayOfInts = new List<int>();
    cc = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControll>();
    EnemyTutorial = GameObject.FindGameObjectWithTag("Canvas").transform.Find("EnemyTutorial").gameObject;
    ReverseEnemyTutorial = GameObject.FindGameObjectWithTag("Canvas").transform.Find("ReverseEnemyTutorial").gameObject;
    FlashyEnemyTutorial = GameObject.FindGameObjectWithTag("Canvas").transform.Find("FlashyEnemyTutorial").gameObject;
    YYBarTutorial = GameObject.FindGameObjectWithTag("Canvas").transform.Find("YinYangBarTutorial").gameObject;
    GenerateMoves();

    canvas = GameObject.FindGameObjectWithTag("Canvas");
    barInstance = Instantiate(EnemyBar, new Vector3(1000, 1000, 1000), Quaternion.identity);
    barInstance.transform.SetParent(canvas.transform, false);
    barInstance.transform.SetAsFirstSibling();
    barInstance.GetComponent<EnemyHPBar>().Track(gameObject);
    barInstance.GetComponent<EnemyHPBar>().UpdateArrows();

    audiosource = GetComponent<AudioSource>();

    if(isReverse)
    {
      transform.Find("ReverseCircle").gameObject.SetActive(true);
    }
    if (isFlashy)
    {
      transform.Find("FlashyCircle").gameObject.SetActive(true);
    }
  }

  // Update is called once per frame
  void Update()
  {
    //keep enemy moving left.
    transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * movingSpeed);
    Vector3 position = transform.position;
    if (!GlobalStaticVars.hasViewedEnemyTutorial && !GlobalStaticVars.skipTutorial && position.x < 16.5)
    {
      Time.timeScale = 0;
      EnemyTutorial.SetActive(true);
      GlobalStaticVars.inTutorial = true;
      GlobalStaticVars.hasViewedEnemyTutorial = true;
    }



    if(isFlashy)
    {
      flashyTimer += Time.unscaledDeltaTime;

      if(flashyTimer >= 0.8f)
      {
        arrayOfInts.RemoveAt(0);
        arrayOfInts.Add(Random.Range(1, 5));
        if(barInstance)
          barInstance.GetComponent<EnemyHPBar>().UpdateArrows();
        flashyTimer = 0f;
      }
    }

    if (isReverse && !GlobalStaticVars.hasViewedReverseEnemyTutorial && !GlobalStaticVars.skipTutorial && position.x < 16.5)
    {
      Time.timeScale = 0;
      ReverseEnemyTutorial.SetActive(true);
      GlobalStaticVars.inTutorial = true;
      GlobalStaticVars.hasViewedReverseEnemyTutorial = true;
    }
    else if (isFlashy && !GlobalStaticVars.hasViewedFlashyEnemyTutorial && !GlobalStaticVars.skipTutorial && position.x < 16.5)
    {
      Time.timeScale = 0;
      FlashyEnemyTutorial.SetActive(true);
      GlobalStaticVars.inTutorial = true;
      GlobalStaticVars.hasViewedFlashyEnemyTutorial = true;
    }

  }

  public void TakeDamage(float attackDamage)
  {
    audiosource.Play();
    hp = hp - attackDamage;
    arrayOfInts.Add(Random.Range(1, 5));
    barInstance.GetComponent<EnemyHPBar>().UpdateArrows();

    if (hp <= 0f)
    {
      cc.ChangeYinYang(isYin, 10);

      cc.rewardPoints(1);
      if (isYin == false)
      { cc.killedYang += 1; }
      else
      { cc.killedYin += 1; }
      if (!GlobalStaticVars.hasViewedYYBarTutorial && !GlobalStaticVars.skipTutorial)
      {
        EnemyTutorial.SetActive(false);
        Time.timeScale = 0;
        GlobalStaticVars.inTutorial = true;
        YYBarTutorial.SetActive(true);
        GlobalStaticVars.hasViewedYYBarTutorial = true;
      }
        DestroySelf();
    }
  }

  // method to generate moves. 
  //1:up
  //2:left
  //3:right
  //4:down
  private void GenerateMoves()
  {

    for (int i = 0; i < 4; i++)
    {
      arrayOfInts.Add(Random.Range(1, 5));
    }
  }

  public float getHP()
  {
    return hp;
  }

  public float getHPpercent()
  {
    return hp / max_hp;
  }

  public void setHP(float newHp)
  {
    max_hp = newHp;
    hp = max_hp;
  }

  public float getMS()
  {
    return movingSpeed;
  }

  public void setMS(float newMS)
  {
    movingSpeed = newMS;
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Player")
    {
      cc.ChangeHealth(-20);
      if (isYin == false)
      { cc.damageYang += 1; }
      else
      { cc.damageYin += 1; }

      DestroySelf();
    }
  }

  public void DestroySelf()
  {
    gameObject.GetComponent<Animator>().SetBool("Die", true);
    gameObject.GetComponent<BoxCollider>().enabled = false;
    gameObject.tag = "Untagged";
    Destroy(gameObject, 1f);
    Destroy(barInstance.gameObject);
  }
}
