using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    //Controle de som
    bool timer = false;
    private float time = 0;

    //Parametros Personagem - VIDA
    public int Maxhp = 30;
    public float Maxsta = 100;
    public int hp;
    public float sta;

    // Parametros - MOVIMENTO
    public float velocidade;

    // Parametros Animação - CORRER
    public Transform player;
    private Animator animator;
    public Rigidbody2D body;
    public AudioSource hit;
    private Scene scene;

    // Parametros Animação - PULO
    public float force = 100;

    public bool isGrounded;
    // Use this for initialization
    void Start()
    {
        hp = Maxhp;
        sta = Maxsta;
        animator = player.GetComponent<Animator> ();
        body = GetComponent<Rigidbody2D>();
        scene = SceneManager.GetActiveScene();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            animator.SetBool("Ground", true);
            animator.SetBool("isJumping", false);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
        animator.SetBool("Ground", true);
        animator.SetBool("isJumping", false);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
            animator.SetBool("Ground",false);
            animator.SetBool("isJumping", true);
        }
    }

    // Update is called once per frame

    void Update()
    {
        if (player.transform.position.y <= -2.5f && scene.name=="Fase 2") Application.LoadLevel("LevelSelect");
        else if (player.transform.position.y <= -5.5f && scene.name == "Fase 2") Application.LoadLevel("LevelSelect");
        if (timer) time += Time.deltaTime;
        if(Time.timeScale==1) Movimentar();
        if (Input.GetKeyDown(KeyCode.Return) && Time.timeScale == 1) Time.timeScale = 0;
        else if (Input.GetKeyDown(KeyCode.Return) && Time.timeScale == 0) Time.timeScale = 1;
    }

    void Movimentar()
    {
// Parametros Animação - CORRER
        animator.SetBool("isRunning", false);
        if(sta < Maxsta)sta += 0.2f;

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
            if (time == 0)
            {
                hit.Play();
                timer = true;
            }
            if (time >= 0.2)
            {
                time = 0;
                timer = false;
            }
            animator.SetBool("isPunching", true);
            sta -= 1;
            if (sta <= 0)
            {
                sta = 0;
                animator.SetBool("isPunching", false);
            }
        }
        else if(!Input.GetKey(KeyCode.J)) animator.SetBool("isPunching", false);


        if (isGrounded)
       {
            animator.SetBool("isJumping", false);
            animator.SetBool("Ground", true);
        }
    }

}