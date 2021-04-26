using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class EngineTune : MonoBehaviour
{


    public Slider frequency;    
    public Button engineStarter;
    public Button CalculationButton;

    Text debugText;

    
    public Text powerInfo;
    public Text EngineStatus;
    public Text EnergyStatus;

  


    //Bool hodnota určuje, či je motor zapnutý alebo vypnutý
    bool engineOn;
    //Bool hodnota určuje, či je motor funkčný
    bool functional;
    //Bool hodnota určuje, či je zapnutý zdroj energie pre motor
    bool energyOn;

    public GameObject Rounds;
    private EngineManager RoundsScript;

    public GameObject Poles;
    private EngineManager PolesScript;

    public GameObject Power;
    private EngineManager PowerScript;

    public GameObject Voltage;
    private EngineManager VoltageScript;

    public GameObject accumulators;
    private Accumulators accumObj;

    public GameObject powerInfoObject;
    private PowerButton powerButtonScript;

    int voltage;
    int polesCount;

    bool on = true;
    bool off = false;
    double power;
    // Start is called before the first frame update
    void Start()
    {
        debugText = GetComponent<Text>();
        accumObj = accumulators.GetComponent<Accumulators>();
        RoundsScript = Rounds.GetComponent<EngineManager>();
        PolesScript = Poles.GetComponent<EngineManager>();
        PowerScript = Power.GetComponent<EngineManager>();
        VoltageScript = Voltage.GetComponent<EngineManager>();

        powerButtonScript = powerInfoObject.GetComponent<PowerButton>();
       

        voltage = accumObj.counter * 1500;

        energyOn = false;
        engineOn = false;
        functional = true;
        
    }

    private void Update()
    {

        voltage = accumObj.counter * 1500;
        VoltageScript.voltageUpdate(voltage);
        power = voltage * 1000;

        if(engineOn)
            PowerScript.powerUpdate(voltage);
        else
            PowerScript.powerUpdate(0);
        if (voltage > 0)
        {
            RoundsScript.roundsUpdate(frequency.value, PolesScript.getPoles());
        }      
    }

    // Funkcia pre štartovanie motora (volá sa len ak je motor vypnutý)
    public void startEngine()
    {

        Debug.Log(energyOn);
        Debug.Log(engineOn);
        Debug.Log(functional);
        Debug.Log(powerButtonScript.isOn());
        Debug.Log(accumObj.accumulatorsPassed);
        Debug.Log("_____________________________");


        if (engineOn)
        {
            turnoffEngine();
            powerButtonScript.switchPower(off);
        }

        //counter - pocet zapojenych akumulatorov, kazdy po 1500 voltov       
      


        

        
        if (!accumObj.accumulatorsPassed)
            engineStartFail("Štart zlyhal, najprv pripoj akumulátory k vlaku!");

        

       if (accumObj.accumulatorsPassed && RoundsScript.getRounds() > 1500 ) 
             destroyEngine();       


        if (functional && accumObj.accumulatorsPassed)
        {
            //otacky na 95 - 105 % maxima
            if (RoundsScript.getRounds() < (0.95 * 1000) || RoundsScript.getRounds() > (1.05 * 1000))
            {
                engineStartFail("Štart zlyhal, otáčky musia byť medzi 95% a 105 % maxima!");
            }
        }

        //ak vsetko zbehlo, a motor stale funguje, mozme startovat
        if (functional && energyOn && accumObj.accumulatorsPassed)
        {           
            engineOn = true;
            powerButtonScript.switchPower(on);
            debugText.text = "Gratulujem ti, podarilo sa ti naštartovať motor, pre ďalšie inštrukcie sa vráť k obrazovke pre inštrukcie.";
            CalculationButton.interactable = true;
        }


        Debug.Log(energyOn);
        Debug.Log(engineOn);
        Debug.Log(functional);
        Debug.Log(powerButtonScript.isOn());
        Debug.Log(accumObj.accumulatorsPassed);
        

    }

    private void turnoffEngine()
    {
        engineOn = false;
        debugText.text = "Vypol si motor vlaku, pre pokračovanie v úrovni ho musíš znova zapnúť.";
    }

    void destroyEngine()
    {        

        functional = false;     

        //Disable button
        engineStarter.interactable = false;
        EngineStatus.text = "Stav motora: Zničený";
        EngineStatus.color = Color.red;
        levelFailed("Motor bol zničený");

        //Zhodenie prudu         
        energyFallout();

    }
    void engineStartFail()
    {
        engineOn = false;
        debugText.text = "Štart motora zlyhal, skontroluj frekvenciu a výkon, a nastav ich podľa inštrukcií";
        //Zhodenie prudu        
        energyFallout();

    }

    void engineStartFail(string failMessage)
    {
        engineOn = false;
        debugText.text = failMessage;

        //Zhodenie prudu   
        energyFallout();

    }

    void levelFailed(string failMessage) {
        debugText.text = "Bohužial sa ti nepodarilo túto úroveň prejsť: " + failMessage;
    }

    public void switchEnergy() {
        energyOn = !energyOn;
    }

    //Prepnutie tlacidla v pripade zhodenia zdroja
    void energyFallout()
    {
        //energyOn = false;
        switchEnergy(); 
        powerButtonScript.switchPower(off);
        powerInfo.text = "Zapnúť";
        powerInfo.color = Color.green;
        EnergyStatus.text = "Zdroj energie: Vypnutý";
        engineStarter.image.color = Color.green;        

        Debug.Log("switchEnergy: " + energyOn);
    }
}
