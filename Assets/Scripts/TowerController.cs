using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerController : MonoBehaviour
{
    public float health = 100f;

    public Slider healthSlider;
    public GameObject explosionSoundPrefab;




    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health;
    }

    

    void OnTriggerEnter(Collider other)
    {   

        if(other.gameObject.tag == "PlayerBullet")
        {
            health -= 1f;
            Destroy(other.gameObject);
            if(health <= 0)
            {
                Instantiate(explosionSoundPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        
        
    }

}
