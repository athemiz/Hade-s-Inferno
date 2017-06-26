using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysManager : MonoBehaviour {
    public EsqueletosIA esqueleto;
    public Skull_lavaIA skull_lava;
    public HellwolfIA hellwolf;
    public HadesIA hades;

    public GameObject player;
    public Rigidbody2D body;

    private float time = 0;
    private bool timer = false;

    List<AudioSource> audios = new List<AudioSource>();
    
	// Use this for initialization
	void Start () {
        esqueleto = GetComponent<EsqueletosIA>();
        skull_lava = GetComponent<Skull_lavaIA>();
        hellwolf = GetComponent<HellwolfIA>();
        body = GetComponent<Rigidbody2D>();
        this.GetComponents<AudioSource>(audios);
	}

    private void OnCollisionStay2D(Collision2D collision)
    {
        Physics2D.IgnoreLayerCollision(8, 8);
        //Caso Inimigo não esteja morto
        if (!this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("dead"))
        {
            //Caso Player o ataque
            if (collision.gameObject.tag == "Player" && player.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("punch"))
            {
                if (esqueleto) esqueleto.hp--;
                else if (skull_lava)
                {
                    skull_lava.hp--;
                }
                else if (hellwolf) {
                    hellwolf.hp--;
                }
                else if (hades)
                {
                    hades.hp--;
                }

                //Toca o som e liga o temporizador para poder tocar o som novamente
                if (time == 0)
                {
                    audios[0].Play();
                    timer = true;
                }
                //Empurra o Inimigo
                if (player.transform.eulerAngles[1] == 180) body.AddForce(Vector2.left * 15);
                else body.AddForce(Vector2.right * 15);
            }
            //Caso o Player seja atacado
            else if (collision.gameObject.tag == "Player" && !player.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("punch"))
            {
                player.gameObject.GetComponent<PlayerController>().hp--;
                //Empurra o player
                if (transform.position.x >= player.transform.position.x)
                {
                    if (transform.eulerAngles[1] == 180) player.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 15);
                    else player.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 15);
                }
                else if (transform.position.x < player.transform.position.x)
                {
                    if (transform.eulerAngles[1] == 180) player.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 15);
                    else player.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 15);
                }
            }
        }
    }

        // Update is called once per frame
        void Update()
    {
        //Conta e reseta o tempo para o som
        if (timer) time += Time.deltaTime;
        if (time >= 0.2)
        {
            time = 0;
            timer = false;
        }
        if (esqueleto)
        {
            if (esqueleto.hp <= 0)
            {
                if (!this.GetComponent<Animator>().GetBool("isDead")) audios[1].PlayOneShot(audios[1].clip);
                this.GetComponent<Animator>().SetBool("isDead", true);
                this.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        else if (skull_lava) {
            if (skull_lava.hp <= 0)
            {
                if (!this.GetComponent<Animator>().GetBool("isDead")) audios[1].PlayOneShot(audios[1].clip);
                this.GetComponent<Animator>().SetBool("isDead", true);
                this.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        else if (hellwolf)
        {
            if (hellwolf.hp <= 0)
            {
                if (!this.GetComponent<Animator>().GetBool("isDead")) audios[1].PlayOneShot(audios[1].clip);
                this.GetComponent<Animator>().SetBool("isDead", true);
                this.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        if (player.gameObject.GetComponent<PlayerController>().hp <= 0) Application.LoadLevel(player.gameObject.scene.name);
    }
}
