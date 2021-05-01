using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject[] particles;
    public Text scoreDisplay;
    public Transform[] points;
    public float beat = 2 * (60 / 130);
    public float particleSpeed;

    private Particle particleScript;
    private float timer;    
    private int Score;
    private float upBorder;

    private int numberOfParticles;
    public int missCombo;
    public int missed;

    public bool gameover;

    public GameObject exitSpawner;
    private ExitSpawner exitSpawnerScript;


    // Start is called before the first frame update
    void Start()
    {
        setScore(0);
        upBorder = 0;
        numberOfParticles = 0;
        missCombo = 0;
        gameover = false;
        exitSpawnerScript = exitSpawner.GetComponent<ExitSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        //Hra beží až kým tri krát po sebe netrafíme časticu..
        if (missCombo < 3 && !gameover)
        {

            if (timer > beat)
            {
                particleSpeed = (float)(20 + Score) / 10f;
                GameObject particle = Instantiate(particles[Random.Range(0, 2)], points[Random.Range(0, 4)]);
                particleScript = particle.GetComponent<Particle>();

                Debug.Log("particle speed : " + (float)(20 + Score) / 10f);
                Debug.Log("beat speed : " + ((float)Random.Range(60, 120)) / 100f);
                Debug.Log("particle info: " + particle.tag);    //dava normnalneinfo



                //mozno tu by som mohla nastavovat tag tej danej partcile
                particle.transform.localPosition = Vector3.zero;
                particle.transform.Rotate(transform.forward, 90 * Random.Range(0, 4));
                timer -= beat;

                upBorder = (Score / 500f);
                beat = ((float)Random.Range(90, 110)) / 100f;
                beat -= upBorder;

            }
            timer += Time.deltaTime;
        }
        else
        {
            GameOver();
        }
    }


    //Vola sa pri zasahu 
    public void setScore(int score)
    {        
        Score = score;
        Debug.Log("score : " + Score);

        scoreDisplay.text = Score.ToString();
        numberOfParticles++;
        missCombo = 0;
    }

    public int getScore()
    {
        return Score;
    }

    void GameOver()
    {

        scoreDisplay.color = Color.green;
        exitSpawnerScript.exitLevel();
        gameover = true;

    }
}
