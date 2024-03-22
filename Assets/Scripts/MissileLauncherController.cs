using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MissileLauncherController : MonoBehaviour
{

    public float velocidade = 50f;
    public GameObject missile;
    public Transform missileLauncher;
    public float intervalo = 0.1f;
    public float forcaBala = 2f;
    public float ultimateMeter = 0f;
    public float ultimateMax = 10000f;

    public AudioSource somTiro;
    public Slider ultimateSlider;

    private float tempo;

    void Start()
    {
        
    }

    private void Update()
    {
        if(ultimateMeter<=ultimateMax)
        {
            ultimateMeter++;
            ultimateSlider.value = ultimateMeter;
        }

        //Verifica se a tecla Q esta precionada
        if (Input.GetKey(KeyCode.Q))
        {
            //Verifica se ultimate esta pronta
            if (ultimateMeter >= ultimateMax)
            {


                //incrmente o tempo do tiro
                tempo += Time.deltaTime;


                //verifica se o tempo decorrido � maior ou menor que o intervalo do termpo do tiro
                if (tempo >= intervalo)
                {

                    //instancia a bala pelo cano da metralhadora
                    GameObject novaBala = Instantiate(missile, missileLauncher.position, missileLauncher.rotation);

                    //ajusta a rota�� da bala, nem sempre � nescessario usar
                    novaBala.transform.Rotate(90, 0, 0);

                    //destroy a balapara ajuste da ememoria
                    Destroy(novaBala, 5);

                    //� uma boa pratica dar um get, pegar o componente de fisica da bala antes de usar
                    Rigidbody rb = novaBala.GetComponent<Rigidbody>();

                    //aplica uma for�a de impulso na bala
                    rb.AddForce(missileLauncher.forward * velocidade * forcaBala, ForceMode.Impulse);

                    //toca o som do tiro
                    somTiro.Play();

                    ultimateMeter = 0f;

                    //zera o intervalo de tempo 
                    tempo = 0f;
                }

            }

        }
        
        
        
    }
}
