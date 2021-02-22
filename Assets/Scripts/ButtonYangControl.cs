using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonYangControl : MonoBehaviour
{
    public CharacterControll cc;
    private Text b2text;
    // Start is called before the first frame update
    void Start()
    {
        b2text = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        b2text.text = cc.storedYang.ToString();
    }

    public void UseYang()
    {
        if (cc.storedYang >= 0)
        {
            cc.ChangeYinYang(false,3);
            cc.ChangeStoredYang(-1);
        }
    }
}
