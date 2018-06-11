using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWallController : MonoBehaviour
{
    public float side;
    public Camera cam;

    public float offset;

    private void Update()
    {
        //controls each walls positions
        if (gameObject.name == "Right")
        {
            transform.position = cam.ViewportToWorldPoint(new Vector3(1, 0, offset));
        }

        if (gameObject.name == "Left")
        {
            transform.position = cam.ViewportToWorldPoint(new Vector3(0, 0, offset));
        }

        if (gameObject.name == "Top")
        {
            transform.position = cam.ViewportToWorldPoint(new Vector3(0, 0.9f, offset));
        }

        if (gameObject.name == "Bottom")
        {
            transform.position = cam.ViewportToWorldPoint(new Vector3(0, 0, offset));
        }
    }
    
}
