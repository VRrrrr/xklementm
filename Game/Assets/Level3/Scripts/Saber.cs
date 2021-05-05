using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;


public class Saber : MonoBehaviour
{
    public LayerMask layer;
    private Vector3 previousPos;

    public GameObject spawner;
    private Spawner spawnerScript;

    public SteamVR_Action_Vibration hapticAction;//todo


    void Start(){
        spawnerScript = spawner.GetComponent<Spawner>();
    }

    void Update(){
        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.forward,out hit, 1, layer)){
            if(Vector3.Angle(transform.position - previousPos,hit.transform.up) > 130){
                if(hit.transform.gameObject.name == "Restart"){
                    Pulse(0.1f, 100, 1.0f, SteamVR_Input_Sources.LeftHand);
                    GameObject[] allObjects = FindObjectsOfType<GameObject>();
                    foreach (GameObject item in allObjects) {
                        Destroy(item);
                    }

                    SceneManager.LoadScene("Level3", LoadSceneMode.Single);
                }
                else if (hit.transform.gameObject.name == "Exit"){
                    if ((Application.isEditor)){
                        Pulse(0.1f, 100, 1.0f, SteamVR_Input_Sources.RightHand);
                        //Scene menu = SceneManager.GetSceneByName("Menu");
                        GameObject[] allObjects = FindObjectsOfType<GameObject>();
                        UnityEngine.Debug.Log("EXIT load menu3");

                        foreach (GameObject item in allObjects){
                            Destroy(item);
                        }
                        UnityEngine.Debug.Log("EXIT load menu4");
                        
                        
                        //todo korutinu
                        //SceneManager.SetActiveScene(menu);


                        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
                        UnityEngine.Debug.Log("Starting coroutine...1");
                        StartCoroutine(WaitForSceneLoad(SceneManager.GetSceneByName("Menu")));
                        UnityEngine.Debug.Log("Started coroutine...2");


                    } else{
                        Process.Start(Application.dataPath + "/../Game.exe");
                        Application.Quit();
                    }
                }
                else if(hit.transform.gameObject.tag == "Negative") {
                    Pulse(0.1f, 100, 1.0f, SteamVR_Input_Sources.LeftHand);
                    Destroy(hit.transform.gameObject);
                    spawnerScript.setScore(spawnerScript.getScore() + 1);
                } 
                else if (hit.transform.gameObject.tag == "Positive") {
                    Pulse(0.1f, 100, 1.0f, SteamVR_Input_Sources.RightHand);
                    Destroy(hit.transform.gameObject);
                    spawnerScript.setScore(spawnerScript.getScore() + 1);
                }
            }      
        }
        previousPos = transform.position;
    }

    private void Pulse(float duration, float frequency, float amplitude, SteamVR_Input_Sources source) {
        hapticAction.Execute(0, duration, frequency, amplitude, source);
    }

    public IEnumerator WaitForSceneLoad(Scene scene) {
        while (scene.isLoaded) {
            UnityEngine.Debug.Log("Setting active scene...");
            SceneManager.SetActiveScene(scene);
            yield return null;  //toto sposobi zacyklenie dovtedy dokym podmienka bude neplatna
        }
    }
}
