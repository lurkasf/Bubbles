using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InfoScript : MonoBehaviour {
    public bool updatear;
    public bool IsActive;
    public int velocidade;

    //Color Transpw = new Color(0, 0, 0, 0);
    //Color TranspB = new Color(1, 1, 1, 0);
    public void AtivaInfo(string InfoTexto)
    {
        gameObject.GetComponentInChildren<Text>().text = InfoTexto;
        gameObject.GetComponentInChildren<Text>().color = new Color(0,0,0,0); ;
        updatear = true;
    }
    public void DesativaBool()
    {
        updatear = false;
    }
    private void Update()
    {
        if (updatear)
        {
            gameObject.GetComponent<Image>().color = Color.Lerp(gameObject.GetComponent<Image>().color, new Color(1,1,1,0.7f), Time.deltaTime * velocidade);
            gameObject.GetComponentInChildren<Text>().color = Color.Lerp(gameObject.GetComponentInChildren<Text>().color, new Color(0, 0, 0, 1), Time.deltaTime * velocidade);
            
        }
        else
        {
            gameObject.GetComponent<Image>().color = Color.Lerp(gameObject.GetComponent<Image>().color, new Color(1, 1, 1, 0), Time.deltaTime * velocidade);
            gameObject.GetComponentInChildren<Text>().color = Color.Lerp(gameObject.GetComponentInChildren<Text>().color, new Color(0,0,0,0), Time.deltaTime * velocidade);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            updatear = false;
        }
    }




}
