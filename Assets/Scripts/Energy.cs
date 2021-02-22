using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
  public bool isYin;
  private CharacterControll cc;
  private float spawnTime;
  // Start is called before the first frame update
  void Awake()
  {
    //transform.position = new Vector3(Random.Range(15, 30),1, Random.Range(2, 7));
  }
  void Start()
  {
    cc = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControll>();
    spawnTime = Time.time;
  }
  // Update is called once per frame
  void Update()
  {
    if (Time.time - spawnTime >= 10f)
    {
      Destroy(gameObject);
    }
  }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            cc.ChangeYinYang(isYin, 6);
            Destroy(gameObject);
        }
        else if(Input.GetMouseButtonDown(1))
        {
            if (isYin)
                cc.ChangeStoredYin(1);
            else
                cc.ChangeStoredYang(1);
            Destroy(gameObject);
        }
    }
}
