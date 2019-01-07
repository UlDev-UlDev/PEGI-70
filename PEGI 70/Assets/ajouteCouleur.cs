using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ajouteCouleur : MonoBehaviour {

    private int NumLigne;
    private int NumCol;
    private Image PionVisé;
    private Color couleur;
    private Image Pion;
    private Image Reponse;
    private Image Led;
    private bool LignePleine;

    public void ajoute()
    {
        NumLigne = int.Parse(GameObject.Find("Text_numLigne").GetComponent<Text>().text);
        NumCol = int.Parse(this.transform.parent.name.Substring(this.transform.parent.name.Length - 1));
        PionVisé = GameObject.Find("Ligne " + NumLigne).transform.Find("Pion " + NumCol).GetComponent<Image>();
        couleur = this.GetComponent<Image>().color;
        PionVisé.color = couleur;
    }

    public void incremente()
    {
        LignePleine = true;

        NumLigne = int.Parse(GameObject.Find("Text_numLigne").GetComponent<Text>().text);

        for (int i = 1; i < 5; i++)
        {
            Pion = GameObject.Find("Ligne " + NumLigne).transform.Find("Pion " + i).GetComponent<Image>();
            if (Pion.color == GameObject.Find("PionType").GetComponent<Image>().color)
            {
                LignePleine = false;
            }
        }

        if (LignePleine == true)
        {
            verif();
            GameObject.Find("Text_numLigne").GetComponent<Text>().text = (NumLigne + 1).ToString();
            if (NumLigne+1 == 11)
            {
                BTN_Ferme.MenuSansContinuer();
                GameObject.Find("Cache").SetActive(false);
            }
        }
    }

    public void verif()
    {
        LignePleine = true;

        NumLigne = int.Parse(GameObject.Find("Text_numLigne").GetComponent<Text>().text);

        for (int i = 1; i < 5; i++)
        {
            Pion = GameObject.Find("Ligne " + NumLigne).transform.Find("Pion " + i).GetComponent<Image>();
            Led = GameObject.Find("Ligne " + NumLigne).transform.Find("Verif " + i).GetComponent<Image>();
            Reponse = GameObject.Find("Ligne 0").transform.Find("Pion " + i).GetComponent<Image>();

            if (Pion.color == Reponse.color) // Bon et bien placé
            {
                Led.color = new Color(0, 255, 0);
            } else //pas bon et placé
            {
                LignePleine = false;
                for (int j = 1; j < 5; j++) // tout n'est pas bon
                {
                    Reponse = GameObject.Find("Ligne 0").transform.Find("Pion " + j).GetComponent<Image>(); //parcours les pions réponses
                    if (Pion.color == Reponse.color) // les compare à notre pion à vérifier
                    {
                        Led.color = new Color(255, 255, 255);
                    }
                }
            }
        }

        if (LignePleine == true) //si tout bon
        {
            Vector3 scale = GameObject.Find("MenuFin").GetComponent<Transform>().localScale;
            scale.Set(1, 1, 1);
            GameObject.Find("MenuFin").GetComponent<Transform>().localScale = scale;
            GameObject.Find("Cache").SetActive(false);

            if ((PlayerPrefs.GetInt("HighScoreMastermind",11) > NumLigne) || PlayerPrefs.GetInt("HighScoreMastermind",0) ==0)
            {
                PlayerPrefs.SetInt("HighScoreMastermind", NumLigne);
            }

        }
    }

}
