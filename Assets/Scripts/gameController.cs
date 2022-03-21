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
    bool startOrda = false;


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
    public int qtdOrdaAtual;
    public Transform spawnPosA;
    public Transform spawnPosB;
    public LayerMask isEnemy;
    public bool slotAIsBusy;
    public bool slotBIsBusy;
    public int qtdInimigosTela;

    [Header("Variaveis de acesso")]
    public playerController _playerController;
    public enemyController _enemyController;
 


    // Start is called before the first frame update
    void Start()
    {
        qtdTirosAtual = qtdMaxTiros;
        vidaAtual = vidaMax;

        StartCoroutine("spawnEnemy");
    }

    // Update is called once per frame
    void Update()
    {
        txtQuantidade.text = Pontuacao.ToString();

        verificaSlot();

        if(startOrda == false && qtdInimigosTela <= 0)
        {
            StartCoroutine("spawnEnemy");
        }

    }
    
    IEnumerator spawnEnemy()
    {
  
        //Sortei do inimigo
        qtdOrdaAtual = Random.Range(1, 6);

        startOrda = true;

        while(qtdOrdaAtual > 0)
        {
            yield return new WaitForSeconds(0.3f);
            int positionSpanw = Random.Range(1, 3);
            int enemyType = Random.Range(0, 3);

            
            if( qtdInimigosTela == 3)
            {
                yield return new WaitForSeconds(0.5f);
            }

            if (positionSpanw == 1)
            {
                //yield return new WaitForSeconds(1);
                GameObject temp = Instantiate(inimigoPrefab[enemyType]);
                temp.transform.position = spawnPosA.transform.position;
            }

            if (positionSpanw == 2)
            {
                //yield return new WaitForSeconds(1);
                GameObject temp = Instantiate(inimigoPrefab[enemyType]);
                temp.transform.position = spawnPosB.transform.position;
            }

            print(qtdOrdaAtual);
            qtdOrdaAtual -= 1;
            qtdInimigosTela += 1;


        }

        Debug.Log("<color=green>A Orda foi totalmente gerada!</color>");

        yield return new WaitForSeconds(2);
        startOrda = false;

    }

    

    IEnumerator GenerateEnemy()
    {
        int positionSpanw = Random.Range(1, 3);
        int enemyType = Random.Range(0, 3);

        GameObject temp = Instantiate(inimigoPrefab[enemyType]);

        if (positionSpanw == 1)
        {
            //yield return new WaitWhile(() => slotAIsBusy == false);
           
            temp.transform.position = spawnPosA.transform.position;
            qtdOrdaAtual -= 1;
            qtdInimigosTela += 1;
        }
        else if (positionSpanw == 2)
        {
            //yield return new WaitWhile(() => slotBIsBusy == false);
            
            temp.transform.position = spawnPosB.transform.position;
            qtdOrdaAtual -= 1;
            qtdInimigosTela += 1;
        }
        yield return new WaitForSeconds(0);

    }


    void verificaSlot()
    {
        slotAIsBusy = Physics2D.OverlapCircle(spawnPosA.transform.position, 0.35f, isEnemy);
        slotBIsBusy = Physics2D.OverlapCircle(spawnPosB.transform.position, 0.35f, isEnemy);
    }











    /*    
    IEnumerator SpawnInimigo()
    {
        yield return new WaitForSeconds(2);

        if (startOrda == false)
        {
            startOrda = true;
            qtdOrdaAtual = Random.Range(1, 10);
        }

        positionSpanw = Random.Range(1, 3);
        enemyType = Random.Range(0, 3);

        print(" Inimigo do tipo: " + enemyType + " na posição: " + positionSpanw);        

        yield return new WaitForSeconds(3);

        while (qtdOrdaAtual > 0)
        {
            if (positionSpanw == 1)
            {
                if (slotAIsBusy == false)
                {
                    GameObject temp = Instantiate(inimigoPrefab[enemyType]);
                    temp.transform.position = spawnPosA.transform.position;
                    qtdInimigosTela += 1;
                    qtdOrdaAtual -= 1;
                }

                else if (slotAIsBusy == true && slotBIsBusy == false)
                {
                    GameObject temp = Instantiate(inimigoPrefab[enemyType]);
                    temp.transform.position = spawnPosB.transform.position;
                    qtdOrdaAtual -= 1;
                    qtdInimigosTela += 1;
                }

                else if (slotAIsBusy == true && slotBIsBusy == true)
                {
                    yield return new WaitUntil(() => slotAIsBusy == false);
                    enemy.transform.position = spawnPosA.transform.position;
                    qtdOrdaAtual -= 1;
                    qtdInimigosTela += 1;
                }

            }
            if (positionSpanw == 2)
            {
                if (slotBIsBusy == false)
                {
                    GameObject temp = Instantiate(inimigoPrefab[enemyType]);
                    temp.transform.position = spawnPosB.transform.position;
                    qtdOrdaAtual -= 1;
                    qtdInimigosTela += 1;
                }

                else if (slotAIsBusy == false && slotBIsBusy == true)
                {
                    GameObject temp = Instantiate(inimigoPrefab[enemyType]);
                    temp.transform.position = spawnPosA.transform.position;
                    qtdOrdaAtual -= 1;
                    qtdInimigosTela += 1;
                }

                else if (slotAIsBusy == true && slotBIsBusy == true)
                {
                    yield return new WaitUntil(() => slotBIsBusy == false);
                    enemy.transform.position = spawnPosB.transform.position;
                    qtdOrdaAtual -= 1;
                    qtdInimigosTela += 1;
                }
            }

        }

        startOrda = false;

    }*/





}

