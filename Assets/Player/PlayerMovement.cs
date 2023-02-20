using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public bool modoPalo=true;
        public void ModoPalo()
            { modoPalo = !modoPalo; }
        Cuerda cuerda;
    public GameObject bola1;
    public GameObject bola2;
        Transform tB1;
        Transform tB2;
        Rigidbody2D rbB1;
        Rigidbody2D rbB2;

    public bool b1TocaSuelo;
    public bool b2TocaSuelo;
        public void bola1TocaSuelo(bool a)
            { b1TocaSuelo = a; }
        public void bola2TocaSuelo(bool a)
            { b2TocaSuelo = a; }
    public AudioSource pc;
    public AudioSource cp;

    private void Start()
    {
        tB1 = bola1.transform;
        tB2 = bola2.transform;
        rbB1 = bola1.GetComponent<Rigidbody2D>();
        rbB2 = bola2.GetComponent<Rigidbody2D>();
        cuerda = GetComponent<Cuerda>();
    }

    public float sensibilidadControl = 0.5f;
    public float velocidadGiro=5;
    public float giro = 5;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("CambiarModo"))
        {
            ModoPalo();
            cuerda.CambiarPaloCuerda();
            if (!modoPalo)
                pc.Play();
            else cp.Play();
        }
        if(Input.GetKeyDown(KeyCode.Backspace))
            { SceneManager.LoadScene(1); }

        if (modoPalo)
        {
            //Player 1
            if (Input.GetKey(KeyCode.D) || Input.GetAxis("Horizontal1") > sensibilidadControl)
                if( (!b1TocaSuelo&&b2TocaSuelo)||(b1TocaSuelo&&b2TocaSuelo) )
                {
                    rbB1.velocity = Vector2.Perpendicular(tB2.position - tB1.position).normalized * velocidadGiro;
                }
            if (Input.GetKey(KeyCode.A) || Input.GetAxis("Horizontal1") < -sensibilidadControl)
                if((!b1TocaSuelo && b2TocaSuelo) || (b1TocaSuelo && b2TocaSuelo))
                {
                    rbB1.velocity = Vector2.Perpendicular(tB1.position - tB2.position).normalized * velocidadGiro;
                }

            //Player 2
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal2") > sensibilidadControl)
                if( (b1TocaSuelo&&!b2TocaSuelo)||(b1TocaSuelo&&b2TocaSuelo) )
                {
                    rbB2.velocity = Vector2.Perpendicular(tB1.position - tB2.position).normalized * velocidadGiro;
                }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal2") < -sensibilidadControl)
                if((b1TocaSuelo && !b2TocaSuelo) || (b1TocaSuelo && b2TocaSuelo))
                {
                    rbB2.velocity = Vector2.Perpendicular(tB2.position - tB1.position).normalized * velocidadGiro;
                }
        }
        else
        {
            //Player 1
            if (Input.GetKey(KeyCode.D) || Input.GetAxis("Horizontal1") > sensibilidadControl)
                rbB1.AddTorque(-giro * Time.deltaTime);
            if (Input.GetKey(KeyCode.A) || Input.GetAxis("Horizontal1") < -sensibilidadControl)
                rbB1.AddTorque(giro * Time.deltaTime);


            //Player 2
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal2") > sensibilidadControl)
                rbB2.AddTorque(-giro * Time.deltaTime);

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal2") < -sensibilidadControl)
                rbB2.AddTorque(giro * Time.deltaTime);
        }
    }
}