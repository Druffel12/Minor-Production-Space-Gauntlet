using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public List<GameObject> players;

    public float cameraSpeed;

    public float minCameraDistance;
    float cameraDistance = 20;
    public float maxCameraDistance;

    public float offset;

    Camera mainCamera;
    Vector3 center;
    Vector3 centroid;
    float count;

	void Start ()
    {
        mainCamera = GetComponent<Camera>();
        players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        StartCoroutine("CameraPosition");
    }

    IEnumerator CameraPosition()
    {
        while (true)
        {
            center = Vector3.zero;
            count = 0;
            foreach (GameObject player in players)
            {
                center += player.transform.position;
                count++;
                Vector3 viewPos = mainCamera.WorldToViewportPoint(player.transform.position);

                //zooms the camera out
                if(viewPos.x < 0.1f || viewPos.x > 0.9f)
                {
                    if(cameraDistance < maxCameraDistance)
                    {
                        cameraDistance += Time.deltaTime;
                        offset += Time.deltaTime * cameraSpeed;
                    }
                }

            }

            centroid = center / players.Count;
            Vector3 centerVector = new Vector3(centroid.x, cameraDistance, centroid.z - offset);


            transform.position = centerVector;

            yield return null;
        }
    }
}
