using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartButton()
    {
        int currentindex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentindex + 1);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
