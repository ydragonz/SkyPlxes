using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TowerController : MonoBehaviour
{
    public float health = 500f;

    //public Slider healthSlider;
    public GameObject explosionSoundPrefab;
    public Slider healthSlider;
    public TextMeshProUGUI healthText;
    public Image targetImage;
    public bool isHit;




    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health;
        healthText.text = health.ToString()+"/"+healthSlider.maxValue.ToString();
        if(health <= 0)
        {
            Instantiate(explosionSoundPrefab, transform.position, Quaternion.identity);
            targetImage.enabled = false;
            Destroy(gameObject);
            
        }
    }

    

    void OnTriggerEnter(Collider other)
    {   

        if(other.gameObject.tag == "PlayerBullet")
        {
            health -= 5f;
            isHit = true;

        }
        if(other.gameObject.tag == "PlayerMissile")
        {
            health -= 250f;

        }
        
        
    }

}
