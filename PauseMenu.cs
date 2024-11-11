using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // 다른 스크립트에서 쉽게 접근이 가능하도록 static
    public static bool GameIsPaused = false;
    public GameObject pauseMenuCanvas;
    [SerializeField] private AudioSource source;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        source.pitch = 1f;

    }

    public void Pause()
    {
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        source.pitch = 0f;

    }

    public void ToSettingMenu()
    {
        Debug.Log("아직 미구현입니다...");
    }

    public void ToMain()
    {
        Debug.Log("아직 미구현입니다...");
        //Time.timeScale = 1f;
        //SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("아직 미구현입니다...");
        Application.Quit();
    }

    public void Start()
    {
        pauseMenuCanvas.SetActive(false);
    }
}