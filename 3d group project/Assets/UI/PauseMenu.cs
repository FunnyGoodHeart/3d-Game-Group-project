using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] Canvas pauseMenu;
    bool isCursorLocked = false;
    //[SerializeField] GameObject player;
    //PlayerInput pI;

    private void Start()
    {
        pauseMenu.enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pauseMenu.enabled = true;
            cursorSwitch();
            //pI.enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0)
        {
            //pI.enabled = true;
            cursorSwitch();
            Resume();
        }
    }
    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.enabled = false;
        cursorSwitch();
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadPauseMenu()
    {
        Time.timeScale = 0;
        pauseMenu.enabled = true;
    }
    public void cursorSwitch()
    {
        Cursor.lockState = isCursorLocked ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !isCursorLocked;
    }
}
