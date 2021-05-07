﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoiceOnClick : MonoBehaviour
{
    //Funkcia sa vola po stlaceni tlacidla start
    public void startGame()
    {
        DestroyAllDontDestroyOnLoadObjects();
        //Level 1
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
        StartCoroutine(WaitForSceneLoad(SceneManager.GetSceneByName("Level1")));
    }

    public void DestroyAllDontDestroyOnLoadObjects() {

        var go = new GameObject("Sacrificial Lamb");
        DontDestroyOnLoad(go);

        //Debug.Log("Amount of children in DontDestroyOnLoad: " + go.scene.rootCount);
        foreach (var root in go.scene.GetRootGameObjects()) {
            if (!((string.Equals(root.name, "Player") || string.Equals(root.name, "[ChaperoneInfo]")))) {
                //Debug.Log("Name of child in DontDestroyOnLoad: " + root.name);
                Destroy(root);
            }
        }
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


