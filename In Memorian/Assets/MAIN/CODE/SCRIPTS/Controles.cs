using UnityEngine;

public class Controles : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb2d;

    [SerializeField]
    private float fuerza = 100f;




    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //arriba

        if (Input.GetKeyDown(KeyCode.W))
        {
            rb2d.AddForce(new Vector2(0f, 1f) * fuerza);

        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb2d.AddForce(new Vector2(0f, 1f) * fuerza);
        }

        //izquierda

        if (Input.GetKeyDown(KeyCode.A))
        {
            rb2d.AddForce(new Vector3(-1f, 0f) * fuerza);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb2d.AddForce(new Vector3(-1f, 0f) * fuerza);
        }

        //derecha

        if (Input.GetKeyDown(KeyCode.D))
        {
            rb2d.AddForce(new Vector4(1f, 0f) * fuerza);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb2d.AddForce(new Vector4(1f, 0f) * fuerza);
        }

        //abajo

        if (Input.GetKeyDown(KeyCode.S))
        {
            rb2d.AddForce(new Vector2(0f, -1f) * fuerza);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb2d.AddForce(new Vector2(0f, -1f) * fuerza);
        }

    }

}