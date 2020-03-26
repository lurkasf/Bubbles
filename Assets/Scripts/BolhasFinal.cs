#region Código BolhasFinal.cs

                                        // ESTA É UMA CÓPIA DESCARADA DE  "BolhaPuft", MAIS UMAS ADIÇÕES //
#region BIBLIOTECAS
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
#endregion
#region CLASSE DAS BOLHAS
public class BolhasFinal : MonoBehaviour
{
    
#region Variáveis e Tal 
    public AudioClip som1;
    public AudioClip som2;
    public enum Types
    {
        Infinito,
        Fases,
        Relogio
    }
    public Types ModoDeJogo;
    public enum BolhaType
    {
        Normal,
        Bonus,
        Menos,
        Lento,
        Rapido
    }
    public BolhaType TipoBolha;
    public int respawnTimeMin;  // Tempo mínimo que a bolha leva para voltar, quando clicada ou quando escapada;
    public int respawnTimeMax;  // Tempo máximo que a bolha leva para voltar, quando clicada ou quando escapada;
    public int DistCenterMaxX;  // Distância máxima que a bola pode ficar do centro no eixo X sem ter que voltar;
    public int DistCenterMaxY;  // Distância máxima que a bola pode ficar do centro no eixo Y sem ter que voltar;
    public int DistCenterSpawn; // Distância máxima de spawn quando a bolha voltar;
    public GameObject centro;   // Centro usado para verificar a distância da bolha
    public GameObject fora;     // Objeto suja posição é usada para teleportar as bolhas em aso de clique; //(talvez em caso de saída tbm);
    public bool IsForaPermission;   // Permissão que é concedida quando a bolha é intencionalmente colocada do lado de fora;
    //public bool IsBonus;            // Caso for uma bolha bônus, esta variável deve receber o valor true (no editor), para o programa aggir de forma diferente;
    public int BonusTime;           // Duração do bônus de multiplicador;
    public static int multiplicator;// Multiplicador para a bolha bônus, seu valor será adicionado à pontuação;(PADRÃO: 1)
    public bool Voltou = false;     // Verifica se a bolha já voltou, não sei se é extremamente necessário, coloquei por precaução;
#endregion 

#region Funções Para Cada Modo de Jogo
    // essas funções precisam ser configuradas para cada caso, pois ainda está genérico;
    void ModoInfinito()
    {
        Pontuation.Points += multiplicator;
        BolhaSair();
    }
    void ModoFases()
    {
        Pontuation.Points = Pontuation.Points + multiplicator;
        BolhaSair();
    }
    void ModoTimer()
    {
        Pontuation.Points = Pontuation.Points + multiplicator;
        BolhaSair();
    }
#endregion

#region Funções Genéricas
    void Clicou()               // realiza a verificação do modo de jogo para chamar os procedimentos específicos de cada uma.
    {

        /*if (IsBonus) // Caso seja uma bolha bônus, o multiplcador sai do padrão(1) para o bônue (2);
        {
            transform.GetComponent<AudioSource>().clip = som2;
            
            multiplicator = 2;
            StopCoroutine(BonusFim());
            StartCoroutine(BonusFim()); // Um timer para que o tempo de bônus acabe;
        }
        else
        {
            transform.GetComponent<AudioSource>().clip = som1;
        }*/
        switch (TipoBolha)
        {
            case BolhaType.Normal:
                transform.GetComponent<AudioSource>().clip = som1;
                
                break;
            case BolhaType.Bonus:
                transform.GetComponent<AudioSource>().clip = som2;
                multiplicator = 2;
                StopCoroutine(BonusFim());
                StartCoroutine(BonusFim());
                break;
            case BolhaType.Lento:
                transform.GetComponent<AudioSource>().clip = som2;
                Time.timeScale = Time.timeScale * 0.5f;
                break;
            case BolhaType.Menos:
                Pontuation.Points /= 2;  
                transform.GetComponent<AudioSource>().clip = som2;
                
                break;
            case BolhaType.Rapido:
                transform.GetComponent<AudioSource>().clip = som2;
                Time.timeScale = Time.timeScale* 2;
                break;
        }


        transform.GetComponent<AudioSource>().Play(); // toca o som independente do tipo de bolha
        switch (ModoDeJogo)
        {
            case Types.Infinito:
                ModoInfinito();
                break;
            case Types.Fases:
                ModoFases();
                break;
            case Types.Relogio:
                ModoTimer();
                break;
            default:
                break;
        }
    }
    void VerificaDistancia()    // Verifica se a bolha está fora e avisa que Saiu() quando estiver fora. (Chamada em Update)
    {
        if(!IsForaPermission && 
        transform.position.y - centro.transform.position.y < -DistCenterMaxY ||
        transform.position.y - centro.transform.position.y >  DistCenterMaxY ||
        transform.position.x - centro.transform.position.x < -DistCenterMaxX ||
        transform.position.x - centro.transform.position.x > DistCenterMaxX   )
        {
            Saiu();
        }
        #region Opcional
        /*if (transform.position.y - centro.transform.position.y < -DistCenterMaxY && !IsForaPermission)
        {
            Saiu();
        }
        if (transform.position.y - centro.transform.position.y > DistCenterMaxY && !IsForaPermission)
        {
            Saiu();
        }
        if (transform.position.x - centro.transform.position.x < -DistCenterMaxX && !IsForaPermission)
        {
            Saiu();
        }
        if (transform.position.x - centro.transform.position.x > DistCenterMaxX && !IsForaPermission)
        {
            Saiu();
        }*/
        #endregion
    }
    void Saiu()                 // Realiza os procedimentos necessários quando a bolha(self) estiver do lado de fora, seja por click ou por movimento próprio;
    {
        IsForaPermission = true;
        BolhaSair();
    }
    void BolhaSair()//public?   // Manda a bolha sair(é chamada no ckick-> Clicou()-> FunçõesDeModo());
    {
        IsForaPermission = true;
        Voltou = false;
        transform.position = fora.transform.position;
        StartCoroutine(Respawn());
    }
    void Voltar()               // Manda a bolha voltar para a área visível para o jogador
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
    void PiscaLoko()            // função que faz cada bolha piscar loucamente quando o bônus (multiplicador == 2) está ativo;
    {
        if (multiplicator == 2)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0.3f, 0.8f), Random.Range(0.3f, 0.8f), Random.Range(0.3f, 0.8f));
            //gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(gameObject.GetComponent<Image>().color, new Color(Random.Range(0.3f, 0.8f), Random.Range(0.3f, 0.8f), Random.Range(0.3f, 0.8f)), Time.deltaTime * 5);
        }
    }
