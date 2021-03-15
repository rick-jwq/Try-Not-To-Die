using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    // Start is called before the first frame update
    public int level = 1;
    public string skill_name;
    public int Yincost;
    public int Yangcost;

    public virtual void Cast()
    {

    }
}
