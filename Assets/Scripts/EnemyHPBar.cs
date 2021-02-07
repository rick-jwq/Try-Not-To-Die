using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform targetEnemy;

    private RectTransform HPValueBar;
    private Enemy enemyScript;

    private void Start()
    {
        HPValueBar = GetComponentsInChildren<RectTransform>()[1];
    }

    // Update is called once per frame
    void Update()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (enemy)
        {
            gameObject.SetActive(true);
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            Vector3 headPosition = Camera.main.WorldToScreenPoint(enemy.transform.GetChild(0).position);
            transform.position = headPosition;

            float enemyHP = enemyScript.getHP();
            HPValueBar.sizeDelta = new Vector2(enemyHP * 2, 40);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
