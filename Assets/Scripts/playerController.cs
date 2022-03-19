using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [Header("Propriedades do Player")]        
    public float positionX;
    public GameObject armaPosition;
    public GameObject tiroPrefab;
    public bool isShooting;
    public bool isGrounded;
    public Transform groundCheckPosition;
    public LayerMask whatIsGround;
    public float jumpForce;

    //variaveis de acesso
    private Rigidbody2D playerRb;
    private gameController _gameController;
    private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {              
        playerRb = GetComponent<Rigidbody2D>(); //acesso ao componente rigidbody2D
        playerAnimator = GetComponent<Animator>();
        _gameController = FindObjectOfType(typeof(gameController)) as gameController; //procura o script playerController
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal"); //Variaveis de input
        playerRb.velocity = new Vector2(h * _gameController.velocidadeMovimento, playerRb.velocity.y); //multiplica a propriedade velocity pelo valor do Getaxis para X. para Y mantem o valor atual.

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

        //Ataque!

        if (Input.GetButtonDown("Fire1") && isShooting == false)
        {
            if(_gameController.qtdTirosAtual > 0)
            {                
                isShooting = true;
                playerAnimator.SetTrigger("isShooting");
            }
        }

        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, 0.005f, whatIsGround); //sempre que houver uma colisão com o chão, isgrounded fica true

        //Animações

        if (Input.GetButton("Jump") && isGrounded == true)
        {
            jump();
        }

    }

    void jump()
    {         
        //_AudioController.playSFX(_AudioController.sfxJump, 1);
        playerRb.velocity = Vector2.up * jumpForce;
    }

    void shoot(int atk)
    {
        switch (atk)
        {
            case 0:
                isShooting = false;                
                break;

            case 1:
                //_AudioController.playSFX(_AudioController.sfxPlayerAtack, 1f);                
                GameObject temp = Instantiate(tiroPrefab);
                temp.transform.position = armaPosition.transform.position;                
                isShooting = true;
                break;
        }
    }
}
