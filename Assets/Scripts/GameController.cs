using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{


    public PlayerController player;
    public TowerController enemy;

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
    }

    void LoadGameOverScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }

    void LoadVictoryScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Victory");
    }
}
