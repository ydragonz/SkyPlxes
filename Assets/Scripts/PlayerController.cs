using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float health = 100f;

    public Slider healthSlider;
    public GameObject explosionSoundPrefab;
    public AudioSource dmgSound;
    public TextMeshProUGUI healthText;
    public bool isHit;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health;
        healthText.text = health.ToString()+"/"+healthSlider.maxValue.ToString();
    }

    

    void OnTriggerEnter(Collider other)
    {   
        if(other.gameObject.tag == "Cenario" || other.gameObject.tag == "Barrier")
        {
            Instantiate(explosionSoundPrefab, transform.position, Quaternion.identity);
            isHit = true;
            health = 0;

            Destroy(gameObject);

        }
        if(other.gameObject.tag == "EnemySmallBullet")
        {
            health -= 2f;
            dmgSound.Play();
            isHit = true;
            Destroy(other.gameObject);
            if(health <= 0)
            {
                Instantiate(explosionSoundPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        
        
    }

    void LoadGameOverScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }
}
