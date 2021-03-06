﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonYangControl : MonoBehaviour
{
    private CharacterControll cc;
    private Text b2text;
    // Start is called before the first frame update
    void Start()
    {
        cc = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControll>();
        b2text = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        b2text.text = cc.storedYang.ToString();
    }

    public void UseYang()
    {
        if (cc.storedYang > 0)
        {
            cc.ChangeYinYang(false,10);
            cc.ChangeStoredYang(-1);
            cc.usedYang +=1;
        }
    }
}
