using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [Header("References:")]
    public Rigidbody self;

    [Header("Stats:")]
    public float smoothSpeed = 0.125f;
    public Vector3 gravity = Physics.gravity;
    public bool? botTouchedLast = null;

    event EventHandler test;

    // Start is called before the first frame update
    void Start()
    {
        self.useGravity = false;
        test.Invoke(this, null);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0)
        {
            transform.position = new Vector3(0, 6, 0);
            self.velocity = Vector3.zero;
        }

    }

    void FixedUpdate()
    {
        self.AddForce(self.mass * gravity);
    }

    void lob(Vector3 pos)
    {
        //Vector3 start = transform.position;
        //Vector3 diff = start - pos;
        //while (start)
        //{

        //    pos.y += 0.1
        //}
    }
}
