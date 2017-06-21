using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("aaaa");
            Application.LoadLevel("LevelSelect");
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
