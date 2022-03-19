using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [Header("Propriedades do Player")]        
    public float positionX;

    //variaveis de acesso
    private Rigidbody2D playerRb;
    private gameController _gameController;

    // Start is called before the first frame update
    void Start()
    {              
        playerRb = GetComponent<Rigidbody2D>(); //acesso ao componente rigidbody2D
        _gameController = FindObjectOfType(typeof(gameController)) as gameController; //procura o script playerController
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); //Variaveis de input
        playerRb.velocity = new Vector2(horizontal * _gameController.velocidadeMovimento, playerRb.velocity.y); //multiplica a propriedade velocity pelo valor do Getaxis para X. para Y mantem o valor atual.

        positionX = transform.position.x;
        
        //Verifica Posição do Player

        if (positionX < _gameController.limiteMinX)
        {
            transform.position = new Vector2(_gameController.limiteMinX, transform.position.y);
        }

        else if (positionX >= _gameController.limiteMaxX)
        {
            transform.position = new Vector2(_gameController.limiteMaxX, transform.position.y);
        }


    }
}
