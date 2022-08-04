using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{


    [Header("Character attributes:")]
    public float baseSpeed = 1;


    [Header("Character stats:")]
    public Vector3 movementDirection;
    public Vector3 aimDirection = Vector3.zero;
    public Vector3 serveForce = new Vector3(-4, 10, 0);
    public float movementSpeed;
    public GameObject targetSphere;
    public float topSpin = 1;

    [Header("References:")]
    public Rigidbody rb;
    public GameObject ball;
    public Camera firstPersonCam;
    public Camera mainCam;
    public GameObject myPrefab;

    private bool serving = false;


    private List<GameObject> targetSpheres = new List<GameObject>();

    void Start()
    {
        serve();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        if (serving)
        {
            aimDirection += movementDirection/18;
            drawAimPoints(aimDirection + serveForce, transform.position + new Vector3(0, 2, 0));

            if (Input.GetAxis("Jump") > 0.5)
            {
                ball.transform.position = transform.position + new Vector3(0, 2, 0);
                ball.GetComponent<Rigidbody>().velocity = aimDirection + serveForce;
                ball.GetComponent<ball>().gravity = Physics.gravity * topSpin;
                ball.SetActive(true);
                serving = false;
            }

        } else
        {
            move();
        }

    }


    void ProcessInputs()
    {
        movementDirection = new Vector3(Input.GetAxis("Vertical") * -1 , 0, Input.GetAxis("Horizontal"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();
    }


    void move()
    {

        rb.velocity = movementDirection * movementSpeed * baseSpeed;

    }

    void serve()
    {
        serving = true;
        mainCam.gameObject.SetActive(false);
        firstPersonCam.gameObject.SetActive(true);

        myPrefab = Instantiate(myPrefab, transform.position + new Vector3(-15, -0.9f,0), Quaternion.identity);


    }

    void drawAimPoints(Vector3 vel, Vector3 startingPos)
    {
        List<Vector3> list = new List<Vector3>();
        {
            for (int i = 0; i < 1000; i++)
            {
                Vector3 newPoint = startingPos + i / 10f * vel;
                newPoint.y = startingPos.y + vel.y * i / 10f + (Physics.gravity.y * topSpin) / 2f * i / 10f * i / 10f;
                list.Add(newPoint);
            }
        }

        List<GameObject> points = new List<GameObject>();
        foreach (Vector3 pos in list)
        {
            points.Add(Instantiate(targetSphere, pos, Quaternion.identity));

        }
        foreach (GameObject o in targetSpheres)
        {
            Destroy(o);
        }
        targetSpheres = points;
    }


}
