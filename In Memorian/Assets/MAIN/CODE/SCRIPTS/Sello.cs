using UnityEngine;

public class Sello : MonoBehaviour
{
    [SerializeField] 
    private GameManager gameManager;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.ObtenerSello();
            Destroy(gameObject); 
        }
    }
}
