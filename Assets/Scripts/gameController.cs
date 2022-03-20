using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    [Header("Geral")]
    public int Pontuacao;
    public int vidaMax;
    public int vidaAtual;
    
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
    public GameObject[] inimigoPrefab;
    public int qtdInimigosTela;


    [Header("Variaveis de acesso")]
    public playerController _playerController;
    public enemyController _enemyController;
    

    // Start is called before the first frame update
    void Start()
    {
        qtdTirosAtual = qtdMaxTiros;
        vidaAtual = vidaMax;
    }

    // Update is called once per frame
    void Update()
    {
        txtQuantidade.text = Pontuacao.ToString();
        StartCoroutine("SpawnInimigo");       
    }

    IEnumerator SpawnInimigo()
    {       

        bool Enemyspawned = false;

        if(Enemyspawned == false && qtdInimigosTela <= 0)
        {
            if (qtdInimigosTela < 0) { qtdInimigosTela = 0; }
            qtdInimigosTela += 1;
            yield return new WaitForSeconds(3);
            int enemyID = Random.Range(0, 1);

            print(enemyID);

            if (enemyID == 0)
            {
                GameObject temp = Instantiate(inimigoPrefab[enemyID]);
            }
        }       

    }
}
