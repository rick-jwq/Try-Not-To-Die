using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonYinControl : MonoBehaviour
{
    private CharacterControll cc;
    private Text b1text;
    // Start is called before the first frame update
    void Start()
    {
        cc = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControll>();
        b1text = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        b1text.text = cc.storedYin.ToString();
    }

    public void UseYin()
    {
        if (cc.storedYin > 0)
        {
            cc.ChangeYinYang(true, 10);
            cc.ChangeStoredYin(-1);
            cc.usedYin +=1;
        }
    }
}
