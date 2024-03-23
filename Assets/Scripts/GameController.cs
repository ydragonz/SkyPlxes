using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{


    public PlayerController player;
    public TowerController enemy;
    public float score;
    public float scoreMultiplier = 1.0f;
    public TextMeshProUGUI scoreText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.health <= 0)
        {
            Invoke("LoadVictoryScene", 2.0f);
        }
        if(player.health <= 0)
        {
            Invoke("LoadGameOverScene", 2.0f);
        }
        if(player.isHit)
        {
            scoreMultiplier = 1.0f;
            player.isHit = false;
        } else {
            if(enemy.isHit)
            {
                score += 10 * scoreMultiplier;
                scoreMultiplier += 0.1f;
                enemy.isHit = false;
            }
        }
        scoreText.text = score.ToString();
    }

    void LoadGameOverScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }

    void LoadVictoryScene()
    {   
        PlayerPrefs.SetFloat("Score", score);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Victory");
    }
}
