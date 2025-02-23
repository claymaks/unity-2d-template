using UnityEditor;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseMenuUI;

    void Update()
    {
        MaybeTogglePause();
    }

    private void MaybeTogglePause()
    {
        if (Input.GetButtonDown("Cancel") && PauseMenuUI != null)
        {
            if (GameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void LoadScene(string scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(scene);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void ResumeGame()
    {
        GameIsPaused = false;
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        GameIsPaused = true;
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void GoToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("MainMenu");
    }

    public void QuitGame(bool save = false)
    {
        Debug.Log("User closed application");
        Application.Quit();
    }
}
