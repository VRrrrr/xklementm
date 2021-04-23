using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Describing : MonoBehaviour
{
    // Start is called before the first frame update
    public Text describeText;
    private int clickCounter = 0;

    void Start()
    {
    }

    public void ButtonPressed()
    {
        describeText.text = "Výborne! Podarilo sa ti stlačiť tlačidlo " + ++clickCounter + "-krát";
    }

    public void HoverButtonPressed()
    {
        describeText.text = "Výborne! Podarilo sa ti stlačiť tlačidlo";
    }

    public void HoverButtonReleased()
    {
        describeText.text = "Posuň tlačidlo dolu tým, že ho ovládačom potlačíš dole";
    }

}
