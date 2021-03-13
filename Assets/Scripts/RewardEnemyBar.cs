using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardEnemyBar : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject arrowContainer;
    public GameObject UpArrow;
    public GameObject DownArrow;
    public GameObject LeftArrow;
    public GameObject RightArrow;

    private GameObject targetEnemy;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (targetEnemy)
        {
            Vector3 headPosition = Camera.main.WorldToScreenPoint(targetEnemy.transform.GetChild(0).position);
            transform.position = headPosition;
        }
    }

    public void Track(GameObject target)
    {
        targetEnemy = target;
    }

    public void UpdateArrows()
    {
        RewardEnemy enemyScript = targetEnemy.GetComponent<RewardEnemy>();
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
