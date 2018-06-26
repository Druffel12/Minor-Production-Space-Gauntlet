using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotater : MonoBehaviour {
    [Range(-200, 200)]
    public float XSpeed;
    [Range(-200, 200)]
    public float YSpeed;
    [Range(-200, 200)]
    public float ZSpeed;
    Vector3 Rotation;

	void Update ()
    {
        Rotation.x = XSpeed;
        Rotation.y = YSpeed;
        Rotation.z = ZSpeed;

        Rotation *= Time.deltaTime;             

        transform.Rotate(Rotation);
	}
}
