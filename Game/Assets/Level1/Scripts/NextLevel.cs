using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    //Funkcia sa vola po stlaceni tlacidla start
    private void Start()
    {
 
    }

    public void nextLevel()
    {
        //Level 2
        Debug.Log("Vymazat");
        DestroyAllDontDestroyOnLoadObjects();
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);
    }
    public void restartLevel()
    {
        //Level restart
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

    //treba premazat akumulatory lebo sa teleportuju do levelu2
    public void DestroyAllDontDestroyOnLoadObjects() {

        var go = new GameObject("Sacrificial Lamb");
        DontDestroyOnLoad(go);

        //Debug.Log("Amount of children in DontDestroyOnLoad: " + go.scene.rootCount);
        foreach (var root in go.scene.GetRootGameObjects()) {
            if (!((string.Equals(root.name, "Player") || string.Equals(root.name, "[ChaperoneInfo]")))) {
                Debug.Log("Name of child in DontDestroyOnLoad: " + root.name);
                Destroy(root);
            }
        }
    }
}
