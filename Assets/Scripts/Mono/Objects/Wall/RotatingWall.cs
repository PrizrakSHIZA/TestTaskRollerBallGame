using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingWall : MonoBehaviour
{
    [Range(0.1f, 5)] public float speed = 1;
    public bool leftside = false;

    void Start()
    {
        if (leftside)
            speed = speed * -1;
    }

    void Update()
    {
        gameObject.transform.Rotate(0, speed, 0);
    }
}
