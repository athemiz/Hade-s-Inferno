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
        if (colision.gameObject.tag == "Ground") isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D colision)
    {
        if (colision.gameObject.tag == "Ground") isGrounded = false;
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        Movimentar();
    }

    void Movimentar()
    {
// Parametros Animação - CORRER
        animator.SetFloat("run",Mathf.Abs(Input.GetAxis("Horizontal")));

// Parametros - MOVIMENTO
        if (Input.GetAxisRaw("Horizontal") > 0)
        {

            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {

            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
        }

      

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            body.AddForce(transform.up * force);
            jumpTime = jumpDelay;
            animator.SetTrigger("Jump");
        }

       

       if (isGrounded)
       {
            animator.SetTrigger("Ground");
        }
    }

}