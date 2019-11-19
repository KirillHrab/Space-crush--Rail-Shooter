using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float yAngle;

   // private GameObject cube1, cube2;
    // Start is called before the first frame update
    void Start()
    {
        yAngle = 50f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, yAngle*Time.deltaTime, 0);
    }
}
