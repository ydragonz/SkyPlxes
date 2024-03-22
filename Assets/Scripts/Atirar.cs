using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Atirar : MonoBehaviour
{
    //PUBLIC VARIABLES
    public float velocidade = 100f;
    public GameObject bala;
    public Transform cano;
    public float intervalo = 0.1f;
    public float forçaBala = 2f;

    public AudioSource somTiro;


    //PRIVATE VARIABLES
    private float tempo;

    void Start()
    {
        //pega o componente de audio do objeto
        somTiro = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //Verifica se a tecla Espaço esta precionada
        if(Input.GetKey(KeyCode.Space))
        {
            //toca o som do tiro
            if(!somTiro.isPlaying)
            {
                somTiro.Play();
            }

            //incrmente o tempo do tiro
            tempo += Time.deltaTime;

            //verifica se o tempo decorrido é maior ou menor que o intervalo do termpo do tiro
            if(tempo >= intervalo)
            {
                

                //instancia a bala pelo cano da metralhadora
                GameObject novaBala = Instantiate(bala, cano.position, cano.rotation);

                //ajusta a rotaçã da bala, nem sempre é nescessario usar
                novaBala.transform.Rotate(180,0,0);

                //destroy a balapara ajuste da ememoria
                Destroy(novaBala, 5);

                //é uma boa pratica dar um get, pegar o componente de fisica da bala antes de usar
                Rigidbody rb = novaBala.GetComponent<Rigidbody>();

                //aplica uma força de impulso na bala
                rb.AddForce(cano.forward * velocidade * forçaBala, ForceMode.Impulse);

                //zera o intervalo de tempo 
                tempo = 0f;
            }

        } else {
            if(somTiro.isPlaying)
            {
                Invoke("PararSomTiro", 0.1f);
            }
        }
        



    }

    private void PararSomTiro()
    {

        somTiro.Stop();

    }

}



