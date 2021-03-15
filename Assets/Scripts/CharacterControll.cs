using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControll : MonoBehaviour
{
  public int maxHealth;
  public int maxYin = 100;
  public int maxYang = 100;
  public int initYin = 50;

  public int killedYin = 0;
  public int killedYang = 0;
  public int damageYin = 0;
  public int damageYang = 0;
  public float losingSpeed = -0.3f;
  public int attackTotal = 0;
  public int attackCorrect = 0;
  public int usedYin = 0;
  public int usedYang = 0;
  public int usedSkill1 = 0;
  public int usedSkill2 = 0;
  public int usedSkill3 = 0;
  public int usedSkill4 = 0;
  public int usedSkill5 = 0;
  public int usedSkill6 = 0;

    public GameObject SkillContainer;


    public Text YinText;
    public Text YangText;
    public GameObject UnbalanceText;

    public GameObject GameEndScreen;

  public float time = 0.1f;

  bool isDrainingHealth = false;

  public float currentHealth;
  public float health { get { return currentHealth; } }

  int currentYin;
  public int yin { get { return currentYin; } }

  int currentYang;
  public int yang { get { return currentYang; } }

  int currentStoredYin;
  public int storedYin { get { return currentStoredYin; } }
  int currentStoredYang;
  public int storedYang { get { return currentStoredYang; } }
  private Rigidbody rb;

  //int currentLevel;
  //public int level { get { return currentLevel; } }
  

  public int attack { get; set; }

  public int points { get; set; }

  //int scalingFactor;

    public void ChangeStoredYin(int amount)
  {
    currentStoredYin = currentStoredYin + amount;
        YinText.text = currentStoredYin.ToString();

  }
  public void ChangeStoredYang(int amount)
  {
    currentStoredYang = currentStoredYang + amount;
        YangText.text = currentStoredYang.ToString();
  }

  // Start is called before the first frame update
  void Start()
  {
    rb = GetComponent<Rigidbody>();

        maxHealth = GlobalStaticVars.playerHP;
        currentHealth = maxHealth;
        attack = GlobalStaticVars.playerAttack;

        points = GlobalStaticVars.playerPoints;

    currentStoredYin = 0;
    currentStoredYang = 0;

    currentYin = initYin;
    currentYang = maxYang - initYin;

        //currentLevel = 1;
        //scalingFactor = 1;

    foreach (GameObject skill in GlobalStaticVars.skills)
    {
            GameObject skillInstance = Instantiate(skill);

            skillInstance.transform.SetParent(SkillContainer.transform);
            
    }
  }

    // Update is called once per frame
    void Update()
  {
    //if (currentLevel % 5 == 0)
    //{
    //    scalingFactor++;
    //}
    GlobalStaticVars.LevelTime += Time.deltaTime;
    if (isDrainingHealth)
    {
      time -= Time.deltaTime;
      if (time < 0)
      {
        time = 0.1f;
        ChangeHealth(losingSpeed);
      }
    }
  }

  public void ChangeHealth(float amount)
  {
    if (currentHealth + amount <= 0)
    {
     GameState.instance.Lose();
    }
    currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
  }

  public void ChangeYinYang(bool isYin, int amount)
  {
    if (!isYin) amount = -amount;

    if (amount + currentYin <= 10 || amount + currentYin >= 90)
    {
      isDrainingHealth = true;
      losingSpeed = -0.6f;
            UnbalanceText.SetActive(true);
    }
    else if (amount + currentYin <= 20 || amount + currentYin >= 80)
    {
      isDrainingHealth = true;
      losingSpeed = -0.3f;
            UnbalanceText.SetActive(true);
        }
    else
    {
      isDrainingHealth = false;
            UnbalanceText.SetActive(false);
        }

    time = 0.1f;
    currentYin = Mathf.Clamp(currentYin + amount, 0, maxYin);
    currentYang = 100 - currentYin;
  }

    public void upgradeAttack(int amount)
    {
        //currentLevel++;
        attack += amount;
        //maxHealth += scalingFactor * 10;
        //currentHealth = maxHealth;
    }

    public void upgradeHP(int amount)
    {
        //currentLevel++;
        //currentAttack = currentLevel * scalingFactor;
        maxHealth += amount;
        //currentHealth = maxHealth;
    }

    public void rewardPoints(int amount)
    {
        GlobalStaticVars.playerPoints += amount;
        points = GlobalStaticVars.playerPoints;
    }

    public void reBalance()
  {
    currentYin = initYin;
    currentYang = maxYang - initYin;
  }
}
