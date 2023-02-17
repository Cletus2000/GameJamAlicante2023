using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuerda : MonoBehaviour
{
    public GameObject bola1;
    public GameObject bola2;
    public float distance = 50f;
    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        bola1.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bola1.transform.position = (bola1.transform.position - bola2.transform.position).normalized * distance + bola2.transform.position;
    }
}
