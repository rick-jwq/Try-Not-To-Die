using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControll : MonoBehaviour
{
  public int maxHealth = 100;
  public int maxYin = 100;
  public int maxYang = 100;
  public int initYin = 50;

  public float losingSpeed = -0.3f;

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

  int currentLevel;
  public int level { get { return currentLevel; } }

  int currentAttack;
  public int attack { get { return currentAttack; } }

  int scalingFactor;

  public List<GameObject> skills = new List<GameObject>();

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
    currentHealth = maxHealth;

    currentStoredYin = 0;
    currentStoredYang = 0;

    currentYin = initYin;
    currentYang = maxYang - initYin;
    
    currentLevel = 1;
    currentAttack = 1;
    scalingFactor = 1;

    foreach (GameObject obj in skills)
    {
        obj.SetActive(true);
    }
  }

    // Update is called once per frame
    void Update()
  {
    if (currentLevel % 5 == 0)
    {
        scalingFactor++;
    }

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
     Time.timeScale = 0;
     GameEndScreen.SetActive(true);
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

  public void upgrade()
    {
        currentLevel++;
        currentAttack = currentLevel * scalingFactor;
        maxHealth += scalingFactor * 10;
        currentHealth = maxHealth;
    }
}
