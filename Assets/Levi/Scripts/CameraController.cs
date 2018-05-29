﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public List<GameObject> players;
    public List<InvisibleWallController> walls;

    public float cameraSpeed;

    public float minCameraDistance;
    [SerializeField]
    float cameraDistance = 25;
    public float maxCameraDistance;

    public float maxDistance;

    bool canZoomOut = false;

    public float minOffset;
    [SerializeField]
    float offset;
    public float maxOffset;
    
    Vector3 center;
    Vector3 centroid;
    float count;
    int zoomCounter;


    void CameraZoomin()
    {
        cameraDistance -= Time.deltaTime * cameraSpeed;
        if (offset > minOffset)
        {
            offset -= Time.deltaTime * cameraSpeed / 2;
        }
        //tells the walls to spread out
        foreach (InvisibleWallController wall in walls)
        {
            wall.offset -= Time.deltaTime * cameraSpeed;
        }
    }

    void CameraZoomOut()
    {
        cameraDistance += Time.deltaTime * cameraSpeed;
        if (offset < maxOffset)
        {
            offset += Time.deltaTime * cameraSpeed/2;
        }
        //tells the wells to come closer to the players
        foreach(InvisibleWallController wall in walls)
        {
            wall.offset += Time.deltaTime * cameraSpeed;
        }
    }

    void Start ()
    {
        //logs all the players currently playing
        players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        offset = minOffset;
        StartCoroutine("CameraPosition");
    }

    IEnumerator CameraPosition()
    {
        while (true)
        {
            //resets the values
            center = Vector3.zero;
            count = 0;
            //finds the center between all the players
            foreach (GameObject player in players)
            {
                center += player.transform.position;
                count++;
            }

            centroid = center / players.Count;
            Vector3 centerVector = new Vector3(centroid.x, cameraDistance, centroid.z - offset);

            //checks through all the players to see if the camera should zoom out
           for(int i = 0; i < players.Count; i++)
            {
                float distanceFromCenter = Vector3.Distance(players[i].transform.position, centroid);
                if (distanceFromCenter >= maxDistance)
                {
                    canZoomOut = true;
                    if(cameraDistance < maxCameraDistance)
                    {
                        CameraZoomOut();
                    }
                }

                if(distanceFromCenter < maxDistance)
                {
                    zoomCounter++;
                    if(zoomCounter >= players.Count)
                    {
                        canZoomOut = false;
                    }
                    if(cameraDistance > minCameraDistance && canZoomOut == false)
                    {
                        CameraZoomin();
                    }
                }
                Color test = distanceFromCenter < maxDistance ? Color.red : Color.blue;
                Debug.DrawLine(centroid, players[i].transform.position, test);
            }


            // moves the camera to the center between the players
            transform.position = centerVector;

            yield return null;
        }
    }
}
