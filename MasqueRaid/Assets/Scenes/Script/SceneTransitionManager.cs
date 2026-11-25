using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour {
    public void Play() {
        SceneManager.LoadScene("PrototypeScene");
        Time.timeScale = 1f;
    }

    public void ReturnMain() {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
    }

    public void Exit() {
        Application.Quit();
    }

}
