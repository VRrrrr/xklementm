using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoiceOnClick : MonoBehaviour
{

    //Player a Player3 
    public void DestroyAllDontDestroyOnLoadObjects() {

        var go = new GameObject("Sacrificial Lamb");
        DontDestroyOnLoad(go);

        Debug.Log("size of children DontDestroyOnLoad: " + go.scene.rootCount);

        /*foreach (var root in go.scene.GetRootGameObjects()) {
            //if(string.Equals(root.name, "Player")) { }
            Debug.Log("Name of child in DontDestroyOnLoad: " + root.name);
        //Destroy(root);

        }*/

        //go.scene.rootCount je mnoztsvo deti sceny DontDestroyOnLoad
        //preskakujem prve dva prvky, lebo 1. je ChaperoneInfo a 2. je Player. kjtory musia zostat
        for (int i = 2; i < go.scene.rootCount; i++) {
            Debug.Log("Name of child in DontDestroyOnLoad: " + go.scene.GetRootGameObjects()[i].name);
            Destroy(go.scene.GetRootGameObjects()[i]);
        }
    }


    //Funkcia sa vola po stlaceni tlacidla start
    public void startGame()
    {
        //GameObject matafaka = GameObject.Find("DontDestroyOnLoad");
        //toto asi nejde
        //Debug.Log("pocety: " + matafaka.transform.childCount);
        /*for(int i = 0; i < matafaka.transform.childCount; i++) {
            Debug.Log("Name of child in DonbtDestroyOnLoad: " + matafaka.transform.GetChild(i).gameObject.name);
        }*/


        DestroyAllDontDestroyOnLoadObjects();


        /*Destroy(GameObject.Find("Cubes"));
        Destroy(GameObject.Find("Cubes2"));
        Destroy(GameObject.Find("Sabres"));
        Destroy(GameObject.Find("Grip"));
        Destroy(GameObject.Find("Grip"));
        Destroy(GameObject.Find("ViveController"));
        Destroy(GameObject.Find("ViveController (1)"));*/

     


        //Level 1
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
        StartCoroutine(WaitForSceneLoad(SceneManager.GetSceneByName("Level1")));

    }

    public IEnumerator WaitForSceneLoad(Scene scene) {
        while (scene.isLoaded) {
           // Debug.Log("Setting active scene...");
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


