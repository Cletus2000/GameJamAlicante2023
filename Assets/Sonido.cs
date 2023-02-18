using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonido : MonoBehaviour
{
    public int minimoTiempoEntreRayos = 10;
    public int maximoTiempoEntreRayos = 25;
    [Header("Objetos")]
    public GameObject luz;
    public Animation anim;
    public AudioSource sonido;
    public AudioSource sonido2;

    void Start()
    {
        Invoke("Volver", 0);
    }

    void Volver()
    {
        int segundos = Random.Range(minimoTiempoEntreRayos, maximoTiempoEntreRayos);
        Invoke("GenerarRayo", segundos);
    }

    void GenerarRayo()
    {
        anim.Play("Trueno");
        sonido.Play(0);
        sonido2.Play(0);
        Invoke("Volver", 0);
    }
}
