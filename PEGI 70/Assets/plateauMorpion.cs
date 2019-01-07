using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class plateauMorpion : MonoBehaviour
{
    public static bool gagné;
    public bool gagnédebug;
    public static bool perdu;
    public bool perdudebug;


    // Use this for initialization
    void Start () {
        gagné = false;
        perdu = false;
	}

    void Update()
    {
        gagnédebug = gagné;
        perdudebug = perdu;
    }


    public static void verif_J1()
    {
        int nb = 0;



        //verif par ligne
        for (int i = 1; i < 4; i++)
        {
            for (int j = 1; j < 4; j++)
            {
                if (GameObject.Find("Ligne " + i).transform.Find("CASE " + j).GetComponent<Image>().sprite == GameObject.Find("Image_J1").GetComponent<Image>().sprite)
                {
                    nb = nb + 1;
                }
            }
            if (nb == 3)
            {
                gagné = true;
            }
            nb = 0;
        }

        //verif par colonne
        for (int i = 1; i < 4; i++)
        {
            for (int j = 1; j < 4; j++)
            {
                if (GameObject.Find("Ligne " + j).transform.Find("CASE " + i).GetComponent<Image>().sprite == GameObject.Find("Image_J1").GetComponent<Image>().sprite)
                {
                    nb = nb + 1;
                }
            }
            if (nb == 3)
            {
                gagné = true;
            }
            nb = 0;
        }


        //verif diag1

        if(GameObject.Find("Ligne " + 1).transform.Find("CASE " + 1).GetComponent<Image>().sprite == GameObject.Find("Image_J1").GetComponent<Image>().sprite
            & GameObject.Find("Ligne " + 2).transform.Find("CASE " + 2).GetComponent<Image>().sprite == GameObject.Find("Image_J1").GetComponent<Image>().sprite
            & GameObject.Find("Ligne " + 3).transform.Find("CASE " + 3).GetComponent<Image>().sprite == GameObject.Find("Image_J1").GetComponent<Image>().sprite)
        {
            gagné = true;
        }


        //verif diag2

        if (GameObject.Find("Ligne " + 1).transform.Find("CASE " + 3).GetComponent<Image>().sprite == GameObject.Find("Image_J1").GetComponent<Image>().sprite
            & GameObject.Find("Ligne " + 2).transform.Find("CASE " + 2).GetComponent<Image>().sprite == GameObject.Find("Image_J1").GetComponent<Image>().sprite
            & GameObject.Find("Ligne " + 3).transform.Find("CASE " + 1).GetComponent<Image>().sprite == GameObject.Find("Image_J1").GetComponent<Image>().sprite)
        {
            gagné = true;
        }
    }


    public static void verif_J2()
    {
        int nb = 0;



        //verif par ligne
        for (int i = 1; i < 4; i++)
        {
            for (int j = 1; j < 4; j++)
            {
                if (GameObject.Find("Ligne " + i).transform.Find("CASE " + j).GetComponent<Image>().sprite == GameObject.Find("Image_J2").GetComponent<Image>().sprite)
                {
                    nb = nb + 1;
                }
            }
            if (nb == 3)
            {
                perdu = true;
            }
            nb = 0;
        }

        //verif par colonne
        for (int i = 1; i < 4; i++)
        {
            for (int j = 1; j < 4; j++)
            {
                if (GameObject.Find("Ligne " + j).transform.Find("CASE " + i).GetComponent<Image>().sprite == GameObject.Find("Image_J2").GetComponent<Image>().sprite)
                {
                    nb = nb + 1;
                }
            }
            if (nb == 3)
            {
                perdu = true;
            }
            nb = 0;
        }


        //verif diag1

        if (GameObject.Find("Ligne " + 1).transform.Find("CASE " + 1).GetComponent<Image>().sprite == GameObject.Find("Image_J2").GetComponent<Image>().sprite
            & GameObject.Find("Ligne " + 2).transform.Find("CASE " + 2).GetComponent<Image>().sprite == GameObject.Find("Image_J2").GetComponent<Image>().sprite
            & GameObject.Find("Ligne " + 3).transform.Find("CASE " + 3).GetComponent<Image>().sprite == GameObject.Find("Image_J2").GetComponent<Image>().sprite)
        {
            perdu = true;
        }


        //verif diag2

        if (GameObject.Find("Ligne " + 1).transform.Find("CASE " + 3).GetComponent<Image>().sprite == GameObject.Find("Image_J2").GetComponent<Image>().sprite
            & GameObject.Find("Ligne " + 2).transform.Find("CASE " + 2).GetComponent<Image>().sprite == GameObject.Find("Image_J2").GetComponent<Image>().sprite
            & GameObject.Find("Ligne " + 3).transform.Find("CASE " + 1).GetComponent<Image>().sprite == GameObject.Find("Image_J2").GetComponent<Image>().sprite)
        {
            perdu = true;
        }
    }


    public static void IA()
    {
        if (verifattaque() == 1) { return; };
        if (verifbloque() == 1) { return; };
        couprandom();
    }


    public static void couprandom()
    {

        //création d'une variable random (générateur de nombre au hasard)
        System.Random rdm = new System.Random();
        int ligne, colonne;
        do // attribution d'un nombre random entre les bornes à x et y et d'une valeur random entre 1 et 2
        {
            ligne = rdm.Next(1, 4);
            colonne = rdm.Next(1, 4);
        } while (GameObject.Find("Ligne " + ligne).transform.Find("CASE " + colonne).GetComponent<Image>().sprite != null);

        GameObject.Find("Ligne " + ligne).transform.Find("CASE " + colonne).GetComponent<Image>().sprite = GameObject.Find("Image_J2").GetComponent<Image>().sprite;

        GameObject.Find("Ligne " + ligne).transform.Find("CASE " + colonne).GetComponent<Image>().color = GameObject.Find("Image_J2").GetComponent<Image>().color;
    }


    public static int verifbloque()
    {
        int nb = 0;



        //verif par ligne
        for (int i = 1; i < 4; i++)
        {
            for (int j = 1; j < 4; j++)
            {
                if (GameObject.Find("Ligne " + i).transform.Find("CASE " + j).GetComponent<Image>().sprite == GameObject.Find("Image_J1").GetComponent<Image>().sprite)
                {
                    nb = nb + 1;
                }
            }
            if (nb == 2)
            {
                for (int k = 1; k < 4; k++)
                {
                    if (GameObject.Find("Ligne " + i).transform.Find("CASE " + k).GetComponent<Image>().sprite == null)
                    {
                        GameObject.Find("Ligne " + i).transform.Find("CASE " + k).GetComponent<Image>().sprite = GameObject.Find("Image_J2").GetComponent<Image>().sprite;
                        GameObject.Find("Ligne " + i).transform.Find("CASE " + k).GetComponent<Image>().color = GameObject.Find("Image_J2").GetComponent<Image>().color;
                        return 1;
                    }
                }
            }
            nb = 0;
        }

        //verif par colonne
        for (int i = 1; i < 4; i++)
        {
            for (int j = 1; j < 4; j++)
            {
                if (GameObject.Find("Ligne " + j).transform.Find("CASE " + i).GetComponent<Image>().sprite == GameObject.Find("Image_J1").GetComponent<Image>().sprite)
                {
                    nb = nb + 1;
                }
            }
            if (nb == 2)
            {
                for (int k = 1; k < 4; k++)
                {
                    if (GameObject.Find("Ligne " + k).transform.Find("CASE " + i).GetComponent<Image>().sprite == null)
                    {
                        GameObject.Find("Ligne " + k).transform.Find("CASE " + i).GetComponent<Image>().sprite = GameObject.Find("Image_J2").GetComponent<Image>().sprite;
                        GameObject.Find("Ligne " + k).transform.Find("CASE " + i).GetComponent<Image>().color = GameObject.Find("Image_J2").GetComponent<Image>().color;
                        return 1;
                    }
                }
            }
            nb = 0;
        }




        //verif diag1
        nb = 0;
        if (GameObject.Find("Ligne " + 1).transform.Find("CASE " + 1).GetComponent<Image>().sprite == GameObject.Find("Image_J1").GetComponent<Image>().sprite) { nb = nb + 1; }
        if (GameObject.Find("Ligne " + 2).transform.Find("CASE " + 2).GetComponent<Image>().sprite == GameObject.Find("Image_J1").GetComponent<Image>().sprite) { nb = nb + 1; }
        if (GameObject.Find("Ligne " + 3).transform.Find("CASE " + 3).GetComponent<Image>().sprite == GameObject.Find("Image_J1").GetComponent<Image>().sprite) { nb = nb + 1; }
        
        if (nb==2)
        {
            if (GameObject.Find("Ligne " + 1).transform.Find("CASE " + 1).GetComponent<Image>().sprite == null) { GameObject.Find("Ligne " + 1).transform.Find("CASE " + 1).GetComponent<Image>().sprite = GameObject.Find("Image_J2").GetComponent<Image>().sprite; GameObject.Find("Ligne " + 1).transform.Find("CASE " + 1).GetComponent<Image>().color = GameObject.Find("Image_J2").GetComponent<Image>().color; return 1; }
            if (GameObject.Find("Ligne " + 2).transform.Find("CASE " + 2).GetComponent<Image>().sprite == null) { GameObject.Find("Ligne " + 2).transform.Find("CASE " + 2).GetComponent<Image>().sprite = GameObject.Find("Image_J2").GetComponent<Image>().sprite; GameObject.Find("Ligne " + 2).transform.Find("CASE " + 2).GetComponent<Image>().color = GameObject.Find("Image_J2").GetComponent<Image>().color; return 1; }
            if (GameObject.Find("Ligne " + 3).transform.Find("CASE " + 3).GetComponent<Image>().sprite == null) { GameObject.Find("Ligne " + 3).transform.Find("CASE " + 3).GetComponent<Image>().sprite = GameObject.Find("Image_J2").GetComponent<Image>().sprite; GameObject.Find("Ligne " + 3).transform.Find("CASE " + 3).GetComponent<Image>().color = GameObject.Find("Image_J2").GetComponent<Image>().color; return 1; }
        }


        //verif diag2
        nb = 0;
        if (GameObject.Find("Ligne " + 1).transform.Find("CASE " + 3).GetComponent<Image>().sprite == GameObject.Find("Image_J1").GetComponent<Image>().sprite) { nb = nb + 1; }
        if (GameObject.Find("Ligne " + 2).transform.Find("CASE " + 2).GetComponent<Image>().sprite == GameObject.Find("Image_J1").GetComponent<Image>().sprite) { nb = nb + 1; }
        if (GameObject.Find("Ligne " + 3).transform.Find("CASE " + 1).GetComponent<Image>().sprite == GameObject.Find("Image_J1").GetComponent<Image>().sprite) { nb = nb + 1; }

        if (nb == 2)
        {
            if (GameObject.Find("Ligne " + 1).transform.Find("CASE " + 3).GetComponent<Image>().sprite == null) { GameObject.Find("Ligne " + 1).transform.Find("CASE " + 3).GetComponent<Image>().sprite = GameObject.Find("Image_J2").GetComponent<Image>().sprite; GameObject.Find("Ligne " + 1).transform.Find("CASE " + 3).GetComponent<Image>().color = GameObject.Find("Image_J2").GetComponent<Image>().color; return 1; }
            if (GameObject.Find("Ligne " + 2).transform.Find("CASE " + 2).GetComponent<Image>().sprite == null) { GameObject.Find("Ligne " + 2).transform.Find("CASE " + 2).GetComponent<Image>().sprite = GameObject.Find("Image_J2").GetComponent<Image>().sprite; GameObject.Find("Ligne " + 2).transform.Find("CASE " + 2).GetComponent<Image>().color = GameObject.Find("Image_J2").GetComponent<Image>().color; return 1; }
            if (GameObject.Find("Ligne " + 3).transform.Find("CASE " + 1).GetComponent<Image>().sprite == null) { GameObject.Find("Ligne " + 3).transform.Find("CASE " + 1).GetComponent<Image>().sprite = GameObject.Find("Image_J2").GetComponent<Image>().sprite; GameObject.Find("Ligne " + 3).transform.Find("CASE " + 1).GetComponent<Image>().color = GameObject.Find("Image_J2").GetComponent<Image>().color; return 1; }
        }







        return 0;
    }


    public static bool estplein()
    {
        bool reponse = true;

        for (int i = 1; i < 4; i++)
        {
            for (int j = 1; j < 4; j++)
            {
                if ((GameObject.Find("Ligne " + i).transform.Find("CASE " + j).GetComponent<Image>().sprite == null) || (GameObject.Find("Ligne " + i).transform.Find("CASE " + j).GetComponent<Image>().color == new Color(0.5f,0.5f,0.5f)))
                {
                    reponse = false;
                }
            }
        }

        return reponse;
    }


    public static int verifattaque()
    {
        int nb = 0;



        //verif par ligne
        for (int i = 1; i < 4; i++)
        {
            for (int j = 1; j < 4; j++)
            {
                if (GameObject.Find("Ligne " + i).transform.Find("CASE " + j).GetComponent<Image>().sprite == GameObject.Find("Image_J2").GetComponent<Image>().sprite)
                {
                    nb = nb + 1;
                }
            }
            if (nb == 2)
            {
                for (int k = 1; k < 4; k++)
                {
                    if (GameObject.Find("Ligne " + i).transform.Find("CASE " + k).GetComponent<Image>().sprite == null)
                    {
                        GameObject.Find("Ligne " + i).transform.Find("CASE " + k).GetComponent<Image>().sprite = GameObject.Find("Image_J2").GetComponent<Image>().sprite;
                        GameObject.Find("Ligne " + i).transform.Find("CASE " + k).GetComponent<Image>().color = GameObject.Find("Image_J2").GetComponent<Image>().color;
                        return 1;
                    }
                }
            }
            nb = 0;
        }

        //verif par colonne
        for (int i = 1; i < 4; i++)
        {
            for (int j = 1; j < 4; j++)
            {
                if (GameObject.Find("Ligne " + j).transform.Find("CASE " + i).GetComponent<Image>().sprite == GameObject.Find("Image_J2").GetComponent<Image>().sprite)
                {
                    nb = nb + 1;
                }
            }
            if (nb == 2)
            {
                for (int k = 1; k < 4; k++)
                {
                    if (GameObject.Find("Ligne " + k).transform.Find("CASE " + i).GetComponent<Image>().sprite == null)
                    {
                        GameObject.Find("Ligne " + k).transform.Find("CASE " + i).GetComponent<Image>().sprite = GameObject.Find("Image_J2").GetComponent<Image>().sprite;
                        GameObject.Find("Ligne " + k).transform.Find("CASE " + i).GetComponent<Image>().color = GameObject.Find("Image_J2").GetComponent<Image>().color;
                        return 1;
                    }
                }
            }
            nb = 0;
        }




        //verif diag1
        nb = 0;
        if (GameObject.Find("Ligne " + 1).transform.Find("CASE " + 1).GetComponent<Image>().sprite == GameObject.Find("Image_J2").GetComponent<Image>().sprite) { nb = nb + 1; }
        if (GameObject.Find("Ligne " + 2).transform.Find("CASE " + 2).GetComponent<Image>().sprite == GameObject.Find("Image_J2").GetComponent<Image>().sprite) { nb = nb + 1; }
        if (GameObject.Find("Ligne " + 3).transform.Find("CASE " + 3).GetComponent<Image>().sprite == GameObject.Find("Image_J2").GetComponent<Image>().sprite) { nb = nb + 1; }

        if (nb == 2)
        {
            if (GameObject.Find("Ligne " + 1).transform.Find("CASE " + 1).GetComponent<Image>().sprite == null) { GameObject.Find("Ligne " + 1).transform.Find("CASE " + 1).GetComponent<Image>().sprite = GameObject.Find("Image_J2").GetComponent<Image>().sprite; GameObject.Find("Ligne " + 1).transform.Find("CASE " + 1).GetComponent<Image>().color = GameObject.Find("Image_J2").GetComponent<Image>().color; return 1; }
            if (GameObject.Find("Ligne " + 2).transform.Find("CASE " + 2).GetComponent<Image>().sprite == null) { GameObject.Find("Ligne " + 2).transform.Find("CASE " + 2).GetComponent<Image>().sprite = GameObject.Find("Image_J2").GetComponent<Image>().sprite; GameObject.Find("Ligne " + 2).transform.Find("CASE " + 2).GetComponent<Image>().color = GameObject.Find("Image_J2").GetComponent<Image>().color; return 1; }
            if (GameObject.Find("Ligne " + 3).transform.Find("CASE " + 3).GetComponent<Image>().sprite == null) { GameObject.Find("Ligne " + 3).transform.Find("CASE " + 3).GetComponent<Image>().sprite = GameObject.Find("Image_J2").GetComponent<Image>().sprite; GameObject.Find("Ligne " + 3).transform.Find("CASE " + 3).GetComponent<Image>().color = GameObject.Find("Image_J2").GetComponent<Image>().color; return 1; }
        }


        //verif diag2
        nb = 0;
        if (GameObject.Find("Ligne " + 1).transform.Find("CASE " + 3).GetComponent<Image>().sprite == GameObject.Find("Image_J2").GetComponent<Image>().sprite) { nb = nb + 1; }
        if (GameObject.Find("Ligne " + 2).transform.Find("CASE " + 2).GetComponent<Image>().sprite == GameObject.Find("Image_J2").GetComponent<Image>().sprite) { nb = nb + 1; }
        if (GameObject.Find("Ligne " + 3).transform.Find("CASE " + 1).GetComponent<Image>().sprite == GameObject.Find("Image_J2").GetComponent<Image>().sprite) { nb = nb + 1; }

        if (nb == 2)
        {
            if (GameObject.Find("Ligne " + 1).transform.Find("CASE " + 3).GetComponent<Image>().sprite == null) { GameObject.Find("Ligne " + 1).transform.Find("CASE " + 3).GetComponent<Image>().sprite = GameObject.Find("Image_J2").GetComponent<Image>().sprite; GameObject.Find("Ligne " + 1).transform.Find("CASE " + 3).GetComponent<Image>().color = GameObject.Find("Image_J2").GetComponent<Image>().color; return 1; }
            if (GameObject.Find("Ligne " + 2).transform.Find("CASE " + 2).GetComponent<Image>().sprite == null) { GameObject.Find("Ligne " + 2).transform.Find("CASE " + 2).GetComponent<Image>().sprite = GameObject.Find("Image_J2").GetComponent<Image>().sprite; GameObject.Find("Ligne " + 2).transform.Find("CASE " + 2).GetComponent<Image>().color = GameObject.Find("Image_J2").GetComponent<Image>().color; return 1; }
            if (GameObject.Find("Ligne " + 3).transform.Find("CASE " + 1).GetComponent<Image>().sprite == null) { GameObject.Find("Ligne " + 3).transform.Find("CASE " + 1).GetComponent<Image>().sprite = GameObject.Find("Image_J2").GetComponent<Image>().sprite; GameObject.Find("Ligne " + 3).transform.Find("CASE " + 1).GetComponent<Image>().color = GameObject.Find("Image_J2").GetComponent<Image>().color; return 1; }
        }







        return 0;
    }

}
