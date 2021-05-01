using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

public class DistanceCalculation : MonoBehaviour
{
    public Button calculateButton;
    public Button levelPassButton;
    
    public Slider frequency;
    public Text debugLog;
    public GameObject teleportPoint;
    TeleportPoint newLevelTeleport;
    Text outputText;
    double retDistance;
    int pressLimit = 3;


    public GameObject accumulators;
    private Accumulators accumObj;

    public GameObject Rounds;
    private EngineManager RoundsScript;

    int voltageVal;


    bool passLevel = false;

    // Start is called before the first frame update
    void Start()
    {
        outputText = GetComponent<Text>();
        accumObj = accumulators.GetComponent<Accumulators>();
        newLevelTeleport = teleportPoint.GetComponent<TeleportPoint>();
        RoundsScript = Rounds.GetComponent<EngineManager>();
        voltageVal = 1500 * accumObj.counter;

      
    }

    // Update is called once per frame
    void Update()
    {
        double retDistancePenalty = 500;

        int powerVal = 1000* voltageVal;
        double frequencyVal = frequency.value;
        float roundsVal = RoundsScript.getRounds();
        

        if (roundsVal < 500 || roundsVal > 1500)
        {
            retDistancePenalty = 0;
        }
        else
        {
            //Vzdialenost zalezi od poctu vlozenych baterii
            retDistancePenalty -= 100*accumObj.counter/(roundsVal/1000);
        }

        System.Random rnd = new System.Random();
        retDistance = rnd.Next(1175, 1225) + retDistancePenalty;
        retDistance = Math.Round(retDistance, 2);

        if (retDistance > 1300 && debugLog.text == "Gratulujem ti, podarilo sa ti naštartovať motor, pre ďalšie inštrukcie sa vráť k obrazovke pre inštrukcie.." && accumObj.accumulatorsPassed)
        {
            passLevel = true;
            levelPassButton.interactable = true;
            newLevelTeleport.locked = false;
        }
        else
        {
            passLevel = false;
            levelPassButton.interactable = false;
            newLevelTeleport.locked = true;
        }
            

      
            

    }

    public void Calculation()
    {  
        //Vypis na text
        
        if(pressLimit > 0)
        { 
            outputText.text = "Dojazd vlaku:  " + retDistance + " km";
            pressLimit--;
        }
        else 
            outputText.text = "Limit výpočtov vyčerpaný.";

        

    }
}
