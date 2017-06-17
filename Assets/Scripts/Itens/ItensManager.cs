using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItensManager : MonoBehaviour {

    public GameObject player;
    public AudioSource heal;

	// Use this for initialization
	void Start () {
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            heal.Play();
            player.GetComponent<PlayerController>().hp += 10;
            if (player.GetComponent<PlayerController>().hp > player.GetComponent<PlayerController>().Maxhp) player.GetComponent<PlayerController>().hp = player.GetComponent<PlayerController>().Maxhp;
            this.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
