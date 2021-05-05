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
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);
    }
    public void restartLevel()
    {
        //Level restart
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }
}
