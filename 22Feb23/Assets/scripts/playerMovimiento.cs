using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerMovimiento : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidad;
    private Rigidbody rb;
    public Camera camara;
    private Vector3 offset;
    public Text textoEstrella;
    public Text textoVida;
    public AudioClip audMuerteTrampa;
    public AudioClip audMuerteCaida;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        offset = camara.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float movHorizontal = Input.GetAxis("Horizontal");
        float movVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movHorizontal, 0.0f, movVertical);

        rb.AddForce(movimiento * velocidad);
        camara.transform.position = this.transform.position + offset;
    }

    private void OnTriggerEnter(Collider other)
    {

    }

    private void playDeathByFallSound()
    {
        GameObject goPlayer = GameObject.FindWithTag("Player");

        Vector3 v3PosJugador = goPlayer.transform.position;
    }

}
