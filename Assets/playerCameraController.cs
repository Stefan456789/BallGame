using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCameraController : MonoBehaviour
{

    [Header("References:")]
    public Transform target;
    public Camera mainCam;
    public Camera firstPersonCam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float distance = Vector3.Distance(target.position, transform.position);
        //if (distance < 4)
        //{
        //    mainCam.gameObject.SetActive(false);
        //    firstPersonCam.gameObject.SetActive(true);
        //}
        //else
        //{
        //    firstPersonCam.gameObject.SetActive(false);
        //    mainCam.gameObject.SetActive(true);
        //}
    
        if (target.position.y > transform.position.y)
        transform.LookAt(target);
    }
}
