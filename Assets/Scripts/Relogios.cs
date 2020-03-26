using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Relogios : MonoBehaviour {
    public enum Types
    {
        Infinito,
        Fases,
        Relogio
    }
    public Types ModoDeJogo;
    public float RelogioCont;
    public Text Relogio;
    public Slider slide;
    public GameObject Painel;
    public GameObject[] Ativandos;
    public GameObject[] Desativandos;
    public int Timer_geral = 25;
    
    // Update is called once per frame
    private void Start()
    {
        switch (ModoDeJogo)
        {
            case Types.Relogio:
                RelogioCont = Timer_geral;
                break;
            case Types.Fases:
                RelogioCont = 0;
                break;
            case Types.Infinito:
                RelogioCont = 0;
                Relogio.text = "∞";
                break;
        }
    }
    void Update () {
        
        if(RelogioCont < 0)
        {
            Relogio.text = "FIM";
            //Time.timeScale = 0;
            //Painel.SetActive(true);
            foreach (GameObject item in Ativandos)
            {
                item.SetActive(true);
            }
            foreach (GameObject item in Desativandos)
            {
                item.SetActive(false);
            }
        }
        else
            switch (ModoDeJogo)
            {
                case Types.Relogio:
                    RelogioCont -= Time.deltaTime;
                    Relogio.text = RelogioCont.ToString("00.00");
                    slide.value = RelogioCont;
                    break;
                case Types.Fases:
                    RelogioCont += Time.deltaTime;
                    Relogio.text = RelogioCont.ToString("00.00");
                    break;
                case Types.Infinito:
                    RelogioCont += Time.deltaTime;
                    Relogio.text = RelogioCont.ToString("00.00");
                    break;
            }
    }
}
