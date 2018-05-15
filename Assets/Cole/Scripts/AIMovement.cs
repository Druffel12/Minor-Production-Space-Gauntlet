using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public float Speed;
    private Transform Player;
    Vector3 Dir;
    
    private void Awake()
    {
        MyTransform = transform;
    }
    // Use this for initialization
    void Start ()
    {
        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player").transform;
        }


	}
	
	// Update is called once per frame
	void Update ()
    {

        // Vector3 lookat = Player.position;
        //transform.LookAt(lookat);

        Dir = MyTransform.position - Player.transform.position;
        MyTransform.position -= Dir.normalized * Speed; 
		
	}
}
