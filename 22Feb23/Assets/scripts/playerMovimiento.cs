using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

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
    public Text txtPuntuacion;
    private Vector3 v3PosicionJugador;


    void Start()
    {
        StartCoroutine(killerFunction());
        rb = GetComponent<Rigidbody>();
        offset = camara.transform.position;
        bIsAlive = true;
        iPuntuacion = 0;
        v3PosicionJugador.z = 0;
        txtPuntuacion.text = "Puntuacion: 0";
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

            GameObject goPlayer = GameObject.FindWithTag("Player");
            Vector3 v3PosJugadorActual = goPlayer.transform.position;

            if(v3PosJugadorActual.z >= (v3PosicionJugador.z + 3)){
                iPuntuacion++;
                v3PosicionJugador.z = v3PosJugadorActual.z;
            }
            //Act Valor Text
            txtPuntuacion.text = "Puntuacion: " + iPuntuacion;



        }
        else
        {
           killerFunction();
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        //Colisiones con la trampa (muerte)
        Debug.Log(other.tag);
        if(other.CompareTag("Trampa"))
        {
            AudioSource audBSO = GameObject.FindWithTag("BSO").GetComponent<AudioSource>();

            AudioSource audMuerte = GameObject.FindWithTag("SonidoTrampa").GetComponent<AudioSource>();

            audBSO.Stop();
            audMuerte.Play();
            bIsAlive = false;

            killerFunction();
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

    IEnumerator killerFunction()
    {
        yield return new WaitForSeconds(8); // Espera 5 segundos
        SceneManager.LoadScene("EscenaPerdedor", LoadSceneMode.Single);//Te has muerto, play sound cambiar escena
    }

}
