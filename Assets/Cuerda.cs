using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuerda : MonoBehaviour
{
    public GameObject bola1;
    public GameObject bola2;
    public LineRenderer lineRenderer;
    public float velocidadGiro=2.5f;
    bool estirada;
    public float compensar = 3.4f;

    // Update is called once per frame
    void Update()
    {
        //Cuerda
        lineRenderer.SetPosition(0, bola1.transform.position);
        lineRenderer.SetPosition(1, bola2.transform.position);


        //
        Vector3 speed3 = bola2.transform.position - bola1.transform.position;
        if(speed3.magnitude>=compensar)
            estirada = true;
        else estirada = false;
        if (Input.GetKey(KeyCode.D))
        {
            if(!estirada)
            {
                Vector3 speed = bola2.transform.position - bola1.transform.position;
                Vector2 speed2 = new Vector2(speed.x, speed.y);
                bola1.GetComponent<Rigidbody2D>().velocity = Vector2.Perpendicular(speed2).normalized*velocidadGiro - speed2.normalized;
            }
            else
            {
                Vector3 speed = bola2.transform.position - bola1.transform.position;
                Vector2 speed2 = new Vector2(speed.x, speed.y);
                bola1.GetComponent<Rigidbody2D>().velocity = Vector2.Perpendicular(speed2).normalized * velocidadGiro;
            }
        }
        if (Input.GetKey(KeyCode.I))
        {
            if (!estirada)
            {
                Vector3 speed = bola1.transform.position - bola2.transform.position;
                Vector2 speed2 = new Vector2(speed.x, speed.y);
                bola1.GetComponent<Rigidbody2D>().velocity = Vector2.Perpendicular(speed2).normalized * velocidadGiro + speed2.normalized;
            }
            else
            {
                Vector3 speed = bola1.transform.position - bola2.transform.position;
                Vector2 speed2 = new Vector2(speed.x, speed.y);
                bola1.GetComponent<Rigidbody2D>().velocity = Vector2.Perpendicular(speed2).normalized * velocidadGiro;
            }
        }
    }
}
