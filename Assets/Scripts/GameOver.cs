using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI txtQtdePontos;

    public gameController _gameController;

    // Start is called before the first frame update
    void Start()
    {
        _gameController = FindObjectOfType(typeof(gameController)) as gameController;
       
    }

    // Update is called once per frame
    void Update()
    {
        txtQtdePontos.text = _gameController.Pontuacao.ToString();
    }
}
