using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour {

    public GameObject player;
    public GameObject barqueiro;
    public GameObject hades;
    public GameObject dBox;
    public GameObject cutscenes;
    public Text dText;
    public Text dName;
    private Scene scene;

    public bool dialogActive;

    private int i = 0;
    public bool binativo = false;
    public bool fase1 = false;
    public bool fase2 = false;
    public bool fase3 = false;
    public bool fase4 = false;
    public bool fase5 = false;
    public bool castelo = false;
    public bool boss = false;
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
    public void Fase1Dialog()
    {
        string[] dialogo = new string[] { "Ao que tudo indica estou me aproximando do Rio Aqueronte, o rio do submundo.",
            "Hades seu miseravel me espere, estou indo de encontro a você para buscar minha vingança.", };
        string[] nome = new string[] { "Vioder", "Vioder" };
        if (!fase1) ShowBox(dialogo, nome);
    }
    public void Fase2Dialog()
    {
        string[] dialogo = new string[] { "Bem vindo ao infernos de Cemiterio de Fogo e Colinas de Rocha. Aqui estão confinados todos aqueles que desdenham a minha existencia.",
            "As almas dos condenados ardem eternamente no poço de lava e todas as suas lembranças são transformadas em rocha formando todas as colinas desse lugar.",
            "Espero que sua jornada termine aqui, junto com os outros." };
        string[] nome = new string[] { "HADES", "HADES", "HADES" };
        if (!fase2) ShowBox(dialogo, nome);
    }
    public void Fase3Dialog()
    {
        string[] dialogo = new string[] { "Bem vindo ao inferno do Rio Estinge e do Lago de Lama. Todos que viveram suas vidas com ira e ganancia terminam aqui.",
            "As almas dos que se foram ficam atoladas na lama impossibilidades de se libertarem enquanto as aguas violentas do rio Estige as torturam impiedosamente." };
        string[] nome = new string[] { "HADES", "HADES" };
        if (!fase3) ShowBox(dialogo, nome);
    }
    public void Fase4Dialog()
    {
        string[] dialogo = new string[] { "Bem vindo ao Cocite, o inferno do gelo e ao Vale dos Ventos. Aqui é o destino de todos aqueles que cometeram qualquer tipo de traição.",
            "O frio e os ventos congelantes desse inferno aprissionam as almas desse lugar.  O frio é tão intenso que nenhum vestigio de calor é encontrado aqui." };
        string[] nome = new string[] { "HADES", "HADES"};
        if (!fase4) ShowBox(dialogo, nome);
    }
    public void Fase5Dialog()
    {
        string[] dialogo = new string[] { "Bem vindo ao inferno de Flegetonte e Malebolge. Violencia e fraude são os principais pecados das pessoas que aqui estão aprissionadas.",
            "As almas daqui percorrem o deserto dia após dia sem destino como forma de pagar suas atrocidades cometidas em vida." };
        string[] nome = new string[] { "HADES", "HADES" };
        if (!fase5) ShowBox(dialogo, nome);
    }
    public void CasteloDialog()
    {
        string[] dialogo = new string[] { "Incrivel mortal, você acaba de chegar no meu castelo. Espero ansiosamente sua morte em meus aposentos. Hahaha!" };
        string[] nome = new string[] { "HADES" };
        if (!castelo) ShowBox(dialogo, nome);
    }
    public void HadesDialog()
    {
        string[] dialogo = new string[] { "Hades seu miseravel, devolva as almas das pessoas da minha vila.",
        "Seu feito em atravessar meus 9 infernos é respeitavel humano, tenho que admitir, mas as almas ja são minhas.",
        "Então terei que tira-las a força de você.",
        "Idiota, como ousa desafiar um deus em seus proprios dominios. Você não vai sair daqui com vida.",
        "A minha vida não é nada se comparada as almas dos meus amigos",
        "Se faz tanta questão assim de morrer, irei providenciar que isto aconteça." };
        string[] nome = new string[] { "Vioder", "HADES", "Vioder", "HADES", "Vioder", "HADES" };
        if (!boss) ShowBox(dialogo, nome);
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

            if (scene.name == "Fase 1" && fase1)
            {
                cutscenes.SetActive(true);
                binativo = true;
            }
            if (scene.name == "Fase 1") fase1 = true;
            if (scene.name == "Fase 2") fase2 = true;
            if (scene.name == "Fase 3") fase3 = true;
            if (scene.name == "Fase 4") fase4 = true;
            if (scene.name == "Fase 5") fase5 = true;
            if (scene.name == "Castelo" && castelo) boss = true;
            if (scene.name == "Castelo" && !boss) castelo = true;
        }
    }

	// Use this for initialization
	void Start () {
        scene = SceneManager.GetActiveScene();
	}
	
	// Update is called once per frame
	void Update () {
        if (scene.name=="Fase 1") BarqueiroDialog();
        if (scene.name == "Fase 1") Fase1Dialog();
        if (scene.name == "Fase 2") Fase2Dialog();
        if (scene.name == "Fase 3") Fase3Dialog();
        if (scene.name == "Fase 4") Fase4Dialog();
        if (scene.name == "Fase 5") Fase5Dialog();
        if (scene.name == "Castelo") CasteloDialog();
        if (scene.name == "Castelo" && System.Math.Abs(player.transform.position.x - hades.transform.position.x) <= 5) HadesDialog();
    }
}
