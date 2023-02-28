using UnityEngine;
using UnityEngine.UI;


public class playerMovimiento : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidad;
    private Rigidbody rb;
    public Camera camara;
    private Vector3 offset;
    public Text textoEstrella;
    public Text textoVida;
    private bool bIsAlive;
    private int iPuntuacion;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        offset = camara.transform.position;
        bIsAlive = true;
        iPuntuacion = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (bIsAlive)
        {
            float movHorizontal = Input.GetAxis("Horizontal");
            float movVertical = Input.GetAxis("Vertical");

            Vector3 movimiento = new Vector3(movHorizontal, 0.0f, movVertical);

            rb.AddForce(movimiento * velocidad);
            camara.transform.position = this.transform.position + offset;
            playDeathByFallSound();
        }
        else
        {
            //Te has muerto, play sound cambiar escena
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        //Colisiones con la trampa (muerte)
        if(other.CompareTag("Trampa"))
        {
            AudioSource audBSO = GameObject.FindWithTag("BSO").GetComponent<AudioSource>();

            AudioSource audMuerte = GameObject.FindWithTag("SonidoTrampa").GetComponent<AudioSource>();

            audBSO.Stop();
            audMuerte.Play();
            bIsAlive = false;
        }
        if(other.tag == "Premio")
        {
            iPuntuacion++;
        }
    }

    private void playDeathByFallSound()
    {
        GameObject goPlayer = GameObject.FindWithTag("Player");

        Vector3 v3PosJugador = goPlayer.transform.position;

        //Debug.Log(v3PosJugador.y);

        if(v3PosJugador.y < -10 && bIsAlive == true)
        {
            AudioSource audBSO =GameObject.FindWithTag("BSO").GetComponent<AudioSource>();
            AudioSource audMuerte = GameObject.FindWithTag("SonidoCaida").GetComponent<AudioSource>();
            audBSO.Stop();
            audMuerte.Play();
            bIsAlive = false;
        }

        
    }

}
