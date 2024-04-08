using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{

    [SerializeField] private GameObject creditos;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject botaoMusica;
    [SerializeField] private Sprite musicaDesligada;
    [SerializeField] private Sprite musicaLigada;

    public void Jogar() {
        SceneManager.LoadScene("MainScene");

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
            botaoMusica.GetComponent<Image>().sprite = musicaLigada;
            
            
        } else {
            AudioListener.volume = 0;
            botaoMusica.GetComponent<Image>().sprite = musicaDesligada;
        }
    }
    
}
