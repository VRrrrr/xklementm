using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttachCanvasesToPlayer1 : MonoBehaviour
{

    Canvas[] canvases2;
    // Start is called before the first frame update
    void Start()
    {
        canvases2 = FindObjectsOfType<Canvas>();
        GameObject player = GameObject.Find("Player");
        Camera prPointer = player.GetComponentInChildren<Camera>();
        
        for (int i = 0; i < canvases2.Length; i++)
        {
            canvases2[i].worldCamera = prPointer;
        }
        player.transform.localScale = new Vector3(3f, 3f, 3f);
        player.transform.position = transform.position;
        player.transform.RotateAround(player.transform.position, player.transform.up, 180f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
