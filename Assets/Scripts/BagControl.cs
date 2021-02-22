using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagControl : MonoBehaviour
{

    public int CurrentNumberYin;
    public int CurrentNumberYang;
    public int NumberYin { get { return CurrentNumberYin; } }
    public int NumberYang { get { return CurrentNumberYang; } }
    // Start is called before the first frame update
    void Start()
    {
        CurrentNumberYin=300;
        CurrentNumberYang=100;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
