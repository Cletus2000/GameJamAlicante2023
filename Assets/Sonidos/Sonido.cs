using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonido : MonoBehaviour
{
    [Header("Musica de fondo")]
    public AudioSource musica0;
    public float delay1;
    public AudioSource musica;
    public float delay2;
    public AudioSource musica2;

    [Header("Ruidos random")]
    public int minimoTiempo= 10;
    public int maximoTiempo= 25;
    [Header("Objetos")]
    public GameObject luz;
    public Animation anim;

    void Start()
    {
        musica0.PlayDelayed(delay1);
        musica.PlayDelayed(delay1);
        musica2.PlayDelayed(delay2);
        //Invoke("Volver", 0);
    }

    void Volver()
    {
        int segundos = Random.Range(minimoTiempo, maximoTiempo);
        Invoke("GenerarRayo", segundos);
    }

    void GenerarRayo()
    {
        //anim.Play("Trueno");
        //sonido.Play(0);
        //Invoke("Volver", 0);
    }
}
