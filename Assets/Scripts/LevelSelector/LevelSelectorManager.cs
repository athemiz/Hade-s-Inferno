using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectorManager : MonoBehaviour {
    private RectTransform selector_img;
    private RectTransform fase1_img;
    private RectTransform fase2_img;
    private RectTransform fase3_img;
    private RectTransform fase4_img;
    private RectTransform fase5_img;

    // Use this for initialization
    void Start () {
        selector_img = GetComponent<RectTransform>();
        fase1_img = GameObject.Find("Fase 1").GetComponent<RectTransform>();
        fase2_img = GameObject.Find("Fase 2-3").GetComponent<RectTransform>();
        fase3_img = GameObject.Find("Fase 4-5").GetComponent<RectTransform>();
        fase4_img = GameObject.Find("Fase 6-7").GetComponent<RectTransform>();
        fase5_img = GameObject.Find("Fase 8-9").GetComponent<RectTransform>();
        selector_img.transform.position = fase1_img.transform.position;
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (selector_img.transform.position == fase1_img.transform.position) selector_img.transform.position = fase2_img.transform.position;
            else if (selector_img.transform.position == fase2_img.transform.position) selector_img.transform.position = fase3_img.transform.position;
            else if (selector_img.transform.position == fase3_img.transform.position) selector_img.transform.position = fase4_img.transform.position;
            else if (selector_img.transform.position == fase4_img.transform.position) selector_img.transform.position = fase5_img.transform.position;
            else if (selector_img.transform.position == fase5_img.transform.position) selector_img.transform.position = fase1_img.transform.position;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (selector_img.transform.position == fase1_img.transform.position) selector_img.transform.position = fase5_img.transform.position;
            else if (selector_img.transform.position == fase2_img.transform.position) selector_img.transform.position = fase1_img.transform.position;
            else if (selector_img.transform.position == fase3_img.transform.position) selector_img.transform.position = fase2_img.transform.position;
            else if (selector_img.transform.position == fase4_img.transform.position) selector_img.transform.position = fase3_img.transform.position;
            else if (selector_img.transform.position == fase5_img.transform.position) selector_img.transform.position = fase4_img.transform.position;
        }

        if (selector_img.transform.position == fase1_img.transform.position) Debug.Log(selector_img.transform.position.y);
        if (selector_img.transform.position == fase1_img.transform.position && Input.GetKey(KeyCode.Space)) Application.LoadLevel("Fase 1");
        else if (selector_img.transform.position == fase2_img.transform.position && Input.GetKey(KeyCode.Space)) Application.LoadLevel("Fase 2");
        else if (selector_img.transform.position == fase3_img.transform.position && Input.GetKey(KeyCode.Space)) Application.LoadLevel("Fase 3");
        else if (selector_img.transform.position == fase4_img.transform.position && Input.GetKey(KeyCode.Space)) Application.LoadLevel("Fase 4");
        else if (selector_img.transform.position == fase5_img.transform.position && Input.GetKey(KeyCode.Space)) Application.LoadLevel("Fase 5");
    }
}
