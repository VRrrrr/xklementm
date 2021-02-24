using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pointer : MonoBehaviour
{
    public float m_DefaultLength = 5.0f;
    public GameObject m_Dot;
    public VRInputModule m_InputModule;

    private LineRenderer m_LineRenderer = null;

    private void Awake()
    {
        m_LineRenderer = GetComponent<LineRenderer>();
    }
    // Update sa volá pri každej snímke (frame)
    private void Update()
    {
        UpdateLine();
    }

    private void UpdateLine()
    {
        //Použi maximálnu dĺžku, alebo vzdialenosť objektu s ktorým je lúč v kolízii
        PointerEventData data = m_InputModule.GetData();
        float targetLength = data.pointerCurrentRaycast.distance == 0 ? m_DefaultLength : data.pointerCurrentRaycast.distance;

        //Raycast lúč
        RaycastHit hit = CreateRaycast(targetLength);
        //Default
        Vector3 endPosition = transform.position + (transform.forward * targetLength);
        //Ak došlo ku kolízii s objektom, určíme hranicu po ktorú siaha lúč až k jeho hranici
        if (hit.collider != null)
        {
            endPosition = hit.point;
        }

        //Určenie pozície bodky na konci lúča
        m_Dot.transform.position = endPosition;
        //Inicializácia pozície linerenderera
        m_LineRenderer.SetPosition(0, transform.position);
        m_LineRenderer.SetPosition(1, endPosition);
    }

    //Vytvorenie samotného lúča
    private RaycastHit CreateRaycast(float length)
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, m_DefaultLength);
        return hit;
    }
}
