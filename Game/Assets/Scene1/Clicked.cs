using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clicked : MonoBehaviour
{
    Text mytext;
    private void Start()
    {
        mytext = GetComponent<Text>();
    }

    public void bClicked()
    {
        mytext.text = "CLICKED";
    }
}
