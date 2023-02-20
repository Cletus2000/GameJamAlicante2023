using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
using System.Linq;

public class Menu : MonoBehaviour
{
    public GameObject loading;
    //Fullscreen
        public Toggle ToggleFullscreen;

        public void AplicarFullscreen()
            {Screen.SetResolution(Screen.width,Screen.height,ToggleFullscreen.isOn);}

    //Resoluciones
        public TMP_Dropdown dropdown;
        List<string> opcionesResolucion = new List<string>();

        public void rellenarResoluciones()
        {
            dropdown.ClearOptions();
            
            //Obtener resoluciones posibles
            Resolution[] array = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
            
            //Meterlas en la lista
            foreach(Resolution res in array)
                opcionesResolucion.Add(res.width+"x"+res.height);

            //Meter la lista en el dropdown
            dropdown.AddOptions(opcionesResolucion);

            //Establecer el actual
            foreach(Resolution res in array)
                if(res.height==Screen.height && res.width==Screen.width)
                    dropdown.value = opcionesResolucion.IndexOf(res.width+"x"+res.height);
        }

        public void AplicarResolucion()
        {
            //Obtener resolucion elegida
            string resolucionElegida = dropdown.options[dropdown.value].text;
            string[] separar = resolucionElegida.Split('x');

            //Aplicar la resolucion y el fullscreen
            Screen.SetResolution(int.Parse(separar[0]), int.Parse(separar[1]), ToggleFullscreen.isOn);
        }

    //Sonido
        public Slider slider;
        public AudioMixer mixer;

        public void VolumenAudio(float f)
            {mixer.SetFloat("MusicVolume",Mathf.Log10(f)*20);}

    void Awake()
    {
        ToggleFullscreen.isOn = Screen.fullScreen;
        rellenarResoluciones();
    }

    public void Jugar()
    {
        loading.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void Salir()
        {Application.Quit();}


}