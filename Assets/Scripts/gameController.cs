using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    [Header("Geral")]
    public int Pontuacao;

    [Header("Configurações do Cenário")]
    public float limiteMinX;
    public float limiteMaxX;
    public float posicaoDestruir;
    public float larguraCenario;
    public GameObject cenarioPrefab;
    public TextMeshProUGUI txtQuantidade;

    [Header("Configurações do Personagem")]
    public float velocidadeMovimento;
    public int qtdMaxTiros;
    public int qtdTirosAtual;

    [Header("Configurações dos Inimigos")]
    public float velocidadeObjeto;


    [Header("Variaveis de acesso")]
    public playerController _playerController;

    // Start is called before the first frame update
    void Start()
    {
       qtdTirosAtual = qtdMaxTiros;
    }

    // Update is called once per frame
    void Update()
    {
        txtQuantidade.text = Pontuacao.ToString();
    }
}
