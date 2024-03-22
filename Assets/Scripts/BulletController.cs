using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject gunHitSoundPrefab;


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Instantiate(gunHitSoundPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
        Destroy(gameObject);
    }
}
