using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bot : MonoBehaviour
{
    [Header("References:")]
    public Transform target;
    [Header("Stats:")]
    public float offset;
    public float smoothSpeed = 0.005f;
    public Vector2 boundsX;
    public Vector2 boundsY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.x > 0 && target.position.x > 0) || (transform.position.x < 0 && target.position.x < 0)) { 
        Vector3 desiredPosition = new Vector3(Mathf.Clamp(target.position.x, boundsX.x, boundsX.y) + offset, transform.position.y, Mathf.Clamp(target.position.z, boundsY.x, boundsY.y));
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.timeScale);
        transform.position = smoothedPosition;
        }
    }
}
