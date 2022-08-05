using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bot : player
{
    [Header("Stats:")]
    public float offset;
    public float smoothSpeed = 0.005f;
    public Vector2 boundsX;
    public Vector2 boundsY;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if ((transform.position.x > 0 && ball.transform.position.x > 0) || (transform.position.x < 0 && ball.transform.position.x < 0)) { 
            Vector3 desiredPosition = new Vector3(Mathf.Clamp(ball.transform.position.x, boundsX.x, boundsX.y) + offset, transform.position.y, Mathf.Clamp(ball.transform.position.z, boundsY.x, boundsY.y));
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.timeScale);
            transform.position = smoothedPosition;
        }
    }

    public override void Serve()
    {

    }
}
