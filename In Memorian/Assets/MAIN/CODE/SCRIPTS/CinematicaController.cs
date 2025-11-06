using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class CinematicaController : MonoBehaviour
{
    [Header("Referencias")]
    public PlayableDirector director;          // Timeline
    public string siguienteEscena = "Nivel1";  
    public Image pantallaNegra;                // Imagen de fundido (UI)
    public float duracionFade = 1.5f;          // Duración del fundido

    void Start()
    {
        if (director == null)
            director = GetComponent<PlayableDirector>();

        director.stopped += OnCinematicaTerminada;

        // Fade in al empezar (de negro a transparente)
        if (pantallaNegra != null)
            StartCoroutine(Fade(1, 0));
    }

    void OnCinematicaTerminada(PlayableDirector d)
    {
        // Cuando termina la cinemática, inicia el fade out
        if (pantallaNegra != null)
            StartCoroutine(FadeOutYCambiarEscena());
        else
            SceneManager.LoadScene(siguienteEscena);
    }

    IEnumerator Fade(float inicio, float fin)
    {
        float elapsed = 0f;
        Color c = pantallaNegra.color;

        while (elapsed < duracionFade)
        {
            elapsed += Time.deltaTime;
            c.a = Mathf.Lerp(inicio, fin, elapsed / duracionFade);
            pantallaNegra.color = c;
            yield return null;
        }

        c.a = fin;
        pantallaNegra.color = c;
    }

    IEnumerator FadeOutYCambiarEscena()
    {
        yield return Fade(0, 1); // Desvanecer a negro
        SceneManager.LoadScene(siguienteEscena);
    }
}
