using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pulsar : MonoBehaviour
{
    private Button btn;
    private bool bContar;
    private int iNumero;
    public Text txtNum;
    public Image img;
    public Sprite[] spraImgNumeros;

    // Start is called before the first frame update
    void Start()
    {
        btn = GameObject.FindWithTag("tgBtnPulsar").GetComponent<Button>();
        //txtNum = GameObject.FindWithTag("txt3").GetComponent<Text>();

        btn.onClick.AddListener(Pulsado);
        bContar = false;
        iNumero = 0;
        img.sprite = spraImgNumeros[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (bContar && iNumero < 3)
        {
            img.sprite = spraImgNumeros[iNumero];
            txtNum.text = "" + (3 - iNumero);
            iNumero++;
            StartCoroutine(Esperar());
            bContar = false;

        }
    }

    void Pulsado()
    {
        img.gameObject.SetActive(true);
        bContar = true;
        btn.gameObject.SetActive(false);
        
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(1);
        bContar = true;
    }
}
