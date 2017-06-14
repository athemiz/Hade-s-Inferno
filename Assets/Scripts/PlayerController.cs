using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

// Parametros - MOVIMENTO
    public float velocidade;

// Parametros Animação - CORRER
    public Transform player;
    private Animator animator;
    public Rigidbody2D body;

    // Parametros Animação - PULO
    public float force = 100;

    public float jumpTime = 0.4f;
    public float jumpDelay = 0.4f;
    public bool isGrounded;

    // Use this for initialization
    void Start()
    {
        animator = player.GetComponent<Animator> ();
        body = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            animator.SetBool("Ground", true);
            animator.SetBool("isJumping", false);
        }
    }

    void OnCollisionExit2D(Collision2D colision)
    {
        if (colision.gameObject.tag == "Ground")
        {
            isGrounded = false;
            animator.SetBool("Ground",false);
            animator.SetBool("isJumping", true);
        }
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        Movimentar();
    }

    void Movimentar()
    {
// Parametros Animação - CORRER
        animator.SetBool("isRunning", false);

        // Parametros - MOVIMENTO
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            animator.SetBool("isRunning", true);
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            animator.SetBool("isRunning", true);
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
        }

      

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isJumping", true);
            body.AddForce(transform.up * force);
        }

        if (Input.GetKey(KeyCode.J))
        {
            animator.SetBool("isPunching", true);
        }
        else if(!Input.GetKey(KeyCode.J)) animator.SetBool("isPunching", false);


        if (isGrounded)
       {
            animator.SetBool("isJumping", false);
            animator.SetBool("Ground", true);
        }
    }

}