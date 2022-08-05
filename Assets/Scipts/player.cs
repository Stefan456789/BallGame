using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{

    [Header("Player attributes:")]
    public Vector3 additionalForce = new Vector3(0,1,0);
    public Vector3 serveForce = new Vector3(0, 11, 0);
    public float topSpin = 1;

    [Header("References:")]
    public GameObject ball;

    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {

        float distance = Vector3.Distance(ball.transform.position, transform.position);
        if (distance < 2 && ball.GetComponent<Rigidbody>().velocity.magnitude < 8)
        {
            Vector3 destination = (ball.transform.position - transform.position);
            destination.Normalize();
            ball.GetComponent<Rigidbody>().velocity += (destination / 4) + additionalForce;
            if (this is PlayerController)
            {
                ball.GetComponent<Ball>().botTouchedLast = false;
            } else
            {
                ball.GetComponent<Ball>().botTouchedLast = true;
            }
        }
    }

    public abstract void Serve();

}
