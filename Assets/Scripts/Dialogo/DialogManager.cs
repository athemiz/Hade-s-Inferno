using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour {

    public GameObject player;
    public GameObject barqueiro;
    public GameObject dBox;
    public GameObject cutscenes;
    public Text dText;
    public Text dName;
    private Scene scene;

    public bool dialogActive;

    private int i = 0;
    public bool binativo = false;
    public bool fase2 = false;
    public bool fase3 = false;
    public bool fase4 = false;
    public bool fase5 = false;
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
        if (barqueiro.transform.position.x - player.transform.position.x <= 3 && !binativo) ShowBox(dialogo, nome);
    }
    public void Fase2Dialog()
    {
        string[] dialogo = new string[] { "O qugfdgfde um mortal como você faz aqui, na margem do rio dos mortos?",
            "Tenho contas a acertar com o deus do submundo, barqueiro. Me leve ate a outra margem.",
            "Você esta louco?",
            "Sabe dos perigos que terá que enfrentar ate chegar ao mestre Hades? Os infernos são lugares inospitos para reles mortais.",
            "Não me interessa quais perigos terei pela frente. So terei paz quando conseguir terminar minha jornada.",
            "Você é mesmo um tolo. Sua alma será consumida e o mestre Hades irá possui-la pela eternidade.",
            "É um risco que estou disposto a enfrentar.", "Então, vai me levar a outra margem do rio barqueiro?",
            "Com todo prazer!",
            "Espero que sua estadia no inferno seja a pior possivel. Hahahahaha" };
        string[] nome = new string[] { "Caronte", "Vioder", "Caronte", "Caronte", "Vioder", "Caronte", "Vioder", "Vioder", "Caronte", "Caronte" };
        if(!fase2) ShowBox(dialogo, nome);
    }
    public void Fase3Dialog()
    {
        string[] dialogo = new string[] { "O qugfdgfde um mortal como você faz aqui, na margem do rio dos mortos?",
            "Tenho contas a acertar com o deus do submundo, barqueiro. Me leve ate a outra margem.",
            "Você esta louco?",
            "Sabe dos perigos que terá que enfrentar ate chegar ao mestre Hades? Os infernos são lugares inospitos para reles mortais.",
            "Não me interessa quais perigos terei pela frente. So terei paz quando conseguir terminar minha jornada.",
            "Você é mesmo um tolo. Sua alma será consumida e o mestre Hades irá possui-la pela eternidade.",
            "É um risco que estou disposto a enfrentar.", "Então, vai me levar a outra margem do rio barqueiro?",
            "Com todo prazer!",
            "Espero que sua estadia no inferno seja a pior possivel. Hahahahaha" };
        string[] nome = new string[] { "Caronte", "Vioder", "Caronte", "Caronte", "Vioder", "Caronte", "Vioder", "Vioder", "Caronte", "Caronte" };
        if (!fase3) ShowBox(dialogo, nome);
    }
    public void Fase4Dialog()
    {
        string[] dialogo = new string[] { "O qugfdgfde um mortal como você faz aqui, na margem do rio dos mortos?",
            "Tenho contas a acertar com o deus do submundo, barqueiro. Me leve ate a outra margem.",
            "Você esta louco?",
            "Sabe dos perigos que terá que enfrentar ate chegar ao mestre Hades? Os infernos são lugares inospitos para reles mortais.",
            "Não me interessa quais perigos terei pela frente. So terei paz quando conseguir terminar minha jornada.",
            "Você é mesmo um tolo. Sua alma será consumida e o mestre Hades irá possui-la pela eternidade.",
            "É um risco que estou disposto a enfrentar.", "Então, vai me levar a outra margem do rio barqueiro?",
            "Com todo prazer!",
            "Espero que sua estadia no inferno seja a pior possivel. Hahahahaha" };
        string[] nome = new string[] { "Caronte", "Vioder", "Caronte", "Caronte", "Vioder", "Caronte", "Vioder", "Vioder", "Caronte", "Caronte" };
        if (!fase4) ShowBox(dialogo, nome);
    }
    public void Fase5Dialog()
    {
        string[] dialogo = new string[] { "O qugfdgfde um mortal como você faz aqui, na margem do rio dos mortos?",
            "Tenho contas a acertar com o deus do submundo, barqueiro. Me leve ate a outra margem.",
            "Você esta louco?",
            "Sabe dos perigos que terá que enfrentar ate chegar ao mestre Hades? Os infernos são lugares inospitos para reles mortais.",
            "Não me interessa quais perigos terei pela frente. So terei paz quando conseguir terminar minha jornada.",
            "Você é mesmo um tolo. Sua alma será consumida e o mestre Hades irá possui-la pela eternidade.",
            "É um risco que estou disposto a enfrentar.", "Então, vai me levar a outra margem do rio barqueiro?",
            "Com todo prazer!",
            "Espero que sua estadia no inferno seja a pior possivel. Hahahahaha" };
        string[] nome = new string[] { "Caronte", "Vioder", "Caronte", "Caronte", "Vioder", "Caronte", "Vioder", "Vioder", "Caronte", "Caronte" };
        if (!fase5) ShowBox(dialogo, nome);
    }

    public void ShowBox(string[] dialogue, string[] nome) {
        dBox.SetActive(true);
        dialogActive = true;
        dText.text = dialogue[i];
        dName.text = nome[i];
        player.gameObject.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<Animator>().SetBool("isRunning", false);
        player.GetComponent<Animator>().SetBool("isPunching", false);
        player.GetComponent<Animator>().SetBool("isJumping", false);
        if (dialogActive && Input.GetKeyDown(KeyCode.Space) && i != dialogue.Length-1)
        {
            i++;
            dName.text = nome[i];
            dText.text = dialogue[i];
        }
        else if(i==dialogue.Length-1 && Input.GetKeyDown(KeyCode.Space))
        {
            player.SetActive(true);
            dBox.SetActive(false);
            dialogActive = false;
            player.gameObject.GetComponent<PlayerController>().enabled = true;

            if (scene.name == "Fase 1")
            {
                cutscenes.SetActive(true);
                binativo = true;
            }
            if (scene.name == "Fase 2") fase2 = true;
            if (scene.name == "Fase 3") fase3 = true;
            if (scene.name == "Fase 4") fase4 = true;
            if (scene.name == "Fase 5") fase5 = true;
        }
    }

	// Use this for initialization
	void Start () {
        scene = SceneManager.GetActiveScene();
	}
	
	// Update is called once per frame
	void Update () {
        if (scene.name=="Fase 1") BarqueiroDialog();
        if (scene.name == "Fase 2") Fase2Dialog();
        if (scene.name == "Fase 3") Fase3Dialog();
        if (scene.name == "Fase 4") Fase4Dialog();
        if (scene.name == "Fase 5") Fase5Dialog();
    }
}
