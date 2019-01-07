using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTN_Ferme : MonoBehaviour {

	public static void MenuAvecContinuer()
    {
        Vector3 scale = GameObject.Find("MenuFin").GetComponent<Transform>().localScale;
        scale.Set(1, 1, 1);
        GameObject.Find("MenuFin").GetComponent<Transform>().localScale = scale;
   
        GameObject.Find("MenuFin").transform.Find("Continuer").GetComponent<Transform>().localScale = scale;
    }

    public static void MenuSansContinuer()
    {
        Vector3 scale = GameObject.Find("MenuFin").GetComponent<Transform>().localScale;
        scale.Set(1, 1, 1);
        GameObject.Find("MenuFin").GetComponent<Transform>().localScale = scale;
    }

    public static void FermeMenuAvecContinuer()
    {
        Vector3 scale = GameObject.Find("MenuFin").GetComponent<Transform>().localScale;
        scale.Set(0, 0, 0);
        GameObject.Find("MenuFin").transform.Find("Continuer").GetComponent<Transform>().localScale = scale;
       
        GameObject.Find("MenuFin").GetComponent<Transform>().localScale = scale;

    }


    public void MenuAvecContinuer1()
    {
        Vector3 scale = GameObject.Find("MenuFin").GetComponent<Transform>().localScale;
        scale.Set(1, 1, 1);
        GameObject.Find("MenuFin").GetComponent<Transform>().localScale = scale;

        GameObject.Find("MenuFin").transform.Find("Continuer").GetComponent<Transform>().localScale = scale;
    }

    public void MenuSansContinuer1()
    {
        Vector3 scale = GameObject.Find("MenuFin").GetComponent<Transform>().localScale;
        scale.Set(1, 1, 1);
        GameObject.Find("MenuFin").GetComponent<Transform>().localScale = scale;
    }

    public void FermeMenuAvecContinuer1()
    {
        Vector3 scale = GameObject.Find("MenuFin").GetComponent<Transform>().localScale;
        scale.Set(0, 0, 0);
        GameObject.Find("MenuFin").transform.Find("Continuer").GetComponent<Transform>().localScale = scale;

        GameObject.Find("MenuFin").GetComponent<Transform>().localScale = scale;

    }
}
