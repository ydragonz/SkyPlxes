using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{

    public GameObject explosionSoundPrefab;

    void OnTriggerEnter(Collider other)
    {
        Instantiate(explosionSoundPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
