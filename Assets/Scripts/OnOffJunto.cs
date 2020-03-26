using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffJunto : MonoBehaviour {

    public GameObject[] quais;
    // Use this for initialization
    public void OnDisable()
    {
        foreach (GameObject item in quais)
        {
            item.SetActive(false);
        }
    }
    public void OnEnable()
    {
        foreach (GameObject item in quais)
        {
            item.SetActive(true);
        }
    }
}
