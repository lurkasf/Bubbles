using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
                                                
public class BolhaPuft : MonoBehaviour
{
    public AudioClip som1;
    public AudioClip som2;
    //AudioSource autifalati;
    public enum Types
    {
        Infinito,
        Fases,
        Relogio
    }
    public Types ModoDeJogo;
    //RaycastHit2D hit;
    public int respawnTimeMin;
    public int respawnTimeMax;
    public int DistCenterMaxX;
    public int DistCenterMaxY;
    public int DistCenterSpawn;
    public GameObject centro;
    public GameObject fora;
    
    public bool IsForaPermission;
    public bool IsBonus;
    public int BonusTime;
    public static int multiplicator;
    public bool Voltou = false;

    void VerificaDistancia()
    {
        if (transform.position.y - centro.transform.position.y < -DistCenterMaxY && !IsForaPermission)
        {
            IsForaPermission = true;
            BolhaSair();
            //return true;
            //IsForaPermission = true;
            //StartCoroutine(Respawn());
            //não StartCoroutine(Respawn());
        }
        if (transform.position.y - centro.transform.position.y > DistCenterMaxY && !IsForaPermission)
        {
            IsForaPermission = true;
            BolhaSair();
            //return true;
            //IsForaPermission = true;
            //StartCoroutine(Respawn());
            // não StartCoroutine(Respawn());
        }
        if (transform.position.x - centro.transform.position.x < -DistCenterMaxX && !IsForaPermission)
        {
            IsForaPermission = true;
            BolhaSair();
            //return true;
            //IsForaPermission = true;
            //StartCoroutine(Respawn());
            //não StartCoroutine(Respawn());
        }
        if (transform.position.x - centro.transform.position.x > DistCenterMaxX && !IsForaPermission)
        {
            IsForaPermission = true;
            BolhaSair();
            //return true;
            //IsForaPermission = true;
            //StartCoroutine(Respawn());
            // não StartCoroutine(Respawn());
        }
        //return false;
    }

    public void BolhaSair()
    {
        //transform.position = fora.transform.position;
        Voltou = false;
        transform.position = fora.transform.position;
        StartCoroutine(Respawn());
    }
    void Voltar()
    {
        if (!Voltou)
        {
            Vector3 SpawnAleatorio =
            new Vector3
                    (Random.Range(centro.transform.position.x - DistCenterSpawn, centro.transform.position.x + DistCenterSpawn),
                     Random.Range(centro.transform.position.y - DistCenterSpawn, centro.transform.position.y + DistCenterSpawn), 0);
            transform.gameObject.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0.1f, 0.9f), Random.Range(0.1f, 0.9f), Random.Range(0.1f, 0.9f), 1);
            transform.position = SpawnAleatorio;
            Voltou = true;
            IsForaPermission = false;
        }
    }


    private void Start()
    {
        transform.GetComponent<AudioSource>().clip = som1;
        //autifalati.clip = som1;
        IsForaPermission = true;
        Voltar();
        multiplicator = 1;
    }
    private void OnMouseDown()
    {
        if (IsBonus)
        {
            transform.GetComponent<AudioSource>().clip = som2;
            transform.GetComponent<AudioSource>().Play();
            multiplicator = 2;
            StartCoroutine(BonusFim());
        }
        else
        {
            transform.GetComponent<AudioSource>().clip = som1;
            transform.GetComponent<AudioSource>().Play();
        }
        Pontuation.Points = Pontuation.Points + multiplicator;
        BolhaSair();
    }
    private void FixedUpdate()
    {
        if (multiplicator == 2)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0.3f, 0.8f), Random.Range(0.3f, 0.8f), Random.Range(0.3f, 0.8f));
        }
        if (!IsForaPermission)
        {
            VerificaDistancia();
        }
    }
    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(Random.Range(respawnTimeMin, respawnTimeMax));
        Voltar();
    }
    IEnumerator BonusFim()
    {
        yield return new WaitForSeconds(BonusTime);
        multiplicator = 1;
    }
}
