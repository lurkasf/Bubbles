#region Bibliotecas
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
#endregion
public class TrocaCenas : MonoBehaviour {
    //public bool IsMenu;
    public void Reseta()    //Função reseta para apagar os dados do jogo, pode ser usada em um botão no menu
    {
        PlayerPrefs.DeleteAll();
    }
    public void Mudar(int Qual)
    {
        SceneManager.LoadScene(Qual, LoadSceneMode.Single);

    }
    public void ReiniciaScene()
    {
        SceneManager.LoadScene(5, LoadSceneMode.Single);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) /*&& !IsMenu*/)
        {
            SceneManager.LoadScene(0);
        }
    }
    public void AtivaDesativaObj(GameObject buli)
    {
        buli.SetActive(!buli.activeSelf);
    }
    public void MudaTimeScale(float time)
    {
        Time.timeScale = time;
    } 
}
