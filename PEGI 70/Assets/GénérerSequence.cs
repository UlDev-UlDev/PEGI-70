using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GénérerSequence : MonoBehaviour {
    private Color Couleur;
    private Image Pion;
    private int random;

	// Use this for initialization
	void Start () {

        System.Random rdn = new System.Random();

        for (int i = 1; i < 5; i++)
        {
            Pion = GameObject.Find("Ligne 0").transform.Find("Pion " + i).GetComponent<Image>();

            random = rdn.Next(1, 11);
            switch (random)
            {
                case 1:
                    Couleur = GameObject.Find("Choix 1").transform.Find("R").GetComponent<Image>().color;
                    break;
                case 2:
                    Couleur = GameObject.Find("Choix 1").transform.Find("V").GetComponent<Image>().color;
                    break;
                case 3:
                    Couleur = GameObject.Find("Choix 1").transform.Find("B").GetComponent<Image>().color;
                    break;
                case 4:
                    Couleur = GameObject.Find("Choix 1").transform.Find("Vi").GetComponent<Image>().color;
                    break;
                case 5:
                    Couleur = GameObject.Find("Choix 1").transform.Find("N").GetComponent<Image>().color;
                    break;
                case 6:
                    Couleur = GameObject.Find("Choix 1").transform.Find("Blc").GetComponent<Image>().color;
                    break;
                case 7:
                    Couleur = GameObject.Find("Choix 1").transform.Find("O").GetComponent<Image>().color;
                    break;
                case 8:
                    Couleur = GameObject.Find("Choix 1").transform.Find("J").GetComponent<Image>().color;
                    break;
                case 9:
                    Couleur = GameObject.Find("Choix 1").transform.Find("Rse").GetComponent<Image>().color;
                    break;
                case 10:
                    Couleur = GameObject.Find("Choix 1").transform.Find("M").GetComponent<Image>().color;
                    break;
                default:
                    Couleur = GameObject.Find("Choix 1").transform.Find("N").GetComponent<Image>().color;
                    break;
            }
            Pion.color = Couleur;

        }
    }
}