#endregion

#region Funções Unity
    private void Start()
    {
        //??????????transform.GetComponent<Rigidbody2D>().gravityScale = transform.GetComponent<Rigidbody2D>().gravityScale * (PlayerPrefs.GetInt("Dific") * 0.5f);

        if (!VarEstaticas.somActive)
        {
            transform.GetComponent<AudioSource>().mute = true;
        }
        IsForaPermission = true;//pq?
        Voltar();               //pq?
        multiplicator = 1;      //seta o valor de todas as bolhas para 1;
        //gameObject.GetComponent<Rigidbody2D>().gravityScale = gameObject.GetComponent<Rigidbody2D>().gravityScale + 10;
    }
    private void OnEnable()
    {
        if (!VarEstaticas.somActive)
        {
            transform.GetComponent<AudioSource>().mute = true;
        }
        IsForaPermission = true;
        Voltar();               
        multiplicator = 1;
    }
    private void FixedUpdate()
    {
        PiscaLoko();            //faz piscar no bônus
        if (!IsForaPermission)
        {
            VerificaDistancia();
        }
    }
    #endregion

#region Coroutines
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
    private void OnMouseDown()  //Função Unity que verifica se houve clique em um objeto; //Acho que precisa de um collider nele;
    {
        Clicou();
    }
#endregion
}
#endregion

                                            // ISSO QUE É UM CÓDIGO BONITO MEUS AMIGOS, QUE ORGULHO //
#endregion