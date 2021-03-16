using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rollingIcon : MonoBehaviour
{
    // Start is called before the first frame update
    private RectTransform image;
    void Start()
    {
        image = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        image.Rotate(new Vector3(0, 0, -0.1f));
    }
}
