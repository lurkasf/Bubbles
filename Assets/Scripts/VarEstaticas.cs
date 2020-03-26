using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class VarEstaticas : MonoBehaviour
{
    public Toggle togli;
    public static bool somActive;

    public void SetSom(bool var)
    {
        somActive = var;
        if(var)
        {
            PlayerPrefs.SetInt("SomActive", 1);
        }
        else
            PlayerPrefs.SetInt("SomActive", 0);
       
        if (var)
        {
            print("ligado");
        }
        else
            print("desligado");
    }
    public void SetDific(int var)
    {
        PlayerPrefs.SetInt("Dific", var);
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey("SomActive"))
        {
            PlayerPrefs.SetInt("SomActive",1);
        }

        if (PlayerPrefs.GetInt("SomActive") == 0)
        {
            togli.isOn = false;
            somActive = false;
        }
        else
        {
            somActive = true;
            togli.isOn = true;
        }
    }
}
