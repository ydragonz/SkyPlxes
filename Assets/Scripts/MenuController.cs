using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Transform aviao001;
    [SerializeField] private Transform aviao002;
    [SerializeField] private Transform aviao003;

    public void PlayGame() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void GoToMenu() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    public void GoToGameOver() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }

    public void GoToWin() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Win");
    }

    public void GoToCredits() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Credits");
    }

    public void SelectPlane(int plane) {
        switch (plane) {
            case 1:
                aviao001.gameObject.SetActive(true);
                aviao002.gameObject.SetActive(false);
                aviao003.gameObject.SetActive(false);
                Debug.Log("Aviao 1");
                break;
            case 2:
                aviao001.gameObject.SetActive(false);
                aviao002.gameObject.SetActive(true);
                aviao003.gameObject.SetActive(false);
                break;
            case 3:
                aviao001.gameObject.SetActive(false);
                aviao002.gameObject.SetActive(false);
                aviao003.gameObject.SetActive(true);
                break;
        }
        
    }
}

