using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPBar : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject arrowContainer;
    public GameObject UpArrow;
    public GameObject DownArrow;
    public GameObject LeftArrow;
    public GameObject RightArrow;

    private GameObject targetEnemy;

    private RectTransform HPValueBar;

    private Enemy enemyScript;
    private bool barset = false;

    private void Start()
    {
        HPValueBar = GetComponentsInChildren<RectTransform>()[1];
    }

    // Update is called once per frame
    void Update()
    {
        if (targetEnemy)
        {
            enemyScript = targetEnemy.GetComponent<Enemy>();
            Vector3 headPosition = Camera.main.WorldToScreenPoint(targetEnemy.transform.GetChild(0).position);
            transform.position = headPosition;

            if(!barset)
                SetBars(enemyScript);

            float enemyHP = enemyScript.getHP();
            HPValueBar.sizeDelta = new Vector2(enemyHP * 50, 40);
        }
    }


    private void SetBars(Enemy enemyScript)
    {
        float enemyHP = enemyScript.getHP();
        GetComponent<RectTransform>().sizeDelta = new Vector2(enemyHP * 50, 40);
        arrowContainer.GetComponent<RectTransform>().sizeDelta = new Vector2(enemyScript.arrayOfInts.Count * 30 * 1.6f, 40);
        barset = true;
    }

    public void Track(GameObject target)
    {
        targetEnemy = target;
    }

    public void UpdateArrows()
    {
        Enemy enemyScript = targetEnemy.GetComponent<Enemy>();
        GameObject arrow;
        foreach (Transform child in arrowContainer.transform)
        {
            Destroy(child.gameObject);
        }
        int i;
        for (i = 0; i < enemyScript.arrayOfInts.Count; i++)
        {
            switch (enemyScript.arrayOfInts[i])
            {
                case 1:
                    arrow = Instantiate(UpArrow);
                    arrow.transform.SetParent(arrowContainer.transform, false);
                    break;
                case 2:
                    arrow = Instantiate(DownArrow);
                    arrow.transform.SetParent(arrowContainer.transform, false);
                    break;
                case 3:
                    arrow = Instantiate(LeftArrow);
                    arrow.transform.SetParent(arrowContainer.transform, false);
                    break;
                case 4:
                    arrow = Instantiate(RightArrow);
                    arrow.transform.SetParent(arrowContainer.transform, false);
                    break;
            }
        }
    }
}
