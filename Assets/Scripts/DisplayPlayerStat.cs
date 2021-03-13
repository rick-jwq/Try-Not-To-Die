using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPlayerStat : MonoBehaviour
{
    // Start is called before the first frame update

    public CharacterControll cc;

    private RectTransform HPValue;
    private RectTransform YinValue;

    public Text points;
    void Start()
    {
        HPValue = transform.GetChild(0).GetComponentsInChildren<RectTransform>()[1];
        YinValue = transform.GetChild(1).GetComponentsInChildren<RectTransform>()[1];
        YinValue = transform.GetChild(1).GetComponentsInChildren<RectTransform>()[1];
        points.text = "Points: " + cc.points.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        HPValue.sizeDelta = new Vector2(cc.health / cc.maxHealth * 200f, 40);
        GetComponentsInChildren<Text>()[1].text = cc.currentHealth + "/" + cc.maxHealth;
        YinValue.sizeDelta = new Vector2(cc.yin * 4f, 40);
        points.text = "Points: " + cc.points.ToString();
    }
}
