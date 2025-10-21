using UnityEngine;
using UnityEngine.InputSystem;

public class Controles : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;   
    private Rigidbody2D rb2d;
    private Vector2 moveImput;
    private Animator animator;

    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        rb2d.linearVelocity = moveImput * moveSpeed;


    }

    public void Move(InputAction.CallbackContext context)
    {
        animator.SetBool("isWalking" , true);

        if (context.canceled)
        {
            animator.SetBool("isWalking", false);
            animator.SetFloat("LastInputX", moveImput.x);
            animator.SetFloat("LastInputY", moveImput.y);
        }

        moveImput = context.ReadValue<Vector2>();
        animator.SetFloat("InputX", moveImput.x);
        animator.SetFloat("InputY", moveImput.y);
    }
}