using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    [Header("Configurações do inimigo")]
    public int vidaMax;
    public int vidaAtual;
    public float velocidadeMax;
    public float velocidadeAtual;
    public int recompensa;
    public float positionX;
    bool isDamage;


    public Color[] enemyColor;
    public bool isHit;
    public float tempoInvencível;

    [Header("Variaveis de acesso")]
    public Rigidbody2D enemyRb;
    public SpriteRenderer enemySpriteRender;
    public gameController _gameController;

    // Start is called before the first frame update
    void Start()
    {
        vidaAtual = vidaMax;
        velocidadeAtual = velocidadeMax;
        _gameController = FindObjectOfType(typeof(gameController)) as gameController;
    }

    // Update is called once per frame
    void Update()
    {
        enemyRb.velocity = new Vector2(velocidadeAtual * -1, enemyRb.velocity.y);
        positionX = transform.position.x;

        if (positionX < _gameController.limiteMinX)
        {
            
            if (isDamage == false)
            {
                isDamage = true;
                _gameController.vidaAtual -= 1;
                print(_gameController.vidaAtual);
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Shoot") && isHit == false)
        {
            print("inimigo atingido");
            StartCoroutine("getHit");
        }
    }

    IEnumerator getHit()
    {
        vidaAtual -= 1;
        enemySpriteRender.color = enemyColor[1];

        isHit = true;

        if (vidaAtual <= 0)
        {
            _gameController.Pontuacao += recompensa;
            _gameController.qtdInimigosTela -= 1;
            Destroy(this.gameObject);
        }

        else
        {
            velocidadeAtual /= 2;
            
            yield return new WaitForSeconds(tempoInvencível);
            
        }

        velocidadeAtual = velocidadeMax;
        isHit = false;
        enemySpriteRender.color = enemyColor[0];        

    }


}
