using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Meta : MonoBehaviour
{
    public CambiarEscena a;
    public AudioSource ganar;

    public GameObject menuVictoria;
    public Transform cam;
    public GameObject player;
    public GameObject cronometro;

    public Timer tiempo;
    public TextMeshProUGUI tiempoFinal;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Bola 1" || collision.name == "Bola 2")
        {
            ganar.Play();
            tiempo.Parar();
            tiempoFinal.text = tiempo.getTiempo();
            Invoke("fun",1f);
        }
        
    }

    void fun()
    {
        menuVictoria.SetActive(true);
        player.SetActive(false);
        cronometro.SetActive(false);
        cam.gameObject.GetComponent<SeguimientoCamara>().enabled = false;
        cam.position = new Vector3(26.37f, 7.99f, -11.08f);
        cam.rotation = Quaternion.Euler(-15.988f, 34.139f, 0);

    }
}
