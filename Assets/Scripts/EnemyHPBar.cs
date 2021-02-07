using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform targetEnemy;

    private RectTransform HPValueBar;
    private Enemy enemyScript;
    private CanvasGroup cg;

    private void Start()
    {
        HPValueBar = GetComponentsInChildren<RectTransform>()[1];
        cg = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (enemy)
        {
            cg.alpha = 1;
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            Vector3 headPosition = Camera.main.WorldToScreenPoint(enemy.transform.GetChild(0).position);
            transform.position = headPosition;

            float enemyHP = enemyScript.getHP();
            HPValueBar.sizeDelta = new Vector2(enemyHP * 2, 40);
        }
        else
        {
            cg.alpha = 0;
        }
    }
}
