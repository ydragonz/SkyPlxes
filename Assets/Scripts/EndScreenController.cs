using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class EndScreenController : MonoBehaviour
{


    public void Retry() {
        SceneManager.LoadScene("MainScene");
    }

    public void Quit() {
        SceneManager.LoadScene("Menu");
    }



}
