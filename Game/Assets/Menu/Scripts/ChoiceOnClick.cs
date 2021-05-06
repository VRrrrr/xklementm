using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoiceOnClick : MonoBehaviour
{

    
    //Funkcia sa vola po stlaceni tlacidla start
    public void startGame()
    {

        Debug.Log("Starting coroutine...1");

        Destroy(GameObject.Find("Cubes"));
        Destroy(GameObject.Find("Cubes2"));
        Destroy(GameObject.Find("Sabres"));
        Destroy(GameObject.Find("Grip"));
        Destroy(GameObject.Find("Grip"));
        Destroy(GameObject.Find("ViveController"));
        Destroy(GameObject.Find("ViveController (1)"));

        //Level 1
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName("Level1"));

        Debug.Log("Starting coroutine...2");
        StartCoroutine(WaitForSceneLoad(SceneManager.GetSceneByName("Level1")));
        Debug.Log("Started coroutine...");

    }

    public IEnumerator WaitForSceneLoad(Scene scene) {
        while (scene.isLoaded) {
            Debug.Log("Setting active scene...");
            SceneManager.SetActiveScene(scene);
            yield return null;  //toto sposobi zacyklenie dovtedy dokym podmienka bude neplatna
        }
    }

    //Funkcia sa vola po stlaceni tlacidla napoveda
    public void startHelp()
    {
        
    }
    //Funkcia sa vola po stlaceni tlacidla ukoncit
    public void quitGame()
    {
        Application.Quit();
    }

}


