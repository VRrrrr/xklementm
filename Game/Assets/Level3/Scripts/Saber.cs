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
                    UnityEngine.Debug.Log("RESTART RESTART");

                    SceneManager.LoadScene("Level3", LoadSceneMode.Single);
                }
                else if (hit.transform.gameObject.name == "Exit")
                {
                    UnityEngine.Debug.Log("Saber tag: " + hit.transform.gameObject.tag);
                    UnityEngine.Debug.Log("Saber name: " + hit.transform.gameObject.name);
                    UnityEngine.Debug.Log("Saber layer: " + hit.transform.gameObject.layer);



                    if ((Application.isEditor))
                    {

                        SceneManager.LoadScene("Menu", LoadSceneMode.Single);

                        Scene menu = SceneManager.GetSceneByName("Menu");

                        GameObject[] allObjects = FindObjectsOfType<GameObject>();
                        SceneManager.SetActiveScene(menu);
                      
                        foreach (GameObject item in allObjects)
                        {
                            if(item.name != "Player")
                            Destroy(item);
                        }
                        UnityEngine.Debug.Log("EXIT load menu");

                    } else
                    {
                        UnityEngine.Debug.Log("EXIT Application quit");

                        Process.Start(Application.dataPath + "/../Game.exe");
                        Application.Quit();
                    }
                    
                }
                else if(hit.transform.gameObject.tag == "Positive" || hit.transform.gameObject.tag == "Negative")
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
