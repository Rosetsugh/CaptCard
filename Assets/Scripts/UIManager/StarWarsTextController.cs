using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarWarsTextController : MonoBehaviour
{

    [Range(0f, 0.02f)]
    public float slideSpeed;
    public Transform transformLogo;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 4.8f)
        {
            transform.position += new Vector3(0, slideSpeed, slideSpeed);
        }
        else
        {
            transform.position += new Vector3(0, slideSpeed, slideSpeed);
            transformLogo.transform.position -= new Vector3(0, slideSpeed, slideSpeed);
        }
    }
}
