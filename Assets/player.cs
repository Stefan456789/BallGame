using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    [Header("Player attributes:")]
    public Vector3 additionalForce = new Vector3(0,1,0);

    [Header("References:")]
    public Rigidbody target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(target.position, transform.position);
        if (distance < 2 && target.velocity.magnitude < 8)
        {
            Vector3 destination = (target.position - transform.position);
            destination.Normalize();
            target.velocity += (destination / 4) + additionalForce;
        }
    }
    
}
