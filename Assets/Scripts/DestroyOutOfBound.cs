using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    private int xBound = -5;

    void LateUpdate()
    {
        if (transform.position.x < xBound)
        {
            Destroy(gameObject);
        }
    }
}
