using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    // Start is called before the first frame update
    bool open = false;
    

    void Start()
    {
        Debug.Log(this.gameObject.name);    
    }


    // Update is called once per frame
    private void Update()
    {
        if (open && transform.position.x < 5)
        {
            transform.position += Time.deltaTime * transform.right * 1.2f;
        }
    }

    public void Open()
    {
        open = true;

        


        
        
    }
}
