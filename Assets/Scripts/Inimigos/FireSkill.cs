using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSkill : MonoBehaviour {

    public GameObject player;
    private Animator animator;
    private bool dano = true;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}

    private void OnCollisionStay2D(Collision2D collision)
    {
        Physics2D.IgnoreLayerCollision(8, 8);
        if (collision.gameObject.tag == "Player" && dano)
        {
            player.gameObject.GetComponent<PlayerController>().hp-=20;
            player.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 15);
            dano = false;
            animator.SetBool("Hited", true);
        }
    }

	
	// Update is called once per frame
	void Update () {
        if (!animator.GetBool("Hited"))
        {
            if (transform.eulerAngles.x == 0) transform.Translate(-0.1f, 0, 0);
            else transform.Translate(0.1f, 0, 0);
        }
	}
}
