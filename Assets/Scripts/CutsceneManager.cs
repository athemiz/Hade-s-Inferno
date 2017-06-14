using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour {

    public GameObject player;
    public GameObject barqueiro;
    public bool freeze;

	// Use this for initialization
	void Start () {
        player.GetComponent<PlayerController>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        player.GetComponent<Animator>().SetBool("isRunning", true);
        player.transform.Translate(Vector2.right * player.gameObject.GetComponent<PlayerController>().velocidade * Time.deltaTime);
        player.transform.eulerAngles = new Vector2(0, 0);
        if (barqueiro.transform.position.x - player.transform.position.x <= -0.3)
        {
            player.GetComponent<Animator>().SetBool("isRunning", false);
            barqueiro.GetComponent<Animator>().SetBool("Moving", true);
            this.gameObject.SetActive(false);
        }
    }
}
