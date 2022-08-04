using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeScale : MonoBehaviour
{
    [Header("References:")]
    public Transform target;


    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(target.position, transform.position) < 4)
        {
            Time.timeScale = 0.1f;
        }
        else
        {
            Time.timeScale = 1f;
        }

        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
}
