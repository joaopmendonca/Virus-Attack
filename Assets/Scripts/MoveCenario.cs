using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCenario : MonoBehaviour
{
    private gameController _gameController;
    private Rigidbody2D cenarioRb;

    private bool cenarioInstanciado;

    // Start is called before the first frame update
    void Start()
    {
        _gameController = FindObjectOfType(typeof(gameController)) as gameController;
        cenarioRb = GetComponent<Rigidbody2D>();
        cenarioRb.velocity = new Vector2(_gameController.velocidadeObjeto, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (cenarioInstanciado == false)
        {
            if (transform.position.x <= 0)
            {
                cenarioInstanciado = true;
                GameObject temp = Instantiate(_gameController.cenarioPrefab);
                temp.transform.position = new Vector3(transform.position.x + _gameController.larguraCenario, transform.position.y, 0); //soma a largura com a posição atual para compensar e não ficar brechas.
            }
        }

        if(transform.position.x < _gameController.posicaoDestruir)
        {
            Destroy(this.gameObject);
        }
     
    }
}
