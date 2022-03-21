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
    public bool isDeath;
    public float velocidadeMedia;
    public float velocidadeAuta;

    public Color[] enemyColor;
    public bool isHit;
    public float tempoInvencível;

    [Header("Variaveis de acesso")]
    public Rigidbody2D enemyRb;
    public SpriteRenderer enemySpriteRender;
    public gameController _gameController;
    public Animator enemyAnimator;
    private AudioController _AudioController;

    // Start is called before the first frame update
    void Start()
    {
        vidaAtual = vidaMax;
        velocidadeAtual = velocidadeMax;
        _gameController = FindObjectOfType(typeof(gameController)) as gameController;
        _AudioController = FindObjectOfType(typeof(AudioController)) as AudioController;

        velocidadeAuta = velocidadeMax + 1f;
        velocidadeMedia = velocidadeMax + 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        enemyRb.velocity = new Vector2(velocidadeAtual * -1, enemyRb.velocity.y);
        positionX = transform.position.x;

        if (positionX < _gameController.limiteMinX && isDeath == false)
        {
            
            if (isDamage == false)
            {                
                isDamage = true;
                _gameController.vidaAtual -= 1;                
            }

        }

        if (_gameController.Pontuacao > 1000 && _gameController.Pontuacao < 2000)
        {
            velocidadeMax = velocidadeMedia;
            velocidadeAtual = velocidadeMax;
        }

        else if (_gameController.Pontuacao > 2000 && _gameController.Pontuacao < 3000)
        {
            velocidadeMax = velocidadeAuta;
            velocidadeAtual = velocidadeMax;
        }


    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Shoot") && isHit == false)
        {           
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
            if(isDeath == false)
            {
                isDeath = true;
                _AudioController.playSFX(_AudioController.sfxEnemyDie, 1f);
                isDeath = true;
                enemyAnimator.SetTrigger("isDead");

            }
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

    void DestroyMe()
    {        
        _gameController.Pontuacao += recompensa;
        _gameController.qtdInimigosTela -= 1;
        Destroy(this.gameObject);
    }


}
