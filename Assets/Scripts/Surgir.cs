using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surgir : MonoBehaviour {

    public int time;
    public GameObject Bolha1;
    public GameObject Bolha2;
    public GameObject Bolha3;
	void Start () {
		StartCoroutine("SurgeBolha");
	}
    /*bolhas reutilizáveis*/
    //morre se cair ou for estourada
    //retorna para posição aleatória quando morrer;
	void Update () {
		
	}
    /*IEnumerator SurgeBolha()
    {
        yield return new WaitForSeconds(time);
        Instantiate(Bolha, new Vector3(Random.Range(0,5), Random.Range(0,5), Random.Range(0,5)), Quaternion.Euler(0,0,0));
        StartCoroutine("SurgeBolha");
    }*/

}
