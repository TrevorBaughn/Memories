using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    //Start Button
    public void StartGame()
    {
        SceneManager.LoadScene("TestScene");    
    }

    //Options Button
    public void OpenOptions()
    {
        //TODO: CREATE OPTIONS MENU
    }

    //Credits Button
    public void PlayCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    //Quit Button
    public void QuitGame()
    {
        Application.Quit();
    }
}
