using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    [SerializeField] GameObject pauseMenuGO;

    public void exit()
    {
        if (GameIsPaused)
            resume();
        SceneManager.LoadScene("MainMenu");
    }

    public void quit()
    {
        Application.Quit();
    }

    public void resume()
    {
        pauseMenuGO.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void pause()
    {
        pauseMenuGO.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

}
