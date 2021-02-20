using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayStoredYin : MonoBehaviour
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
        int Yang=cc.storedYang;
        transform.Find("Text").GetComponent<Text>().text=Yang.ToString();
    }
}
