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
    public GameObject hellwolf;
    private HellwolfIA hellwolfIA;
    public GameObject hades;
    private HadesIA hadesIA;
    public GameObject hp;
    public GameObject stamina;
    public GameObject hp_red;
    private int temp;

	// Use this for initialization
	void Start () {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (player)
        {
            hp.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(player.GetComponent<PlayerController>().hp, hp.GetComponent<Image>().rectTransform.sizeDelta.y);
            hp_red.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(player.GetComponent<PlayerController>().Maxhp, hp.GetComponent<Image>().rectTransform.sizeDelta.y);
            stamina.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(player.GetComponent<PlayerController>().sta, stamina.GetComponent<Image>().rectTransform.sizeDelta.y);
        }
        else if (esqueleto) hp.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(esqueleto.GetComponent<EsqueletosIA>().hp, hp.GetComponent<Image>().rectTransform.sizeDelta.y);
        else if (skull_lava) hp.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(skull_lava.GetComponent<Skull_lavaIA>().hp, hp.GetComponent<Image>().rectTransform.sizeDelta.y);
        else if (hellwolf) hp.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(hellwolf.GetComponent<HellwolfIA>().hp, hp.GetComponent<Image>().rectTransform.sizeDelta.y);
        else if (hades) hp.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(hades.GetComponent<HadesIA>().hp, hp.GetComponent<Image>().rectTransform.sizeDelta.y);
    }
}
