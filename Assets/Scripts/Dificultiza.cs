using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Dificultiza : MonoBehaviour
{
    //public static int dificuldade;
    int aux;
    public GameObject BolhaExtra1, BolhaExtra2, BolhaExtra3, BolhaExtra4;
    void Start ()
    {
        BolhaExtra1.SetActive(false);
        BolhaExtra2.SetActive(false);
        BolhaExtra3.SetActive(false);
        BolhaExtra4.SetActive(false);
    }
	void Update ()
    {
        if (PlayerPrefs.HasKey("Dificuldade"))
        {

            aux = PlayerPrefs.GetInt("Dificuldade");
            if (aux == 1)
            {
                BolhaExtra1.SetActive(true);
            }
            if (aux == 2)
            {
                BolhaExtra2.SetActive(true);
            }
            if (aux >= 3)
            {
                BolhaExtra3.SetActive(true);
            }
        }

    }
}
