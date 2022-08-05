using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : player
{


    [Header("Character attributes:")]
    public float baseSpeed = 1;


    [Header("Character stats:")]
    public Vector3 movementDirection;
    public Vector3 aimDirection = Vector3.zero;
    public float movementSpeed;
    public GameObject targetSphere;

    [Header("References:")]
    public Rigidbody rb;
    public Camera firstPersonCam;
    public Camera mainCam;
    public GameObject BallPrefab;

    private bool serving = false;


    private List<GameObject> targetSpheres = new List<GameObject>();

    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        ProcessInputs();
        if (serving)
        {
            aimDirection += movementDirection/18;
            drawAimPoints(aimDirection + serveForce, transform.position + new Vector3(0, 2, 0));

            if (Input.GetAxis("Jump") > 0.5)
            {
                ball.transform.position = transform.position + new Vector3(0, 2, 0);
                ball.GetComponent<Rigidbody>().velocity = aimDirection + serveForce;
                ball.GetComponent<Ball>().gravity = Physics.gravity * topSpin;
                ball.SetActive(true);
                serving = false;
            }

        } else
        {
            move();
        }

        if (firstPersonCam.gameObject.activeSelf)
        {
            float yRotation = firstPersonCam.transform.rotation.eulerAngles.x - Input.GetAxisRaw("Mouse Y");
            float xRotation = firstPersonCam.transform.rotation.eulerAngles.y + Input.GetAxisRaw("Mouse X");
            firstPersonCam.transform.rotation = Quaternion.Euler(yRotation, xRotation, 0);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        } else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
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

    public override void Serve()
    {
        serving = true;
        mainCam.gameObject.SetActive(false);
        firstPersonCam.gameObject.SetActive(true);

        //BallPrefab = Instantiate(BallPrefab, transform.position + new Vector3(-15, -0.9f,0), Quaternion.identity);
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
