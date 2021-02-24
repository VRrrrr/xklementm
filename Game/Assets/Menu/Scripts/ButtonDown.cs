using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonDown : MonoBehaviour
{
    public void LevelTransition(int level)
    {
        Destroy(GameObject.Find("Cubes"));
        Destroy(GameObject.Find("Cubes2"));
        Destroy(GameObject.Find("Sabres"));

        string Scenename = "level" + level.ToString();
        SceneManager.LoadScene(Scenename, LoadSceneMode.Single);
    }           
}
