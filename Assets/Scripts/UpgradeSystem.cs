using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeSystem : MonoBehaviour
{
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI pointsText;
    // Start is called before the first frame update
    void Start()
    {
        setText(GlobalStaticVars.playerAttack, GlobalStaticVars.playerHP, GlobalStaticVars.playerPoints);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setText(int attack, int health, int points)
    {
        attackText.text = "Attack Damage:  " + attack.ToString();
        healthText.text = "Health:  " + health.ToString();
        pointsText.text = "Your Points: " + points.ToString();
    }

    public void upgradeAttack(int amount)
    {
        if(GlobalStaticVars.playerPoints >= 10)
        {
            GlobalStaticVars.playerAttack += amount;
            GlobalStaticVars.playerPoints -= 10;
            setText(GlobalStaticVars.playerAttack, GlobalStaticVars.playerHP, GlobalStaticVars.playerPoints);
        }
    }

    public void upgradeHP(int amount)
    {
        if (GlobalStaticVars.playerPoints >= 10)
        {
            GlobalStaticVars.playerHP += amount;
            GlobalStaticVars.playerPoints -= 10;
            setText(GlobalStaticVars.playerAttack, GlobalStaticVars.playerHP, GlobalStaticVars.playerPoints);
        }
    }
}
