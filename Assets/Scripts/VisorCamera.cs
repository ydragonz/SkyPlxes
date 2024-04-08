using UnityEngine;
using System.Collections;

public  class VisorCamera : MonoBehaviour
{
    [SerializeField] private Transform targetAviao;
    [SerializeField] private float velocidadeVisor;
    [SerializeField] private Transform pivot;

    //PUBLIC VARIABLES
    public float velocidadeBala = 100f;
    public GameObject bala;
    public Transform cano;
    public float intervalo = 0.1f;
    public float forçaBala = 2f;
    public float downTime = 2f;
    public float downInterval = 5f;

    private float tempo;
    private bool canShoot = false;

    private void Start()
    {
        StartCoroutine(StartShooting());
    }

    private IEnumerator StartShooting()
    {
        yield return new WaitForSeconds(4.0f);
        canShoot = true;
        while (true)
        {
            yield return new WaitForSeconds(downInterval);
            canShoot = false;

            StartCoroutine(RotateDown());
            yield return new WaitForSeconds(downTime);
            canShoot = true;
        }
    }
    private IEnumerator RotateDown()
    {
        float elapsedTime = 0;
        float rotateTime = 1f; // Adjust this to change the speed of rotation
        Quaternion startingRotation = pivot.rotation;
        Quaternion targetRotation = Quaternion.Euler(45, 0, 0); // Adjust this to the target rotation

        while (elapsedTime < rotateTime)
        {
            pivot.rotation = Quaternion.Lerp(startingRotation, targetRotation, elapsedTime / rotateTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        pivot.rotation = targetRotation;
    }

    private void Update()
    {
        //calcula a distancia entre objeto e camera
        Vector3 directionTarget= targetAviao.position - transform.position;
        Debug.Log(directionTarget);

        //calcula a rotacao para olhar para o objeto
        Quaternion targetRotation = Quaternion.LookRotation(directionTarget);

        //olha o objeto de forma suave
        pivot.rotation = Quaternion.Slerp(pivot.rotation, targetRotation, velocidadeVisor * Time.deltaTime);

        //incrmente o tempo do tiro
        tempo += Time.deltaTime;

        //verifica se o tempo decorrido é maior ou menor que o intervalo do termpo do tiro
        if(tempo >= intervalo && canShoot)
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
            rb.AddForce(cano.forward * velocidadeBala * forçaBala, ForceMode.Impulse);

            //zera o intervalo de termpo 
            tempo = 0f;
        }
    }
    
}