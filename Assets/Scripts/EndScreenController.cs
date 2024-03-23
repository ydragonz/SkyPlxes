using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class EndScreenController : MonoBehaviour
{

    public TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText.text = PlayerPrefs.GetFloat("Score").ToString();
        
    }

    public void Retry() {
        SceneManager.LoadScene("MainScene");
    }

    public void Quit() {
        SceneManager.LoadScene("Menu");
    }



}
