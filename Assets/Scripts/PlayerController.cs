using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float health = 100f;

    public Slider healthSlider;
    public GameObject explosionSoundPrefab;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health;
    }

    

    void OnTriggerEnter(Collider other)
    {   
        if(other.gameObject.tag == "Cenario")
        {
            Instantiate(explosionSoundPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Invoke("LoadGameOverScene", 2.0f);
        }
        if(other.gameObject.tag == "EnemySmallBullet")
        {
            health -= 10f;
            Destroy(other.gameObject);
            if(health <= 0)
            {
                Instantiate(explosionSoundPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
                Invoke("LoadGameOverScene", 2.0f);
            }
        }
        
        
    }

    void LoadGameOverScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }
}
