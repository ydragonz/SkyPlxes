using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float xPos;
    [SerializeField] private float yPos;
    [SerializeField] private float zPos;


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x + xPos, player.position.y + yPos, player.position.z + zPos);
    }
}
