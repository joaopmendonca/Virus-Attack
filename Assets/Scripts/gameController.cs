using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    [Header("Configura��es do Cen�rio")]
    public float limiteMinX;
    public float limiteMaxX;
    public float posicaoDestruir;
    public float larguraCenario;
    public GameObject cenarioPrefab;    

    [Header("Configura��es do Personagem")]
    public float velocidadeMovimento;

    [Header("Configura��es dos Inimigos")]
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
