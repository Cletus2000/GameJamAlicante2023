using UnityEngine;

public class SeguimientoCamara : MonoBehaviour
{
    public Transform bola1;
    public Transform bola2;
    [Range(-10,1)] public float suavizado = 0.1f;
    public Vector3 offset = new Vector3 (0,0,-10);
    public bool giroTridimensional = false;

    void LateUpdate()
    {
    //Minima separacion en el eje z para que no atraviese el escenario por detras
        if(offset.z>-1)
            offset.z = -1;

    //Suavizado camara
        Vector3 posicionObjetivo = (bola1.position+bola2.position)/2 + offset;
        Vector3 posicionSuavizada = Vector3.Lerp(transform.position, posicionObjetivo, ((1-suavizado) * Time.deltaTime)*0.5f );
        transform.position = posicionSuavizada;

    //Giro tridimensional
        if(giroTridimensional)
            {transform.LookAt(posicionObjetivo-offset);}
    }
}
