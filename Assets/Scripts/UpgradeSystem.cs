using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeSystem : MonoBehaviour
{
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI yinyangText;

    public TextMeshProUGUI attackCost;
    public TextMeshProUGUI healthCost;
    public TextMeshProUGUI energyCost;
    // Start is called before the first frame update
    void Start()
    {
        setText(GlobalStaticVars.playerAttack, GlobalStaticVars.playerHP, GlobalStaticVars.playerPoints, GlobalStaticVars.StoredYin);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setText(int attack, int health, int points, int yinyang)
    {
        attackText.text = "Attack Damage:  " + attack.ToString();
        healthText.text = "Health:  " + health.ToString();
        pointsText.text = "Your Points: " + points.ToString();
        yinyangText.text = "Initial Energies: " + yinyang.ToString();
    }

    public void upgradeAttack(int amount)  // Set amount: 5
    {
        int cost = 10 + (GlobalStaticVars.playerAttack - 10);
        if (GlobalStaticVars.playerPoints >= cost)
        {
            GlobalStaticVars.playerPoints -= cost;
            GlobalStaticVars.playerAttack += amount;
            setText(GlobalStaticVars.playerAttack, GlobalStaticVars.playerHP, GlobalStaticVars.playerPoints, GlobalStaticVars.StoredYin);
            attackCost.text = "Cost: " + (10 + (GlobalStaticVars.playerAttack - 10)) + " points";
        }
    }

    public void upgradeHP(int amount) // Set amount: 10
    {
        int cost = 10 + (GlobalStaticVars.playerHP - 100) / 2;

        if (GlobalStaticVars.playerPoints >= cost)
        {
            GlobalStaticVars.playerPoints -= cost;
            GlobalStaticVars.playerHP += amount;
            setText(GlobalStaticVars.playerAttack, GlobalStaticVars.playerHP, GlobalStaticVars.playerPoints, GlobalStaticVars.StoredYin);
            healthCost.text = "Cost: " + (10 + (GlobalStaticVars.playerHP - 100) / 2) + " points";
        }
    }

    public void upgradeStoredYinYang(int amount) // Set amount: 1
    {
        int cost = 10 + (GlobalStaticVars.StoredYin - 1) * 5;

        if (GlobalStaticVars.playerPoints >= cost)
        {
            GlobalStaticVars.playerPoints -= cost;
            GlobalStaticVars.StoredYin += amount;
            GlobalStaticVars.StoredYang += amount;
            setText(GlobalStaticVars.playerAttack, GlobalStaticVars.playerHP, GlobalStaticVars.playerPoints, GlobalStaticVars.StoredYin);
            energyCost.text = "Cost: " + (10 + (GlobalStaticVars.StoredYin - 1) * 5) + " points";
        }
    }
}
