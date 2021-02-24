using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Saber : MonoBehaviour
{
    public LayerMask layer;
    private Vector3 previousPos;

    public GameObject spawner;
    private Spawner spawnerScript;


    // Start is called before the first frame update
    void Start()
    {
        spawnerScript = spawner.GetComponent<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.forward,out hit, 1, layer))
        {
            if(Vector3.Angle(transform.position - previousPos,hit.transform.up) > 130)
            {

                UnityEngine.Debug.Log(hit.transform.gameObject.name);
                if(hit.transform.gameObject.name == "Restart")
                {
                    SceneManager.LoadScene("Level3", LoadSceneMode.Single);
                }
                else if (hit.transform.gameObject.name == "Exit")
                {
                    if ((Application.isEditor))
                    {
                        Scene menu = SceneManager.GetSceneByName("Menu");

                        GameObject[] allObjects = FindObjectsOfType<GameObject>();
                        SceneManager.SetActiveScene(menu);
                      
                        foreach (GameObject item in allObjects)
                        {
                            if(item.name != "Player")
                            Destroy(item);
                        }
                        SceneManager.LoadScene("ReturnMenu", LoadSceneMode.Single);

                    }
                    else
                    {
                        Process.Start(Application.dataPath + "/../Game.exe");
                        Application.Quit();
                    }
                    
                }
                else
                {
                    Destroy(hit.transform.gameObject);
                    //Jeden zasah 
                    spawnerScript.setScore(spawnerScript.getScore() + 1);
                }
                
                
            }      

        }
        previousPos = transform.position;
    }

  
}
