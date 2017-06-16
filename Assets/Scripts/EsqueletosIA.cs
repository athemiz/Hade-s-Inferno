using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsqueletosIA : MonoBehaviour {

    private float time=0;

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
            transform.Translate(Vector2.left * Time.deltaTime);
            if (time > 5 && time < 10)
            {
                transform.eulerAngles = new Vector2(0, 180);
            }
            else if (time >= 10)
            {
                time = 0;
                transform.eulerAngles = new Vector2(0, 0);
            }
        }
    }
}
