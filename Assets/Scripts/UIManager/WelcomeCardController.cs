using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeCardController : MonoBehaviour
{
    [Range(0f, 0.05f)]
    public float slideFactor = 0.0125f;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < -1f || transform.position.z > 1f)
        {
            transform.position += new Vector3(0f, 0f, slideFactor);
        }
        else
        {
            transform.position += new Vector3(0f, 0f, slideFactor / 2);
        }
    }
}
