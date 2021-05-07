using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonDown : MonoBehaviour
{
    public void LevelTransition(int level) {
        DestroyAllDontDestroyOnLoadObjects();
        /*Destroy(GameObject.Find("Cubes"));
        Destroy(GameObject.Find("Cubes2"));
        Destroy(GameObject.Find("Sabres"));
        Destroy(GameObject.Find("Grip"));
        Destroy(GameObject.Find("Grip"));
        Destroy(GameObject.Find("ViveController"));
        Destroy(GameObject.Find("ViveController (1)"));*/

        string Scenename = "level" + level.ToString();
        Debug.Log("Meno scenyyyy" + Scenename);

        //Level3 ma svojeho vlastneho playera z nejakeho dovodu
        if (string.Equals(Scenename, "level3")) {
            Destroy(GameObject.Find("Player"));
        }
        SceneManager.LoadScene(Scenename, LoadSceneMode.Single);
    }


    public void DestroyAllDontDestroyOnLoadObjects() {
        //we need an extra object to access the DontDestroyOnLoad scene
        var go = new GameObject("Sacrificial Lamb");
        DontDestroyOnLoad(go);

        //Debug.Log("Amount of children in DontDestroyOnLoad: " + go.scene.rootCount);
        foreach (var root in go.scene.GetRootGameObjects()) {
            if (!((string.Equals(root.name, "Player") || string.Equals(root.name, "[ChaperoneInfo]")))) {
                //Debug.Log("Name of the child in DontDestroyOnLoad: " + root.name);
                Destroy(root);
            }
        }
    }
}
