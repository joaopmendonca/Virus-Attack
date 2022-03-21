using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FXTexto : MonoBehaviour
{
    public TextMeshProUGUI txtStart;
    public Color[] corTexto;
    bool pisquei = false;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (pisquei == false)
        {
            StartCoroutine("piscaTexto");
        }
    }

    IEnumerator piscaTexto()
    {
        pisquei = true;
        txtStart.color = corTexto[1];
        yield return new WaitForSeconds(0.5f);
        txtStart.color = corTexto[0];
        yield return new WaitForSeconds(0.5f);
        pisquei = false;    
              
    }
}
