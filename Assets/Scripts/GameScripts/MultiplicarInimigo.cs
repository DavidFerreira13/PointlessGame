using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplicarInimigo : MonoBehaviour
{
    public GameObject boiiiii;
    public Transform enemyPos;
    private float repeatRate = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            InvokeRepeating("EnemySpawner", 0f, repeatRate);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    void EnemySpawner()
    {
        Instantiate(boiiiii, enemyPos.position, enemyPos.rotation);
    }
}
