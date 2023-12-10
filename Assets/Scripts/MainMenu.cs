using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene("TitleScene");
    }

   public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Controls()
    {
        SceneManager.LoadScene("ControlsScreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}