using System.Collections.Generic;
using UnityEngine;

public class ChangeMusicDynamic : MonoBehaviour
{
    private List<AudioSource> audioSources = new List<AudioSource>();
    private int activeIndex = 0;
    private int transitionFrames = 10; // Duración de la transición en frames

    void Start()
    {
        // Obtener todos los AudioSources de los hijos del GameObject
        foreach (Transform child in transform)
        {
            AudioSource source = child.GetComponent<AudioSource>();
            if (source != null)
            {
                audioSources.Add(source);
                source.loop = true; // Asegurar que los audios están en loop
                source.Play(); // Reproducir todos los audios
                source.volume = 0f; // Inicialmente silenciados
            }
        }

        // Asegurar que al menos un AudioSource esté activo
        if (audioSources.Count > 0)
        {
            audioSources[activeIndex].volume = 1f;
        }
        else
        {
            Debug.LogError("No se encontraron AudioSources en los hijos del GameObject.");
        }
    }

    void Update()
    {
        // Cambiar el audio activo con las flechas
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeActiveAudio(1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeActiveAudio(-1);
        }
    }

    private void ChangeActiveAudio(int direction)
    {
        if (audioSources.Count == 0) return;

        // Guardar el índice actual
        int previousIndex = activeIndex;

        // Cambiar el índice activo
        activeIndex = (activeIndex + direction + audioSources.Count) % audioSources.Count;

        // Iniciar la transición de volumen
        StopAllCoroutines(); // Detener transiciones anteriores
        StartCoroutine(TransitionAudio(audioSources[previousIndex], audioSources[activeIndex]));
    }

    private System.Collections.IEnumerator TransitionAudio(AudioSource previous, AudioSource next)
    {
        for (int frame = 0; frame <= transitionFrames; frame++)
        {
            float t = (float)frame / transitionFrames;

            if (previous != null) previous.volume = Mathf.Lerp(1f, 0f, t); // Volumen bajando
            if (next != null) next.volume = Mathf.Lerp(0f, 1f, t); // Volumen subiendo

            yield return null; // Esperar al siguiente frame
        }

        // Asegurarse de que los volúmenes estén exactamente al final
        if (previous != null) previous.volume = 0f;
        if (next != null) next.volume = 1f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Acaro"))
        {
            // Pasar a la siguiente pista automáticamente
            ChangeActiveAudio(1);
        }
    }
}
