using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurvivabilityManager : MonoBehaviour {

    public GameObject player;
    public GameObject esqueleto;
    private EsqueletosIA esqueletoIA;
    public GameObject skull_lava;
    private Skull_lavaIA skull_lavaIA;
    public GameObject hp;
    public GameObject stamina;
    private int temp;

	// Use this for initialization
	void Start () {
        esqueletoIA = esqueleto.GetComponent<EsqueletosIA>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            hp.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(player.GetComponent<PlayerController>().hp, hp.GetComponent<Image>().rectTransform.sizeDelta.y);
            stamina.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(player.GetComponent<PlayerController>().sta, stamina.GetComponent<Image>().rectTransform.sizeDelta.y);
        }
        else if (esqueleto) hp.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(esqueletoIA.GetComponent<EsqueletosIA>().hp, hp.GetComponent<Image>().rectTransform.sizeDelta.y);
        else if (skull_lava) hp.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(skull_lava.GetComponent<Skull_lavaIA>().hp, hp.GetComponent<Image>().rectTransform.sizeDelta.y);
    }
}
