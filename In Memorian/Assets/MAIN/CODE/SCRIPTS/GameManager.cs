using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject menuPausa;
    [SerializeField]
    private bool _Sello = false;

    void Start()
    {

    }

    // Update is called once per frame

    public void Reintentar(string Derrota)
    {
        //puntos = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene("Juego");
    }


    private void Update()
    {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (menuPausa.activeSelf)
                {
                    EstadoDelJuego("Play");
                    menuPausa.SetActive(false);
                }
                else
                {
                    EstadoDelJuego("Pause");
                    menuPausa.SetActive(true);
                }

            }
    

    }

    public void EstadoDelJuego(string estado)
    {
        switch (estado)
        {

            case "Play":
                Time.timeScale = 1;
                break;
            case "Pause":
                Time.timeScale = 0;
                break;
            case "Quit":
                Application.Quit();
                break;
        }
    }

    public void ObtenerSello()
    {
        _Sello = true;
    }
}
