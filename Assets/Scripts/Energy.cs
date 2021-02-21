using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
  public int type;
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
  void OnMouseOver()
  {
    if (Input.GetMouseButtonDown(0))
    {
      //Change to changeYinYang
      //Item
      if (type == 1)
        cc.ChangeStoredYang(1);
      else
        cc.ChangeStoredYin(1);
      Destroy(gameObject);

      //Rick
      cc.ChangeYinYang(true, 10);
    }
  }
}
