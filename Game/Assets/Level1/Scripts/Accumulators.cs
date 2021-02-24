using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Accumulators : MonoBehaviour
{
    public GameObject accumulatorSpace;
    public GameObject accumulatorSpace1;
    public GameObject accumulatorSpace2;
    public GameObject accumulatorSpace3;
    public Text debugLog;

    private AccumulatorPut aS;
    private AccumulatorPut aS1;
    private AccumulatorPut aS2;
    private AccumulatorPut aS3;
  
    public int counter;

    public bool accumulatorsPassed;
    // Start is called before the first frame update
    void Start()
    {
        accumulatorsPassed = false;

        aS = accumulatorSpace.GetComponent<AccumulatorPut>();
        aS1 = accumulatorSpace1.GetComponent<AccumulatorPut>();
        aS2 = accumulatorSpace2.GetComponent<AccumulatorPut>();
        aS3 = accumulatorSpace3.GetComponent<AccumulatorPut>();

        
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {   //V podmienke musi byt to ci su akumulatory uz vlozene, inak by sa volala podmienka kazdy frame od vlozenia
        if (counter >= 2 && !accumulatorsPassed)
        {
            accumulatorsPassed = true;
            debugLog.text = "Batérie vložené !";
        }

        int tmpCounter = 0;

        
        if (aS.Inserted)
            tmpCounter++;
        if (aS1.Inserted)
            tmpCounter++;
        if (aS2.Inserted)
            tmpCounter++;
        if (aS3.Inserted)
            tmpCounter++;
            
        if (counter != tmpCounter)
            counter = tmpCounter;
        
    }
}
