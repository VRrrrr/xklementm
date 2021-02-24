using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerOpen : MonoBehaviour
{
    public GameObject[] drawerComponents;
    private bool open = false;

    public void Open()
    {
        if (!open) { 
            gameObject.transform.position += new Vector3(0, 0, 0.5f);                        

            foreach (GameObject Object in drawerComponents)
            {
                Object.transform.position += new Vector3(0, 0, 0.5f);
            }
            open = true;
        }
    }
}
