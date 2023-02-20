using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuerda : MonoBehaviour
{
    public GameObject bola1;
    public GameObject bola2;
    public LineRenderer lineRenderer;
    public Transform[] posicionesCadena;
        Vector3[] posicionesCadena2;

    DistanceJoint2D distanceJoint1;
    DistanceJoint2D distanceJoint2;
    void Start()
    {
        distanceJoint1 = bola1.GetComponent<DistanceJoint2D>();
        distanceJoint2 = bola2.GetComponent<DistanceJoint2D>();
        if (!distanceJoint2.maxDistanceOnly)
            lineRenderer.positionCount = 2;
        else lineRenderer.positionCount = posicionesCadena.Length;
    }

    // Update is called once per frame
    void Update()
    {
        //Cuerda visual
        if (distanceJoint2.maxDistanceOnly)
        {
            posicionesCadena2 = new Vector3[posicionesCadena.Length];
            for (int i = 0; i < posicionesCadena.Length; i++)
                posicionesCadena2[i] = posicionesCadena[i].position;

            lineRenderer.SetPositions(posicionesCadena2);
        }
        else
        {
            lineRenderer.SetPosition(0, bola1.transform.position);
            lineRenderer.SetPosition(1, bola2.transform.position);
        }
    }

    public void CambiarPaloCuerda()
    {
        //DistanceJoint2D b1 = bola1.GetComponent<DistanceJoint2D>();
        distanceJoint1.maxDistanceOnly = !distanceJoint1.maxDistanceOnly;
        distanceJoint2.maxDistanceOnly = distanceJoint1.maxDistanceOnly;
        if (!distanceJoint1.maxDistanceOnly)
            lineRenderer.positionCount = 2;
        else lineRenderer.positionCount = posicionesCadena.Length;
    }
}
