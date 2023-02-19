using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    public int escena;

    public cambiarEscena(int numEscena){
        numEscena = escena;
        SceneManagement.LoadScene(numEscena);
    }
}
