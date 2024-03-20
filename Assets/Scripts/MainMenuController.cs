using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{

    [SerializeField] private GameObject creditos;
    [SerializeField] private GameObject menu;

    public void Jogar() {
        SceneManager.LoadScene("SampleScene");

    }

    public void Sair() {
        Application.Quit();
    }

    public void AbrirCreditos() {
        creditos.SetActive(true);
        menu.SetActive(false);
    }

    public void FecharCreditos() {
        creditos.SetActive(false);
        menu.SetActive(true);
    }

    public void ToggleMusic() {
        if (AudioListener.volume == 0) {
            AudioListener.volume = 1;
        } else {
            AudioListener.volume = 0;
        }
    }
}
