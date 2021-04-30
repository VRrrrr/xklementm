using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SchemaManager : MonoBehaviour
{

    public GameObject batteryCollider;
    public GameObject coilCollider;
   
    
    public GameObject compassArrow;
    public GameObject drawer;

    //Skripty
    Compass compassScript;
    SchematicOnPut batteryScript;
    SchematicOnPut coilScript;
    DrawerOpen openDrawerScript;


    Text outputText;
    public Text batteryStateText;
    public Text coilStateText;
    public Text voltmeterText;
  

    bool previousBatteryState;
    bool previousCoilState;



    // Start is called before the first frame update
    private void Start()
    {
        batteryScript = batteryCollider.GetComponent<SchematicOnPut>();
        coilScript = coilCollider.GetComponent<SchematicOnPut>();

        previousBatteryState = batteryScript.batteryInserted;
        previousCoilState = coilScript.coilInserted;

        compassScript = compassArrow.GetComponent<Compass>();
        openDrawerScript = drawer.GetComponent<DrawerOpen>();

        outputText = GetComponent<Text>();

        outputText.text = Instruction(0);

        batteryStateText.text = " Batéria: vybratá";
        coilStateText.text = " Cievka: vybratá";
    }

    // Update is called once per frame
    private void Update()
    {
        batteryScript = batteryCollider.GetComponent<SchematicOnPut>();
        coilScript = coilCollider.GetComponent<SchematicOnPut>();

        //Zistime ci nenastala zmena stavu
        if (batteryScript.batteryInserted != previousBatteryState)
            BatteryAdd();
        if (coilScript.coilInserted != previousCoilState)
            CoilAdd();


        //Ulozime predosly stav kvoli sledovanu zmeny 
        previousBatteryState = batteryScript.batteryInserted;
        previousCoilState = coilScript.coilInserted;

        if (batteryScript.batteryInserted && coilScript.coilInserted)
        {
            Text instructiontext = GetComponent<Text>();
            instructiontext.text = "Výborne, podarilo sa ti vytvoriť magnetické pole. V stole sa otvorila zásuvka, v ktorej sa nachádza ovládač na otvorenie dverí v prvej miestnosti, tam je treba naladiť frekvenciu prijímača na rovnakú ako má ovládač.";

            openDrawerScript.Open();
            compassScript.on = true;
        }    
    }
    
    private void BatteryAdd()
    {
        if (batteryScript.batteryInserted)
        {
            batteryStateText.text = " Batéria: vložená";
            voltmeterText.text = "Napätie: 9 V";            
        }

        else
        {
            batteryStateText.text = " Batéria: vybratá";
            voltmeterText.text = "Napätie: 0 V";
            compassScript.on = false;
        }
            
    }

    private void CoilAdd()
    {
        if (coilScript.coilInserted)        
            coilStateText.text = " Cievka: vložená";
        else
        {
            coilStateText.text = " Cievka: vybratá";
            compassScript.on = false;
        }
            

    }
    
    private string Instruction(int instructionIndex) {
        switch (instructionIndex)
        {
            case 0:
                {
                    return (instructionIndex+1).ToString() + 
                        ". Vyber batériu a cievku a vlož ich do schémy. To, že sú vložené správne poznáš podľa toho, že prúd v cievke začne indukovať magnetické pole, ktoré pritiahne ručičku kompasu na stole.";
                    
                }
            default : {
                    return "Wrong instruction input";
                        };

        }
    }
}
