using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnSlot : MonoBehaviour
{
    public bool isBusy;
    public LayerMask isEnemy;
    public GameObject Enemyslot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        verificaSlot();
    }

    void verificaSlot()
    {
        isBusy = Physics2D.OverlapCircle(transform.position, 0.2f, isEnemy);
    }
}
