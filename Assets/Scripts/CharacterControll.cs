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

  public int losingSpeed = -5;

    public Text YinText;
    public Text YangText;

  public float time = 2.0f;

  bool isDrainingHealth = false;

  public int currentHealth;
  public int health { get { return currentHealth; } }

  int currentYin;
  public int yin { get { return currentYin; } }

  int currentYang;
  public int yang { get { return currentYang; } }

  int currentStoredYin;
  public int storedYin { get { return currentStoredYin; } }
  int currentStoredYang;
  public int storedYang { get { return currentStoredYang; } }
  private Rigidbody rb;

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
  }

  // Update is called once per frame
  void Update()
  {
    if (isDrainingHealth)
    {
      time -= Time.deltaTime;
      if (time < 0)
      {
        time = 2.0f;
        ChangeHealth(losingSpeed);
      }
    }
  }

  public void ChangeHealth(int amount)
  {
    if (currentHealth + amount <= 0)
    {
      // You lost
    }
    currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
  }

  public void ChangeYinYang(bool isYin, int amount)
  {
    if (!isYin) amount = -amount;

    if (amount + currentYin <= 10 || amount + currentYin >= 90)
    {
      isDrainingHealth = true;
      losingSpeed = -10;
    }
    else if (amount + currentYin <= 20 || amount + currentYin >= 80)
    {
      isDrainingHealth = true;
      losingSpeed = -5;
    }
    else
    {
      isDrainingHealth = false;
    }

    time = 2.0f;
    currentYin = Mathf.Clamp(currentYin + amount, 0, maxYin);
    currentYang = 100 - currentYin;
  }
}
