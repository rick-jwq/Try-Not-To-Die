using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPlayerStat : MonoBehaviour
{
    // Start is called before the first frame update

    private CharacterControll cc;

    private RectTransform HPValue;
    private RectTransform YinValue;

    public Text points;
    void Start()
    {
        cc = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControll>();
        HPValue = transform.GetChild(0).GetComponentsInChildren<RectTransform>()[1];
        YinValue = transform.GetChild(1).GetComponentsInChildren<RectTransform>()[1];
        points.text = "Score: " + cc.points.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        HPValue.sizeDelta = new Vector2(cc.health / cc.maxHealth * 300f, 40);
        GetComponentsInChildren<Text>()[1].text = cc.currentHealth + "/" + cc.maxHealth;
        float yin = cc.yin / 100f;
        float factor = (yin - 0.5f) * 2f;
        float sign = yin == 0.5f? 1 : (yin - 0.5f) / Mathf.Abs(yin - 0.5f);
        YinValue.localPosition = Vector3.Lerp(YinValue.localPosition, new Vector3(sign * 160f * factor * factor, 0, 0), 4f * Time.unscaledDeltaTime);
        points.text = "Score: " + cc.points.ToString();
    }
}
