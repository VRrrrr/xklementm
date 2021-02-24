using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccumulatorPut : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Inserted;
    public Text putText;    

    void Start()
    {
        Inserted = false;
        putText = this.gameObject.transform.GetChild(0).GetComponentInChildren<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("colide");
        if(other.gameObject.tag == "Accumul" && !Inserted)
        {
            Debug.Log(other.gameObject.tag);
            Debug.Log(this.name);
            Debug.Log(other.gameObject.name);

            if (this.name == "Accumulatorspace1")
                other.gameObject.transform.position = new Vector3(120.44f, 13.04f, 41.85f);
            if (this.name == "Accumulatorspace2")
                other.gameObject.transform.position = new Vector3(119.044f, 13.04f, 41.85f);
            if (this.name == "Accumulatorspace2")
                other.gameObject.transform.position = new Vector3(120.44f, 14.225f, 41.85f);
            if (this.name == "Accumulatorspace")
                other.gameObject.transform.position = new Vector3(119.044f, 14.225f, 41.85f);
            Destroy(other.gameObject);
            Inserted = true;
            putText.text = "Akumulátor vložený";
        }
    }
}
