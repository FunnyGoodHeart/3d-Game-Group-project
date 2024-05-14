using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] Canvas pauseMenu;
    public bool lockCursor = true;

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
            CursorChange();
            //pI.enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0)
        {
            //pI.enabled = true;
            Resume();
        }
    }
    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.enabled = false;
        CursorChange();
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
    public void CursorChange()
    {
        lockCursor = !lockCursor;
        Cursor.lockState = lockCursor ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !lockCursor;
    }
}
