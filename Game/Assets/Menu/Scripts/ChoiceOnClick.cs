using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoiceOnClick : MonoBehaviour
{

    
    //Funkcia sa vola po stlaceni tlacidla start
    public void startGame()
    {

      
        Destroy(GameObject.Find("Cubes"));
        Destroy(GameObject.Find("Cubes2"));
        Destroy(GameObject.Find("Sabres"));
        //Level 1
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Level1"));
        

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


