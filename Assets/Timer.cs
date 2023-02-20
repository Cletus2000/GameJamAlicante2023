using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Globalization;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI cronometro;

    float segundos;
    int minutos;
    bool parar=false;
        public void Parar() { parar = true; }


    // Update is called once per frame
    void Update()
    {
        if (!parar)
        {
            segundos += Time.deltaTime;
            if (segundos >= 60)
            {
                minutos++;
                segundos -= 60;
            }
            cronometro.text = minutos.ToString("00") + ":" + segundos.ToString("00.00", CultureInfo.InvariantCulture);
        }
    }

    public string getTiempo()
    {
        return minutos.ToString("00") + ":" + segundos.ToString("00.00", CultureInfo.InvariantCulture);
    }
}
