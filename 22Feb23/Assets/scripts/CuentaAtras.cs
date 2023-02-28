using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CuentaAtras : MonoBehaviour
{

    public Button btn;
    public Sprite[] numeros;
    private int mostrar;
    private bool contar;
    public Text textoContador;
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(Pulsado);
        contar = false;
        mostrar = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        if (contar){
            switch(mostrar){
                case 0: SceneManager.LoadScene("Escena2", LoadSceneMode.Single);
                        break;
                case 1: textoContador.text = "1"; 
                        break;
                case 2: textoContador.text = "2"; 
                        break;
                case 3: textoContador.text = "3"; 
                        break;
            }
        StartCoroutine(Esperar());
        contar = false;
        mostrar--;
        }
    }

    IEnumerator Esperar(){
        yield return new WaitForSeconds(1);
        contar = true;
    }

    void Pulsado(){
        textoContador.gameObject.SetActive(true);
        btn.gameObject.SetActive(false);
        contar = true;
    }
}
