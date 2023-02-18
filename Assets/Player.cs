using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bola1;
    public GameObject bola2;
        Transform tB1;
        Transform tB2;
        Rigidbody2D rbB1;
        Rigidbody2D rbB2;
    public LineRenderer lineRenderer;
    public float velocidadGiro=2.5f;
    bool estirada;
    public float compensar = 3.4f;
    public Transform[] posicionesCadena;
            Vector3[] posicionesCadena2;



    public bool b1TocaSuelo;
    public bool b2TocaSuelo;
        public void bola1TocaSuelo(bool a)
            { b1TocaSuelo = a; }
        public void bola2TocaSuelo(bool a)
            { b2TocaSuelo = a; }


    Vector3 distancia213=new Vector3();
        Vector2 distancia212=new Vector2();
    Vector3 distancia123 = new Vector3();
        Vector2 distancia122=new Vector2();

    public float sensibilidadControl=0.05f;

    

    private void Start()
    {
        tB1 = bola1.transform;
        tB2 = bola2.transform;
        rbB1 = bola1.GetComponent<Rigidbody2D>();
        rbB2 = bola2.GetComponent<Rigidbody2D>();
        if (!bola2.GetComponent<DistanceJoint2D>().maxDistanceOnly)
            lineRenderer.positionCount = 2;
        else lineRenderer.positionCount = posicionesCadena.Length;
    }

    void Update()
    {
        //Cuerda visual
        if(bola2.GetComponent<DistanceJoint2D>().maxDistanceOnly)
        {
            posicionesCadena2 = new Vector3[posicionesCadena.Length];
            for (int i = 0; i < posicionesCadena.Length; i++)
                posicionesCadena2[i] = posicionesCadena[i].position;

            lineRenderer.SetPositions(posicionesCadena2);
        }
        else
        {
            lineRenderer.SetPosition(0, tB1.position);
            lineRenderer.SetPosition(1, tB2.position);
        }

        //Cosas para contrarestar la caida
        distancia213 = tB2.position - tB1.position;
        if(distancia213.magnitude>=compensar)
            estirada = true;
        else estirada = false;

        //PLAYER 1
        if (Input.GetKey(KeyCode.D) || Input.GetAxis("Horizontal1") > sensibilidadControl)
        {
            //Limitaciones para evitar volar
            if( (!b1TocaSuelo&&b2TocaSuelo)||(b1TocaSuelo&&b2TocaSuelo) )
            {
                //Ya calculamos esta distancia arriba
                distancia212 = new Vector2(distancia213.x, distancia213.y);
                
                rbB1.velocity = Vector2.Perpendicular(distancia212).normalized * velocidadGiro;
                if (!estirada)
                    rbB1.velocity -= distancia212.normalized;
            }
        }
        if (Input.GetKey(KeyCode.A) || Input.GetAxis("Horizontal1") < -sensibilidadControl)
        {
            if((!b1TocaSuelo && b2TocaSuelo) || (b1TocaSuelo && b2TocaSuelo))
            {
                distancia123 = tB1.position - tB2.position;
                distancia122 = new Vector2(distancia123.x, distancia123.y);
                
                rbB1.velocity = Vector2.Perpendicular(distancia122).normalized * velocidadGiro;
                if (!estirada)
                    rbB1.velocity += distancia122.normalized;
            }
        }

        /*
         * FALTA HACER LO DE QUE AVANCEN COMO UN COCHE
         */



        //PLAYER 2
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal2") > sensibilidadControl)
            if((b1TocaSuelo && !b2TocaSuelo) || (b1TocaSuelo && b2TocaSuelo))
            {
                distancia123 = tB1.position - tB2.position;
                distancia122 = new Vector2(distancia123.x, distancia123.y);
            
                rbB2.velocity = Vector2.Perpendicular(distancia122).normalized * velocidadGiro;
                if (!estirada)
                    rbB2.velocity -= distancia122.normalized;
            }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal2") < -sensibilidadControl)
            if((b1TocaSuelo && !b2TocaSuelo) || (b1TocaSuelo && b2TocaSuelo))
            {
                distancia212 = new Vector2(distancia213.x, distancia213.y);
            
                rbB2.velocity = Vector2.Perpendicular(distancia212).normalized * velocidadGiro;
                if (!estirada)
                    rbB2.velocity += distancia212.normalized;
            }
        
        //...brum brum
    }




    //El boton para cambiar de cuerda a palo y viceversa llama a este m�todo
    public void CambiarPaloCuerda()
    {
        DistanceJoint2D b1 = bola1.GetComponent<DistanceJoint2D>();
        b1.maxDistanceOnly = !b1.maxDistanceOnly;
        bola2.GetComponent<DistanceJoint2D>().maxDistanceOnly=b1.maxDistanceOnly;
        if (!b1.maxDistanceOnly)
            lineRenderer.positionCount = 2;
        else lineRenderer.positionCount = posicionesCadena.Length;
    }

    public void CambiarPaloCuerda(bool a)
    {
        Debug.Log("boton");
        bola1.GetComponent<DistanceJoint2D>().maxDistanceOnly = a;
        bola2.GetComponent<DistanceJoint2D>().maxDistanceOnly = a;
    }
}
