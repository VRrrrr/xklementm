using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ChoiceBall>() != null) {
            Debug.Log("Ring has been hit by ball");
           // Debug.Log("I'm attached to " + gameObject.name);

            // gameObject.name -> dostaneme meno objektu ku ktory je prepojeny so scriptom
            if(gameObject.name == "target1")
            {
                //Level 1
                SceneManager.LoadScene("Scene1", LoadSceneMode.Additive);
            }
            else if(gameObject.name == "target2")
            {
                //Level 2
              // SceneManager.LoadScene("Scene1", LoadSceneMode.Additive);
            }
            else if(gameObject.name == "target3")
            {
                //Level 3
                //SceneManager.LoadScene("Scene1", LoadSceneMode.Additive);
            }


        }
    }
}
