using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;

    private void Start()
    {
        Resume();
    }

    public void TogglePause()
    {
        if (_pauseMenu.activeInHierarchy)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    private void Pause() 
    {
        _pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    private void Resume()
    {
        _pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
