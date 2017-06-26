using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HadesIA : MonoBehaviour {

    public GameObject player;
    private Rigidbody2D body;
    private Animator animator;
    public GameObject fire_obj;
    private float velocidade = 1f;
    private float force = 50f;
    private float time = 0;
    public int hp = 500;
    public bool timer = true;
    public bool timer2 = true;
    public bool move = false;
    public bool fire = true;
    public bool isGrounded;
    private float fire_angle;
    // Use this for initialization
    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
        
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
            animator.SetBool("Ground", false);
            animator.SetBool("isJumping", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (System.Math.Abs(player.transform.position.x - this.transform.position.x) <= 4) move = true;
        if(hp==0) animator.SetBool("isDead", true);
        if (!this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("dead") && move)
        {
            if (Random.Range(1, 80) == 2 && isGrounded)
            {
                animator.SetBool("isRunning", false);
                animator.SetBool("isJumping", true);
                body.AddForce(transform.up * force);
            }
            if (time > 1.3 && time < 2.3 && timer)
            {
                timer = false;
                animator.SetBool("isAttacking", true);
                fire = false;
                Instantiate(fire_obj, new Vector2(transform.position.x, transform.position.y),Quaternion.Euler(0,fire_angle,0));
            }
            else if (time > 2.35)
            {
                time = 0;
                timer = true;
                fire = true;
                animator.SetBool("isAttacking", false);
            }

            if (player.transform.position.x <= this.transform.position.x)
            {
                body.AddForce(Vector2.left * velocidade);
                GetComponent<SpriteRenderer>().flipX = false;
                animator.SetBool("isRunning", true);
                fire_angle = 0f;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = true;
                body.AddForce(Vector2.right * velocidade);
                animator.SetBool("isRunning", true);
                fire_angle = 180f;
            }
        }
        else if(this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("dead"))
        {
            Debug.Log("hashsa");
            if(timer2){
                time = 0;
                timer2 = false;
                }
            if (time >= 3) Application.LoadLevel("Creditos");
        }
    }
}
