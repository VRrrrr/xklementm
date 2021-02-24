using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchematicOnPut : MonoBehaviour
{
    public GameObject battery;
    public GameObject coil;


    public bool batteryInserted;
    public bool batteryRepolarized = false;
    public bool coilInserted;

    private void Start()
    {
        batteryInserted = false;
        coilInserted = false;
        Debug.Log(battery.transform.rotation.y);

    }

    private void OnTriggerEnter(Collider other)
    {
        Quaternion rotate;
        if (other.GetComponent<Battery>() != null && this.gameObject.name == "batterySpace")
        {
            Debug.Log("Battery inserted");
            

            batteryInserted = true;
            battery.transform.position = new Vector3(0.21f, 2.9f, -46.207f);
            battery.transform.rotation = new Quaternion(-0.5f, -0.5f, 0.5f, 0.5f);

            if (battery.transform.rotation.y > 0 && battery.transform.rotation.y < -0.7071f)
            {
              
               
                battery.transform.rotation = new Quaternion(-0.5f, 0.5f, 0.5f, 0.5f);
                batteryRepolarized = true;
                Debug.Log("Battery repolarized!!");
            }

            else
            {
                rotate = Quaternion.Euler(new Vector3(0, -90, 90));
                batteryRepolarized = false;
                battery.transform.rotation = new Quaternion(-0.5f, -0.5f, 0.5f, 0.5f);
            }
            
            
        }



    
        else if (other.GetComponent<Coil>() != null && this.gameObject.name == "coilSpace")
        {
            Debug.Log("Coil inserted");
            coilInserted = true;
            coil.transform.position = new Vector3(-0.644f, 2.875f, -45.21f);
            coil.transform.rotation = new Quaternion(0.0f, 0.7f, 0.0f, 0.7f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Battery>() != null && this.gameObject.name == "batterySpace")
        {
            Debug.Log("Battery removed");
            batteryInserted = false;            

        }
        if (other.GetComponent<Coil>() != null && this.gameObject.name == "coilSpace")
        {
            Debug.Log("Coil removed");
            coilInserted = false;            
        }
    }
}
