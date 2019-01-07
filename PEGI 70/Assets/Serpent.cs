using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class Serpent : MonoBehaviour {

    private bool Enfoncé;
    private int XTete;
    private int YTete;
    private int[] XCorps = new int[200];
    private int[] YCorps = new int[200];
    private Color couleurpardefaut;
    private int i;
    private int j;
    private bool fini;
    public int enattente;
    private Text ScoreEmplacement;
    private int Score;
    private Text TailleEmplacement;
    private Image JaugeFond;
    private Image JaugeRemplie;
    public Color CouleurTete;
    public Color CouleurCorps;

    // Use this for initialization
    void Start ()
    {
        //recup de la couleur par defaut du terrain
        couleurpardefaut = GameObject.Find("Ligne1").transform.Find("CASE1").GetComponent<Image>().color;
        //colori la case et l'associ a la tete
        GameObject.Find("Ligne1").transform.Find("CASE4").GetComponent<Image>().color = new Color(CouleurTete.r,CouleurTete.g,CouleurTete.b);
        XTete = 4;
        YTete = 1;
        //idem corps
        GameObject.Find("Ligne1").transform.Find("CASE3").GetComponent<Image>().color = new Color(CouleurCorps.r, CouleurCorps.g, CouleurCorps.b);
        XCorps[1] = 3;
        YCorps[1] = 1;
        GameObject.Find("Ligne1").transform.Find("CASE2").GetComponent<Image>().color = new Color(CouleurCorps.r, CouleurCorps.g, CouleurCorps.b);
        XCorps[2] = 2;
        YCorps[2] = 1;
        GameObject.Find("Ligne1").transform.Find("CASE1").GetComponent<Image>().color = new Color(CouleurCorps.r, CouleurCorps.g, CouleurCorps.b);
        XCorps[3] = 1;
        YCorps[3] = 1;

        //fin du serpent
        XCorps[4] = 0;
        YCorps[4] = 0;


        //initialise les variables
        Enfoncé = false;
        fini = false;
        enattente = 0;
        ScoreEmplacement = GameObject.Find("Score").GetComponent<Text>();
        TailleEmplacement = GameObject.Find("Score_taille").GetComponent<Text>();
        Score = 0;
        JaugeFond = GameObject.Find("Image_JaugeFond").GetComponent<Image>();
        JaugeRemplie = GameObject.Find("Image_Jauge").GetComponent<Image>();


        //initaliser la jauge
        RemplirJauge();
    }
	
	// Update is called once per frame
	void Update () {

        if (Enfoncé == false & fini == false)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) == true)
            {
                Avancer(1);
                Enfoncé = true;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) == true)
            {
                Avancer(2);
                Enfoncé = true;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) == true)
            {
                Avancer(3);
                Enfoncé = true;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) == true)
            {
                Avancer(4);
                Enfoncé = true;
            }
        } else //si enfoncé = true
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) == false & Input.GetKeyDown(KeyCode.RightArrow) == false & Input.GetKeyDown(KeyCode.UpArrow) == false & Input.GetKeyDown(KeyCode.DownArrow) == false)
            {
                Enfoncé = false;
            }
        }

        if (fini==true)
        {
            Vector3 scale = GameObject.Find("MenuFin").GetComponent<Transform>().localScale;
            scale.Set(1, 1, 1);
            GameObject.Find("MenuFin").GetComponent<Transform>().localScale = scale;

            if (PlayerPrefs.GetInt("HighScoreSerpent")<Score)
            {
                PlayerPrefs.SetInt("HighScoreSerpent", Score);
            }
        }

    }


    void Avancer(int direction)
    {

        if (SortDeMap(direction) == true)
        {
            return;
        }



        if (enattente == 0)
        {
            //effacer la case actuelle de la queue si il n'a rien dans l'estomac
            GameObject.Find("Ligne" + YCorps[EndOfSnake()].ToString()).transform.Find("CASE" + XCorps[EndOfSnake()].ToString()).GetComponent<Image>().color = couleurpardefaut;
        } else
        {
            YCorps[EndOfSnake() + 1] = YCorps[EndOfSnake()];
            XCorps[EndOfSnake() + 1] = XCorps[EndOfSnake()];
            enattente = enattente - 1;
        }

        for (i = EndOfSnake(); i > 1; i--)
        {
            //incrémenter pour trouver la case finale
            YCorps[i] = YCorps[i - 1];
            XCorps[i] = XCorps[i - 1];
            //repeindre la case finale
            GameObject.Find("Ligne" + YCorps[i].ToString()).transform.Find("CASE" + XCorps[i].ToString()).GetComponent<Image>().color = new Color(CouleurCorps.r, CouleurCorps.g, CouleurCorps.b);
        }
        //idem pour 1 qui prend l'emplacement de la tete
        //incrémenter pour trouver la case finale
        YCorps[i] = YTete;
        XCorps[i] = XTete;
        //repeindre la case finale
        GameObject.Find("Ligne" + YCorps[i].ToString()).transform.Find("CASE" + XCorps[i].ToString()).GetComponent<Image>().color = new Color(CouleurCorps.r, CouleurCorps.g, CouleurCorps.b);



        Color CouleurDeLaCaseVisee;

        //puis la tete
        switch (direction)
        {
            case 1:
                //incrémenter pour trouver la case finale
                YTete = YTete - 1;
                //vérifie la couleur de la case visée
                CouleurDeLaCaseVisee = GameObject.Find("Ligne" + YTete.ToString()).transform.Find("CASE" + XTete.ToString()).GetComponent<Image>().color;
                //repeindre la case finale
                GameObject.Find("Ligne" + YTete.ToString()).transform.Find("CASE" + XTete.ToString()).GetComponent<Image>().color = new Color(CouleurTete.r, CouleurTete.g, CouleurTete.b);
                break;
            case 2:
                XTete = XTete + 1;
                //vérifie la couleur de la case visée
                CouleurDeLaCaseVisee = GameObject.Find("Ligne" + YTete.ToString()).transform.Find("CASE" + XTete.ToString()).GetComponent<Image>().color;
                GameObject.Find("Ligne" + YTete.ToString()).transform.Find("CASE" + XTete.ToString()).GetComponent<Image>().color = new Color(CouleurTete.r, CouleurTete.g, CouleurTete.b);
                //avancer vers la droite
                break;
            case 3:
                YTete = YTete + 1;
                //vérifie la couleur de la case visée
                CouleurDeLaCaseVisee = GameObject.Find("Ligne" + YTete.ToString()).transform.Find("CASE" + XTete.ToString()).GetComponent<Image>().color;
                GameObject.Find("Ligne" + (YTete).ToString()).transform.Find("CASE" + XTete.ToString()).GetComponent<Image>().color = new Color(CouleurTete.r, CouleurTete.g, CouleurTete.b);
                //avancer en bas
                break;
            case 4:
                XTete = XTete - 1;
                //vérifie la couleur de la case visée
                CouleurDeLaCaseVisee = GameObject.Find("Ligne" + YTete.ToString()).transform.Find("CASE" + XTete.ToString()).GetComponent<Image>().color;
                GameObject.Find("Ligne" + (YTete).ToString()).transform.Find("CASE" + XTete.ToString()).GetComponent<Image>().color = new Color(CouleurTete.r, CouleurTete.g, CouleurTete.b);
                //avancer a gauche
                break;
            default:
                CouleurDeLaCaseVisee = couleurpardefaut;
                break;
        }

        //en fonction de la couleur de la case visée, on voit s'il mange une pomme
        if (CouleurDeLaCaseVisee == new Color(255, 0, 0)) //pomme rouge (petite)
        {
            enattente = enattente + 1;
            Score = Score + 2;
            ScoreEmplacement.text = "Score : " + Score.ToString();
            TailleEmplacement.text = "Taille : " + (EndOfSnake() + 1 + enattente).ToString();
            RemplirJauge();
            Pommes.spawn();
        }
        if (CouleurDeLaCaseVisee == new Color(0, 255, 0)) //pomme verte (grosse)
        {
            enattente = enattente + 2;
            SupprimePomme(XTete, YTete);
            Score = Score + 1;
            ScoreEmplacement.text = "Score : " + Score.ToString();
            TailleEmplacement.text = "Taille : " + (EndOfSnake() + 1 + enattente).ToString();
            RemplirJauge();
            Pommes.spawn();

        }

        // si la taille du serpent est supérieure ou égale a 30, fin de jeu
        if ((EndOfSnake() + 1 + enattente) >= 30)
        {
            Vector3 scale = GameObject.Find("MenuFin").GetComponent<Transform>().localScale;
            scale.Set(1, 1, 1);
            GameObject.Find("MenuFin").GetComponent<Transform>().localScale = scale;
            fini = true;
        }

        //verif si la case finale n'appartient pas au corps
        for (i = 1; i <= EndOfSnake(); i++)
        {
            if (YTete == YCorps[i] & XTete == XCorps[i])
            {
                fini = true;
            }
        }
    }

    int EndOfSnake()
    {
        j = 1;
        while (XCorps[j] != 0)
        {
            j = j + 1;
        }
        return j - 1;
    }

    bool SortDeMap(int direction)
    {
        switch (direction)
        {
            case 1:
                //incrémenter pour trouver la case finale
                if (GameObject.Find("Ligne" + (YTete-1).ToString()).transform.Find("CASE" + XTete.ToString()) == null)
                {
                    return true;
                } else
                {
                    return false;
                }
            case 2:
                if (GameObject.Find("Ligne" + YTete.ToString()).transform.Find("CASE" + (XTete+1).ToString()) == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case 3:
                if (GameObject.Find("Ligne" + (YTete+1).ToString()).transform.Find("CASE" + XTete.ToString()) == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case 4:
                if (GameObject.Find("Ligne" + YTete.ToString()).transform.Find("CASE" + (XTete-1).ToString()) == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            default:
                return true;
        }
    }


    void SupprimePomme(int x,int y)
    {
        float z;
        RectTransform CaseMangée;

        //on selectionne la case mangée par le serpent
        CaseMangée = GameObject.Find("Ligne" + y).transform.Find("CASE" + x).GetComponent<RectTransform>();

        //on récupère son z pour savoir quel quart de pomme c'est
        z = CaseMangée.position.z;


        switch (z.ToString()) //on convertie en chaine car switch n'accepte pas les float
        {
            case "1":
                GameObject.Find("Ligne" + y).transform.Find("CASE" + (x + 1).ToString()).GetComponent<Image>().color = couleurpardefaut;
                GameObject.Find("Ligne" + (y + 1).ToString()).transform.Find("CASE" + (x + 1).ToString()).GetComponent<Image>().color = couleurpardefaut;
                GameObject.Find("Ligne" + (y + 1).ToString()).transform.Find("CASE" + (x).ToString()).GetComponent<Image>().color = couleurpardefaut;
                break;
            case "2":
                GameObject.Find("Ligne" + y).transform.Find("CASE" + (x - 1).ToString()).GetComponent<Image>().color = couleurpardefaut;
                GameObject.Find("Ligne" + (y + 1).ToString()).transform.Find("CASE" + (x - 1).ToString()).GetComponent<Image>().color = couleurpardefaut;
                GameObject.Find("Ligne" + (y + 1).ToString()).transform.Find("CASE" + (x).ToString()).GetComponent<Image>().color = couleurpardefaut;
                break;
            case "3":
                GameObject.Find("Ligne" + y).transform.Find("CASE" + (x - 1).ToString()).GetComponent<Image>().color = couleurpardefaut;
                GameObject.Find("Ligne" + (y - 1).ToString()).transform.Find("CASE" + (x - 1).ToString()).GetComponent<Image>().color = couleurpardefaut;
                GameObject.Find("Ligne" + (y - 1).ToString()).transform.Find("CASE" + (x).ToString()).GetComponent<Image>().color = couleurpardefaut;
                break;
            case "4":
                GameObject.Find("Ligne" + y).transform.Find("CASE" + (x + 1).ToString()).GetComponent<Image>().color = couleurpardefaut;
                GameObject.Find("Ligne" + (y - 1).ToString()).transform.Find("CASE" + (x + 1).ToString()).GetComponent<Image>().color = couleurpardefaut;
                GameObject.Find("Ligne" + (y - 1).ToString()).transform.Find("CASE" + (x).ToString()).GetComponent<Image>().color = couleurpardefaut;
                break;
        }

    }


    void RemplirJauge()
    {
        float Taux;
        float Taille;
        float TailleMax;
        float Hauteur;
        float xJauge;
        float yJauge;

        Taux = (EndOfSnake() + 1 + enattente)/30f;
        if (Taux > 1)
        {
            Taux = 1;
        }

        TailleMax = JaugeFond.GetComponent<RectTransform>().sizeDelta.x;
        Hauteur = JaugeFond.GetComponent<RectTransform>().sizeDelta.y;
        yJauge = JaugeFond.GetComponent<RectTransform>().position.y;


        Taille = TailleMax * Taux;
        JaugeRemplie.GetComponent<RectTransform>().sizeDelta = new Vector2(Taille, Hauteur);

        xJauge = JaugeFond.GetComponent<RectTransform>().position.x - (0.5f * TailleMax) + (0.5f * Taille);


        JaugeRemplie.GetComponent<RectTransform>().position = new Vector2(xJauge, yJauge);
    }
}
