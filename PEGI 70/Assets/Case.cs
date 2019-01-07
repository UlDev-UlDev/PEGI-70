using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Case : MonoBehaviour {
    private int numLigne;
    private int numCol;
    public Sprite test;

    // Use this for initialization
    void Start () {
        numLigne = int.Parse(this.transform.parent.name.Substring(5));
        numCol = int.Parse(this.name.Substring(4));
    }
	
	// Update is called once per frame
	void Update () {
		
	}



    public void OnMouseOver()
    {
        if (this.GetComponent<Image>().sprite == null)
        {
            this.GetComponent<Image>().sprite = GameObject.Find("Image_J1").GetComponent<Image>().sprite;
            this.GetComponent<Image>().color = new Color(0.5f,0.5f,0.5f);
        }
    }

    public void OnMouseExit()
    {
       if (this.GetComponent<Image>().color == new Color(0.5f, 0.5f, 0.5f))
        {
            this.GetComponent<Image>().sprite = null;
            this.GetComponent<Image>().color = new Color(255,255,255);
        }
    }


    public void clique()
    {
        if ((this.GetComponent<Image>().sprite == null || this.GetComponent<Image>().color == new Color(0.5f, 0.5f, 0.5f)) & plateauMorpion.gagné==false & plateauMorpion.perdu == false & plateauMorpion.estplein() == false)
        {
            this.GetComponent<Image>().sprite = GameObject.Find("Image_J1").GetComponent<Image>().sprite;
            this.GetComponent<Image>().color = GameObject.Find("Image_J1").GetComponent<Image>().color;
            plateauMorpion.verif_J1();
            if (plateauMorpion.gagné == false & plateauMorpion.estplein()==false)
            {
                plateauMorpion.IA();
                plateauMorpion.verif_J2();
            }

            if (plateauMorpion.gagné == true || plateauMorpion.perdu == true || plateauMorpion.estplein() == true)
            {
                BTN_Ferme.MenuSansContinuer();
            }
        }
    }

  
}
