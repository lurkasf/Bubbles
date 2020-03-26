#region Código Pontuation
#region Bibliotecas
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
#endregion
public class Pontuation : MonoBehaviour {
    #region Variaveis etc

    public static int dificuldade = 20;
    public enum Types
    {
        Infinito,
        Fases,
        Relogio
    }
    public Types ModoDeJogo;
    public static int Points;
    public Text Texto1;
    public Text Texto2;
    public Text Texto3;
    public int resta;
    public int QuantoPorFase=20;
    public int RecordeAtual;
    public GameObject ProxFase;
    #endregion
#region Fuções Unity

    private void Start()
    {
        Time.timeScale = 1;
        resta = resta + QuantoPorFase;
        Points = 0;//Inicia a fase com zero pontos;
        //PlayerPrefs.DeleteAll(); //Isso deleta os recordes ou outras coisas salvas;
        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "RecordeAtual"))//Verifica a existência de um recorde anterior;
        {
            RecordeAtual = PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "RecordeAtual");//Seta o recorde da fase como o que está salvo anteriormente;
        }
        Texto3.text = "Recorde:" + RecordeAtual.ToString();//O texto que aparece no painel de recorde recebe o recorde atual, seja ele zero ou um anterior;
    }
    private void Update()
    {
        if (Points>RecordeAtual)// Se ultrapasso o recorde;
        {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "RecordeAtual", Points);// Salva o novo recorde na memória;
            RecordeAtual = Points;// Salva o recorde na variavel local;
            Texto3.text = "Recorde:" + RecordeAtual.ToString(); // Escreve novo recorde para o usuário;
        }

        switch (ModoDeJogo)
        {
            case Types.Infinito:
                Texto1.text = Points.ToString(); //mostra os ponto
                break;
            case Types.Fases:
                Texto1.text = Points.ToString() + "/" + resta.ToString();// mostra os ponto e a meta
                break;
            case Types.Relogio:
                Texto1.text = Points.ToString(); // mostra os ponto
                break;
        }
        Texto2.text = RecordeAtual.ToString(); 
        if (resta - Points <= 0 && resta - Points > -2) // O que tá acontecendo aqui;
        {
            resta = resta + Points;
            Points = 0;
            dificuldade++;
            //SceneManager.GetActiveScene().ToString();
            PlayerPrefs.SetInt("Dificuldade", PlayerPrefs.GetInt("Dificuldade")+1);
            print(PlayerPrefs.GetInt("Dificuldade"));
            //SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());
            //SceneManager.LoadScene(5);
            //Time.timeScale = 0;
            //ProxFase.SetActive(true);
        }
    }
#endregion
}
#endregion