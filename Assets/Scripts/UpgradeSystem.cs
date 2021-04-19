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
        yinyangText.text = "Initial Power: " + yinyang.ToString();
    }

    public void upgradeAttack(int amount)  // Set amount: 5
    {
        if(GlobalStaticVars.playerPoints >= 10+ (GlobalStaticVars.playerAttack-10))
        {
            GlobalStaticVars.playerPoints -= 10+ (GlobalStaticVars.playerAttack-10);
            GlobalStaticVars.playerAttack += amount;
            setText(GlobalStaticVars.playerAttack, GlobalStaticVars.playerHP, GlobalStaticVars.playerPoints, GlobalStaticVars.StoredYin);
        }
    }

    public void upgradeHP(int amount) // Set amount: 10
    {
        if (GlobalStaticVars.playerPoints >= 10+ (GlobalStaticVars.playerHP-100)/2)
        {
            GlobalStaticVars.playerPoints -= 10+ (GlobalStaticVars.playerHP-100)/2;
            GlobalStaticVars.playerHP += amount;
            setText(GlobalStaticVars.playerAttack, GlobalStaticVars.playerHP, GlobalStaticVars.playerPoints, GlobalStaticVars.StoredYin);
        }
    }

    public void upgradeStoredYinYang(int amount) // Set amount: 1
    {
        if (GlobalStaticVars.playerPoints >= 10+ (GlobalStaticVars.StoredYin-1)*5)
        {
            GlobalStaticVars.playerPoints -= 10+ (GlobalStaticVars.StoredYin-1)*5;
            GlobalStaticVars.StoredYin += amount;
            GlobalStaticVars.StoredYang += amount;
            setText(GlobalStaticVars.playerAttack, GlobalStaticVars.playerHP, GlobalStaticVars.playerPoints, GlobalStaticVars.StoredYin);
        }
    }
}
