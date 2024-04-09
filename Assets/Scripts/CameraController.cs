/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset; // Distância entre a câmera e o jogador
    [SerializeField] private Vector3 rotationOffset; // Offset de rotação
    [SerializeField] private float smoothTime = 0.3f; // Tempo de suavização

    private Quaternion rotationOffsetQuaternion;
    private Vector3 velocity = Vector3.zero; // Velocidade atual

    // Start is called before the first frame update
    void Start()
    {
        rotationOffsetQuaternion = Quaternion.Euler(rotationOffset);
    }

    // Update is called once per frame
    void Update()
    {
        // Cria uma nova rotação que usa o ângulo de guinada do jogador, mas usa um ângulo de inclinação fixo
        Quaternion rotation = Quaternion.Euler(player.eulerAngles.x, player.eulerAngles.y, rotationOffset.z);

        // Aplica o offset de rotação
        rotation *= rotationOffsetQuaternion;

        transform.rotation = rotation;

        // Calcula a posição desejada
        Vector3 desiredPosition = player.position - transform.forward * offset.magnitude;
        desiredPosition += transform.up * offset.y;

        // Interpola suavemente entre a posição atual da câmera e a posição desejada
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform enemy; // Referência ao inimigo
    [SerializeField] private Vector3 offset; // Distância entre a câmera e o jogador
    [SerializeField] private Vector3 rotationOffset; // Offset de rotação
    [SerializeField] private float smoothTime = 0.3f; // Tempo de suavização

    private Quaternion rotationOffsetQuaternion;
    private Vector3 velocity = Vector3.zero; // Velocidade atual

    // Start is called before the first frame update
    void Start()
    {
        rotationOffsetQuaternion = Quaternion.Euler(rotationOffset);
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            // Calcula a posição desejada
            Vector3 desiredPosition = player.position - transform.forward * offset.magnitude;
            desiredPosition += transform.up * offset.y;

            // Interpola suavemente entre a posição atual da câmera e a posição desejada
            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
        }

        // Faz a câmera olhar para o inimigo
        if (enemy != null)
        {
            transform.LookAt(enemy);
        }
    }
}