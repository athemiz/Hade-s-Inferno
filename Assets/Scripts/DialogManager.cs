using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

    public GameObject player;
    public GameObject barqueiro;
    public GameObject dBox;
    public Text dText;
    public Text dName;

    public bool dialogActive;

    public int i = 0;
    public bool binativo = false;
    public void BarqueiroDialog()
    {
        string[] dialogo = new string[] { "O que um mortal como você faz aqui, na margem do rio dos mortos?",
            "Tenho contas a acertar com o deus do submundo, barqueiro. Me leve ate a outra margem.",
            "Você esta louco?",
            "Sabe dos perigos que terá que enfrentar ate chegar ao mestre Hades? Os infernos são lugares inospitos para reles mortais.",
            "Não me interessa quais perigos terei pela frente. So terei paz quando conseguir terminar minha jornada.",
            "Você é mesmo um tolo. Sua alma será consumida e o mestre Hades irá possui-la pela eternidade.",
            "É um risco que estou disposto a enfrentar.", "Então, vai me levar a outra margem do rio barqueiro?",
            "Com todo prazer!",
            "Espero que sua estadia no inferno seja a pior possivel. Hahahahaha" };
        string[] nome = new string[] {"Caronte", "Vioder", "Caronte", "Caronte", "Vioder", "Caronte", "Vioder", "Vioder", "Caronte", "Caronte" };
        if (barqueiro.transform.position.x - player.transform.position.x < 5 && !binativo) ShowBox(dialogo, nome);
    }

    public void ShowBox(string[] dialogue, string[] nome) {
        dBox.SetActive(true);
        dialogActive = true;
        dText.text = dialogue[i];
        dName.text = nome[i];
        player.gameObject.GetComponent<PlayerController>().enabled = false;
        if (dialogActive && Input.GetKeyDown(KeyCode.Space) && i != dialogue.Length-1)
        {
            i++;
            dName.text = nome[i];
            dText.text = dialogue[i];
        }
        else if(i==dialogue.Length-1 && Input.GetKeyDown(KeyCode.Space))
        {
            player.SetActive(true);
            binativo = true;
            dBox.SetActive(false);
            dialogActive = false;
            player.gameObject.GetComponent<PlayerController>().enabled = true;
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        BarqueiroDialog();
	}
}
