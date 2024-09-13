using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void Quit()
    {
        Application.Quit();
    }
    
    public void LoadSceneByName(string sceneName)
    {
        // Load the scene by the name passed in as a parameter
        SceneManager.LoadScene(sceneName);
    }
}
