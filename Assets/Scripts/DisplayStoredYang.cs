using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayStoredYang : MonoBehaviour
{
    private CharacterControll cc;
    // Start is called before the first frame update
    void Start()
    {
        cc = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControll>();
    }

    // Update is called once per frame
    void Update()
    {
        int Yin=cc.storedYin;
        transform.Find("Text").GetComponent<Text>().text=Yin.ToString();
    }
}
