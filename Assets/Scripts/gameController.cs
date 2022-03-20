using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    [Header("Geral")]
    public int Pontuacao;

    [Header("Configura��es do Cen�rio")]
    public float limiteMinX;
    public float limiteMaxX;
    public float posicaoDestruir;
    public float larguraCenario;
    public GameObject cenarioPrefab;
    public TextMeshProUGUI txtQuantidade;

    [Header("Configura��es do Personagem")]
    public float velocidadeMovimento;
    public int qtdMaxTiros;
    public int qtdTirosAtual;

    [Header("Configura��es dos Inimigos")]
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
