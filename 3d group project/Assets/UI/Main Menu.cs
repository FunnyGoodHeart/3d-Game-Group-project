using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Player()
    {
        SceneManager.LoadScene("Jungle");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
