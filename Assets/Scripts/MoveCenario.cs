using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCenario : MonoBehaviour
{
    private gameController _gameController;
    private Rigidbody2D cenarioRb;

    private bool instanciado;

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
        if(instanciado == false)
        {
            if(transform.position.x <= 0)
            {
                instanciado = true;
                GameObject temp = Instantiate(_gameController.cenarioPrefab);
                float posX = transform.position.x + _gameController.larguraCenario;
                float posY = transform.position.y;
                temp.transform.position = new Vector3(posX, posY,0);
            }
        }

        if(transform.position.x < _gameController.posicaoDestruir)
        {
            Destroy(this.gameObject);
        }
    }
}
