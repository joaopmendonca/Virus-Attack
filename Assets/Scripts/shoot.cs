using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    //variaveis de acesso
    private Rigidbody2D tiroRb;
    private gameController _gameController;

    [Header("Configurações do Tiro")]
    public float velocidadeTiro;
    public float tempoRecarga;

    

    // Start is called before the first frame update
    void Start()
    {
        tiroRb = GetComponent<Rigidbody2D>();
        _gameController = FindObjectOfType(typeof(gameController)) as gameController;

        _gameController.qtdTirosAtual -= 1;
        StartCoroutine("destroyTiro");
    }

    // Update is called once per frame
    void Update()
    {
        tiroRb.velocity = new Vector2(velocidadeTiro,0);
    }

    IEnumerator destroyTiro()
    {
        yield return new WaitForSeconds(tempoRecarga);
        _gameController.qtdTirosAtual += 1;
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            _gameController.qtdTirosAtual += 1;
            Destroy(this.gameObject);
        }
    }
}
