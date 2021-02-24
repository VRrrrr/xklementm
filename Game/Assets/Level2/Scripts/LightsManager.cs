using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsManager : MonoBehaviour
{
    public Light light1;
    public Light light2;
    public Light light3;
    public Light light4;
    public Light tableLight;

    public void smallRoomLightSwitch()
    {
        light1.enabled = !light1.enabled;
        light2.enabled = !light2.enabled;
    }

    public void bigRoomLightSwitch()
    {
        light3.enabled = !light3.enabled;
        light4.enabled = !light4.enabled;

    }

    public void tableLightSwitch()
    {
        tableLight.enabled = !tableLight.enabled;
    }

}
