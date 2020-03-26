using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoresShow : MonoBehaviour {


    public Text Modo1Text, Modo2Text, Modo3Text;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnEnable()
    {
        Modo1Text.text = PlayerPrefs.GetInt("Timer" + "RecordeAtual").ToString();
        Modo2Text.text = PlayerPrefs.GetInt("Fase de Testes" + "RecordeAtual").ToString();
        Modo3Text.text = PlayerPrefs.GetInt("Progressivo(OLD)" + "RecordeAtual").ToString();
    }
}
