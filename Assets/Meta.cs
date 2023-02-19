using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meta : MonoBehaviour
{
    public CambiarEscena a;
    public AudioSource ganar;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Bola 1" || collision.name == "Bola 2")
        {
            ganar.Play();
            Invoke("fun",2);
        }
        
    }

    void fun()
    {
        a.cambiaEscena();
    }
}
