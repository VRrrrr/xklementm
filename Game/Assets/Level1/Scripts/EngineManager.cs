using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EngineManager : MonoBehaviour
{
    Text outputText;
    public Text outputTextPub;
    int[] poles = {2,4,6,8,10,12};
    int poleIndex;
    int actualPoles;
    float actualRounds;
        

    private void Start()
    {
        outputText = GetComponent<Text>();
        poleIndex = 0;
        actualPoles = 2;
        actualRounds = 0;
    }


    // Text update pre frekvenciu
    public void textUpdate(float freq)
    {
        outputText.text = freq + " Hz";
    }
    // Text update pre nätie
    public void voltageUpdate(float value)
    {
        outputTextPub.text = value + " V";        
    }
    // Text update pre výkon
    public void powerUpdate(float voltage)
    {
        outputTextPub.text = voltage*1000 + " W";
    }

    public void roundsUpdate(float freq, int poles)
    {
        actualRounds = (120 / poles) * freq ;
        outputTextPub.text = (120 / poles) * freq + " RPM";
    }

    public void polesUp()
    {
        if (poleIndex < poles.Length)
            poleIndex++;
        else
            poleIndex = 0;

        actualPoles = poles[poleIndex];
        outputTextPub.text = actualPoles.ToString();
    }

    public void polesDown()
    {
      
        if (poleIndex > 0)
            poleIndex--;
        else
            poleIndex = poles.Length-1;

        Debug.Log(poleIndex);

        actualPoles = poles[poleIndex];
        outputTextPub.text = actualPoles.ToString();
    }

    public int getPoles() { return actualPoles; }
    public float getRounds(){ return actualRounds; }
}
