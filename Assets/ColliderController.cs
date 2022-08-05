using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ColliderController : MonoBehaviour
{
    public GameObject ball;
    event EventHandler ScoreEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(ball == other.gameObject)
        {
            ScoreEvent.Invoke(this, null);
            transform.position += new Vector3(0, 10, 0);
        }
        
    }
}
