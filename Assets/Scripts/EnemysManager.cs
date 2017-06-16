using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysManager : MonoBehaviour {

    public int hp = 30;
    public GameObject player;
    public Rigidbody2D body;
    
	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
	}

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && player.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("punch"))
        {
            hp--;
            if (player.transform.eulerAngles[1] == 180) body.AddForce(Vector2.left * 15);
            else body.AddForce(Vector2.right * 15);
        }
        else if (collision.gameObject.tag == "Player" && !player.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("punch"))
        {
            player.gameObject.GetComponent<PlayerController>().hp--;
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

    // Update is called once per frame
    void Update () {
        Debug.Log(player.GetComponent<PlayerController>().hp);
        if (hp <= 0) Destroy(this.gameObject);
        if (player.gameObject.GetComponent<PlayerController>().hp<=0) Destroy(player.gameObject);
    }
}
