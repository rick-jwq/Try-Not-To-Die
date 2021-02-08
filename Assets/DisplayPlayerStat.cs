using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPlayerStat : MonoBehaviour
{
    // Start is called before the first frame update

    public CharacterControll cc;

    private RectTransform HPValue;
    private RectTransform HungerValue;
    private RectTransform ThristValue;
    void Start()
    {
        HPValue = transform.GetChild(0).GetComponentsInChildren<RectTransform>()[1];
        HungerValue = transform.GetChild(1).GetComponentsInChildren<RectTransform>()[1];
        ThristValue = transform.GetChild(2).GetComponentsInChildren<RectTransform>()[1];
    }

    // Update is called once per frame
    void Update()
    {
        HPValue.sizeDelta = new Vector2(cc.health * 2, 40);
        HungerValue.sizeDelta = new Vector2(cc.hunger * 2, 40);
        ThristValue.sizeDelta = new Vector2(cc.thirst * 2, 40);
    }
}
