using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWallController : MonoBehaviour
{
    public float side;
    public Camera cam;

    public float offset;

    float moveHorizontal;
    Vector3 viewPos;

	// Use this for initialization
	void Start ()
    {
        viewPos = (cam.WorldToViewportPoint(transform.position));
    }

    private void Update()
    {
        if (gameObject.name == "Right")
        { 
            if (viewPos.x < side)
            {
                transform.position = cam.ViewportToWorldPoint(new Vector3(1, 0, offset));
            }
        }

        if (gameObject.name == "Left")
        {
            if (viewPos.x > side)
            {
                transform.position = cam.ViewportToWorldPoint(new Vector3(0, 0, offset));
            }
        }

        if(gameObject.name == "Top")
        {
            if (viewPos.y < side)
            {
                transform.position = cam.ViewportToWorldPoint(new Vector3(0, 1, offset));
            }
        }

        if(gameObject.name == "Bottom")
        {
            if (viewPos.y <= side)
            {
                transform.position = cam.ViewportToWorldPoint(new Vector3(0, 0, offset));
            }
        }
    }
    
}
