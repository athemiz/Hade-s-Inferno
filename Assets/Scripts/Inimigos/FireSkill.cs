using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSkill : MonoBehaviour {

    public GameObject player;
    private Animator animator;
    private bool dano = true;
    private bool timer;
    private float time=0;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}

    private void OnCollisionStay2D(Collision2D collision)
    {
        Physics2D.IgnoreLayerCollision(8, 8);
        if (collision.gameObject.tag == "Player" && dano)
        {
            player.gameObject.GetComponent<PlayerController>().hp-=10;
            GetComponent<BoxCollider2D>().enabled=false;
            dano = false;
            animator.SetBool("Hited", true);
            GetComponent<AudioSource>().Play();
            timer = true;
        }
    }

	
	// Update is called once per frame
	void Update () {
        if (!animator.GetBool("Hited"))
        {
            if (transform.eulerAngles.x == 0) transform.Translate(-0.1f, 0, 0);
            else transform.Translate(0.1f, 0, 0);
        }
        if (timer)
        {
            time += Time.deltaTime;
            if (time >= 0.2) Destroy(gameObject);
        }
	}
}
