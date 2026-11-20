using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour {
    public void Play() {
        SceneManager.LoadScene("PrototypeScene");
    }

    public void ReturnMain() {
        SceneManager.LoadScene("Main Menu");
    }

    public void Exit() {
        Application.Quit();
    }

}
