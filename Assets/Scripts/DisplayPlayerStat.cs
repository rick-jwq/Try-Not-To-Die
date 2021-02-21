using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPlayerStat : MonoBehaviour
{
    // Start is called before the first frame update

    public CharacterControll cc;

    private RectTransform HPValue;
    private RectTransform YinValue;
    void Start()
    {
        HPValue = transform.GetChild(0).GetComponentsInChildren<RectTransform>()[1];
        YinValue = transform.GetChild(1).GetComponentsInChildren<RectTransform>()[1];
    }

    // Update is called once per frame
    void Update()
    {
        HPValue.sizeDelta = new Vector2(cc.health * 2, 40);
        YinValue.sizeDelta = new Vector2(cc.yin * 4, 40);
    }
}
