using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsqueletosIA : MonoBehaviour {

    private float time=0;
    public int hp = 30;

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("dead"))
        {
            time += Time.deltaTime;
            if(time<=5) transform.Translate(Vector2.left * Time.deltaTime);
            else if (time > 5 && time < 10)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                transform.Translate(Vector2.right * Time.deltaTime);
            }
            else if (time >= 10)
            {
                time = 0;
                GetComponent<SpriteRenderer>().flipX = false;
                transform.Translate(Vector2.left * Time.deltaTime);
            }
        }
    }
}
