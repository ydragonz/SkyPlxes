using UnityEngine;

public  class VisorCamera : MonoBehaviour
{
    [SerializeField] private Transform targetAviao;
    [SerializeField] private float velocidadeVisor;

    //PUBLIC VARIABLES
    public float velocidadeBala = 100f;
    public GameObject bala;
    public Transform cano;
    public float intervalo = 0.1f;
    public float forçaBala = 2f;

    //PRIVATE VARIABLES
    private float tempo;

    private void Update()
    {
        //calcula a distancia entre objeto e camera
        Vector3 directionTarget= targetAviao.position - transform.position;
        Debug.Log(directionTarget);

        //calcula a rotacao para olhar para o objeto
        Quaternion targetRotation = Quaternion.LookRotation(directionTarget);

        //olha o objeto de forma suave
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, velocidadeVisor * Time.deltaTime);

        //incrmente o tempo do tiro
        tempo += Time.deltaTime;

        //verifica se o tempo decorrido é maior ou menor que o intervalo do termpo do tiro
        if(tempo >= intervalo)
        {
            //instancia a bala pelo cano da metralhadora
            GameObject novaBala = Instantiate(bala, cano.position, cano.rotation);

            //ajusta a rotaçã da bala, nem sempre é nescessario usar
            novaBala.transform.Rotate(90,0,0);

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