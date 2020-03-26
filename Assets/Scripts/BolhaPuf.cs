using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;

public class BolhaPuf : MonoBehaviour {

    //RaycastHit2D hit;
    public int respawnTimeMin;
    public int respawnTimeMax;
    public int DistCenterMaxX;
    public int DistCenterMaxY;
    public int DistCenterSpawn;
    public GameObject centro;
    public bool IsBonus;
    public static int multiplicator;
    public int BonusTime;

    private void Start()
    {
        StartCoroutine(Await());
        multiplicator = 1;
    }


    private void OnMouseDown()
    {
        Pontuation.Points = Pontuation.Points + multiplicator;
        StartCoroutine(Respawn());
        if (IsBonus)
        {
            transform.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
            multiplicator = 2;
            StartCoroutine(BonusFim());
        }
        

    }
    void Voltar()
    {
        transform.gameObject.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0.1f, 0.9f), Random.Range(0.1f, 0.9f), Random.Range(0.1f, 0.9f), 1);
        transform.position = new Vector3
                (Random.Range(centro.transform.position.x - DistCenterSpawn, centro.transform.position.x + DistCenterSpawn),
                 Random.Range(centro.transform.position.y - DistCenterSpawn, centro.transform.position.y + DistCenterSpawn), 0);
    }

    private void Update()
    {
        if (!IsBonus)
        {
            if (transform.position.y - centro.transform.position.y < -DistCenterMaxY)
            {
                Voltar();
                //não StartCoroutine(Respawn());
            }
            if (transform.position.y - centro.transform.position.y > DistCenterMaxY)
            {
                Voltar();
                // não StartCoroutine(Respawn());
            }
            if (transform.position.x - centro.transform.position.x < -DistCenterMaxX)
            {
                Voltar();
                //não StartCoroutine(Respawn());
            }
            if (transform.position.x - centro.transform.position.x > DistCenterMaxX)
            {
                Voltar();
                // não StartCoroutine(Respawn());
            }
        }
    }
    IEnumerator Respawn()
    {
        if(!IsBonus)
        transform.gameObject.GetComponent<SpriteRenderer>().color = new Color(255,255,255,0);

        //Voltar();
        yield return new WaitForSeconds(Random.Range(respawnTimeMin,respawnTimeMax));
        Voltar();
        if (IsBonus)
        {
            //multiplicator = 1;
            StartCoroutine(Respawn());
        }
        
    }

    IEnumerator Await()
    {
        yield return new WaitForSeconds(1);
        if (IsBonus)
        {
            StartCoroutine(Respawn());
        }
        StopCoroutine(Await());
    }
    /*IEnumerator SpecialRespawn()
    {
        //Voltar();
        yield return new WaitForSeconds(Random.Range(respawnTimeMin, respawnTimeMax));
        Voltar();
        StartCoroutine(SpecialRespawn());
    }*/
    IEnumerator BonusFim()
    {
        yield return new WaitForSeconds(BonusTime);
        multiplicator = 1;
    }

}
