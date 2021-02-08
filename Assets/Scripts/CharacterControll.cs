using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControll : MonoBehaviour
{
    public int maxHealth = 100;
    public int maxHunger = 100;
    public int maxThirst = 100;

    public int losingSpeed = -5;

    public float time = 2.0f;

    int currentHealth;
    public int health { get { return currentHealth; } }

    int currentHunger;
    public int hunger { get { return currentHunger; } }

    int currentThirst;
    public int thirst { get { return currentThirst; } }

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
        currentHunger = maxHunger;
        currentThirst = maxThirst;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            time = 2.0f;
            ChangeHunger(losingSpeed);
            ChangeThirst(losingSpeed);
        }
    }

    public void ChangeHealth(int amount)
    {
        if (currentHealth + amount <= 0)
        {
            //Debug.Log("currentHealth: " + currentHealth + "/" + maxHealth);
            //Debug.Log("You lost");
            //UnityEditor.EditorApplication.isPlaying = false;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        //Debug.Log("currentHealth: " + currentHealth + "/" + maxHealth);
    }

    public void ChangeHunger(int amount)
    {
        if (currentHunger + amount <= 0)
        {
            //Debug.Log("currentHunger: " + currentHunger + "/" + maxHunger);
            //Debug.Log("You lost");
            //UnityEditor.EditorApplication.isPlaying = false;
        }
        currentHunger = Mathf.Clamp(currentHunger + amount, 0, maxHunger);
        //Debug.Log("currentHunger: " + currentHunger + "/" + maxHunger);
    }

    public void ChangeThirst(int amount)
    {
        if (currentThirst + amount <= 0)
        {
            //Debug.Log("currentThirst: " + currentThirst + "/" + maxThirst);
            //Debug.Log("You lost");
            //UnityEditor.EditorApplication.isPlaying = false;
        }
        currentThirst = Mathf.Clamp(currentThirst + amount, 0, maxThirst);
        //Debug.Log("currentThirst: " + currentThirst + "/" + maxThirst);
    }
}
