using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XInputDotNetPure;

public class ButtonManager : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadLevel(string wool)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(wool);
    }
}
