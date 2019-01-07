using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pommes : MonoBehaviour {
    private static int x;
    private static int y;
    private static int valeur; //car plusieurs types de pommes
    private static Color CouleurParDefaut;

	// Use this for initialization
	void Start () {
        CouleurParDefaut = GameObject.Find("Ligne2").transform.Find("CASE1").GetComponent<Image>().color;


        for (int i = 1; i < 4; i++)
        {
            spawn();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public static void spawn()
    {
        //création d'une variable random (générateur de nombre au hasard)
        System.Random rdm = new System.Random();

        do // attribution d'un nombre random entre les bornes à x et y et d'une valeur random entre 1 et 2
        {
            x = rdm.Next(1, 21);
            y = rdm.Next(1, 11);
            valeur = rdm.Next(1, 3);
        } while (EstVide(x, y,valeur) == false); //tant que la case ciblée n'est pas vide (couleur sol)

        switch (valeur) { //selon le type de la pomme
            case 1: //on colori juste la case en rouge
                GameObject.Find("Ligne" + y.ToString()).transform.Find("CASE" + x.ToString()).GetComponent<Image>().color = new Color(255, 0, 0);
                break;
            case 2: //on colori 4 blocs
                if (x==20)
                {
                    x = 19;
                }
                if (y == 10)
                {
                    y = 9;
                }
                //on colori les cases
                GameObject.Find("Ligne" + y.ToString()).transform.Find("CASE" + x.ToString()).GetComponent<Image>().color = new Color(0, 255, 0);
                GameObject.Find("Ligne" + (y+1).ToString()).transform.Find("CASE" + x.ToString()).GetComponent<Image>().color = new Color(0, 255, 0);
                GameObject.Find("Ligne" + (y+1).ToString()).transform.Find("CASE" + (x+1).ToString()).GetComponent<Image>().color = new Color(0, 255, 0);
                GameObject.Find("Ligne" + y.ToString()).transform.Find("CASE" + (x+1).ToString()).GetComponent<Image>().color = new Color(0, 255, 0);

                //on leur attribut un z pour les différencier
                Vector3 NouvellePosition = new Vector3(0,0,0);

                NouvellePosition = new Vector3(GameObject.Find("Ligne" + y.ToString()).transform.Find("CASE" + x.ToString()).GetComponent<RectTransform>().position.x,
                                               GameObject.Find("Ligne" + y.ToString()).transform.Find("CASE" + x.ToString()).GetComponent<RectTransform>().position.y,
                                               1);
                GameObject.Find("Ligne" + y.ToString()).transform.Find("CASE" + x.ToString()).GetComponent<RectTransform>().position = NouvellePosition;



                NouvellePosition = new Vector3(GameObject.Find("Ligne" + y.ToString()).transform.Find("CASE" + (x + 1).ToString()).GetComponent<RectTransform>().position.x,
                                               GameObject.Find("Ligne" + y.ToString()).transform.Find("CASE" + (x + 1).ToString()).GetComponent<RectTransform>().position.y,
                                               2);
                GameObject.Find("Ligne" + y.ToString()).transform.Find("CASE" + (x + 1).ToString()).GetComponent<RectTransform>().position = NouvellePosition;





                NouvellePosition = new Vector3(GameObject.Find("Ligne" + (y + 1).ToString()).transform.Find("CASE" + (x + 1).ToString()).GetComponent<RectTransform>().position.x,
                                               GameObject.Find("Ligne" + (y + 1).ToString()).transform.Find("CASE" + (x + 1).ToString()).GetComponent<RectTransform>().position.y,
                                               3);
                GameObject.Find("Ligne" + (y + 1).ToString()).transform.Find("CASE" + (x + 1).ToString()).GetComponent<RectTransform>().position = NouvellePosition;





                NouvellePosition = new Vector3(GameObject.Find("Ligne" + (y + 1).ToString()).transform.Find("CASE" + x.ToString()).GetComponent<RectTransform>().position.x,
                                               GameObject.Find("Ligne" + (y + 1).ToString()).transform.Find("CASE" + x.ToString()).GetComponent<RectTransform>().position.y,
                                               4);
                GameObject.Find("Ligne" + (y + 1).ToString()).transform.Find("CASE" + x.ToString()).GetComponent<RectTransform>().position = NouvellePosition;

                break;
        }
    }

    static bool EstVide(int x, int y, int valeur) //vérifie si la case ciblée est vide
    {

        if (valeur == 1)
        {
            if (GameObject.Find("Ligne" + y.ToString()).transform.Find("CASE" + x.ToString()).GetComponent<Image>().color == CouleurParDefaut)
            {
                return true;
            }
            else
            {
                return false;
            }
        } else if (valeur == 2)
        {
            if (x == 20)
            {
                x = 19;
            }
            if (y == 10)
            {
                y = 9;
            }
            if (GameObject.Find("Ligne" + y.ToString()).transform.Find("CASE" + x.ToString()).GetComponent<Image>().color == CouleurParDefaut
                & GameObject.Find("Ligne" + (y+1).ToString()).transform.Find("CASE" + x.ToString()).GetComponent<Image>().color == CouleurParDefaut
                & GameObject.Find("Ligne" + y.ToString()).transform.Find("CASE" + (x+1).ToString()).GetComponent<Image>().color == CouleurParDefaut
                & GameObject.Find("Ligne" + (y+1).ToString()).transform.Find("CASE" + (x+1).ToString()).GetComponent<Image>().color == CouleurParDefaut)
            {
                return true;
            }
            else
            {
                return false;
            }
        } else
        {
            return false;
        }

    }
}
