using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    [Header("Configurações do Cenário")]
    public float limiteMinX;
    public float limiteMaxX;
    public float posicaoDestruir;
    public float larguraCenario;
    public GameObject cenarioPrefab;    

    [Header("Configurações do Personagem")]
    public float velocidadeMovimento;

    [Header("Configurações dos Inimigos")]
    public float velocidadeObjeto;
    

    //acesso externo
    private playerController _playerController;

    // Start is called before the first frame update
    void Start()
    {
        _playerController = FindObjectOfType(typeof(playerController)) as playerController; //procura o script playerController
    }

    // Update is called once per frame
    void Update()
    {       
        
    }
}
