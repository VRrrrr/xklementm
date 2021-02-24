using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParticleMiss : MonoBehaviour
{
    int missed = 0;
    bool gameOver;

    public Text gameOverMsg;
    public GameObject spawner;
    private Spawner spawnerParams;


    private void Start()
    {
        spawnerParams = spawner.GetComponent<Spawner>();
        gameOver = false;
    }

    private void Update()
    {
        if (!gameOver && spawnerParams.gameover)
        {
            gameOverMsg.text = "Hra skončila!";
        }
    }

    private void OnCollisionEnter(Collision collision)
    {       
        missed++;
        spawnerParams.missCombo++;
        Destroy(collision.gameObject);
    }
}

