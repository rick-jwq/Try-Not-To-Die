using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beam : MonoBehaviour
{
    // Start is called before the first frame update
    private ParticleSystem ps;
    void Awake()
    {
        ps = GetComponent<ParticleSystem>();

        Vector3 start = new Vector3(1, 0, 3);
        Vector3 end = Attack.instance.Enemyarry[0].transform.position;

        Vector3 offset = end - start;
        ParticleSystem.ShapeModule shape = ps.shape;
        shape.scale = new Vector3(offset.magnitude, 0.1f, 0.1f);
        shape.position = start + (offset / 2);
    }
}
