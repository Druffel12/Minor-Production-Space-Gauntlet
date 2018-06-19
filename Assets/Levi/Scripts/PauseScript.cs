using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public Canvas pauseCanvas;

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseCanvas.gameObject.SetActive(true);
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
        pauseCanvas.gameObject.SetActive(false);
    }

	// Update is called once per frame
	void Update ()
    {
		if(Time.timeScale > 0)
        {
            pauseCanvas.gameObject.SetActive(false);
        }
	}
}
