using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

public class MoveController : MonoBehaviour
{
    [SerializeField] private float flySpeed;
    [SerializeField] private float yawAmount = 120f;
    private float yaw;
    private float currentPitch;
    private float currentRoll;
    private float pitchVelocity;
    private float rollVelocity;
    [SerializeField] private float smoothTime = 0.1f;

    // Update is called once per frame
    void Update()
    {
        //Movimentando o objeto
        transform.position += transform.forward * flySpeed * Time.deltaTime;

        //recebendo os imputs
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // yaw, pitch, roll
        yaw += horizontalInput * yawAmount * Time.deltaTime;
        float targetPitch = Mathf.Lerp(0, 20, Mathf.Abs(verticalInput)) * Mathf.Sign(verticalInput);
        float targetRoll = Mathf.Lerp(0, 30, Mathf.Abs(horizontalInput)) * -Mathf.Sign(horizontalInput);

        // Smooth the pitch and roll
        currentPitch = Mathf.SmoothDamp(currentPitch, targetPitch, ref pitchVelocity, smoothTime);
        currentRoll = Mathf.SmoothDamp(currentRoll, targetRoll, ref rollVelocity, smoothTime);

        //Aplicando 
        transform.localRotation = Quaternion.Euler(Vector3.up * yaw + Vector3.right * currentPitch + Vector3.forward * currentRoll);
    }
}