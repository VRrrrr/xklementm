using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PowerButton : MonoBehaviour
{
    Text powerText;
    bool on;
    public Button switchButton;
    public Text energyStatus;

    

    // Start is called before the first frame update
    void Start()
    {
        powerText = GetComponent<Text>();
        on = false;
    }
    //Preklapanie tlacidla
    public void switchPower()
    {
        //Switch
        on = !on;
        //true
        if (on) { 
            powerText.text = "Vypnúť";
            powerText.color = Color.red;
            switchButton.image.color = Color.red;
            energyStatus.text = "Zdroj energie: Zapnutý";

        } else { 
            powerText.text = "Zapnúť";
            powerText.color = Color.green;
            switchButton.image.color = Color.green;
            energyStatus.text = "Zdroj energie: Vypnutý";

        }
        //Debug.Log(gameObject.name);
    }

    public void switchPower(bool on)
    {
        //Switch
        if (!on)
        {
            powerText.text = "Zapnúť";
            powerText.color = Color.green;
            switchButton.image.color = Color.green;
           
        }
        //true
        else
        {
            powerText.text = "Vypnúť";
            powerText.color = Color.red;
            switchButton.image.color = Color.red;
        }
        //Debug.Log(gameObject.name);
    }




    public bool isOn() { return on; }

    //Funkcia vypise ci je privod energie k motoru zapnuty, alebo vypnuty 
    public void printEnergyStatus()
    {       
        if (isOn())        
            powerText.text = "Zdroj energie: Zapnutý";
        else
            powerText.text = "Zdroj energie: Vypnutý";
    }
}
