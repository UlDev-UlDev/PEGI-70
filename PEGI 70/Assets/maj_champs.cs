using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class maj_champs : MonoBehaviour {
    // déclare les variable contenu de ce qu'on va afficher
    public string description_jeu;
    private string titre_jeu;
    public Sprite apercu_jeu;
    public string IndexJeu;
    // déclare les object dans lesquels on veut afficher nos variables
    private Text emplacement_titre, emplacement_description, emplacement_index;
    private Image emplacement_apercu;
    

    public void MettreAJour()
    {
        // on affecte les objects dans lequels on veut afficher nos variables
        emplacement_titre = GameObject.Find("Text_Titre").GetComponent<Text>();
        emplacement_description = GameObject.Find("Text_Descriptif").GetComponent<Text>();
        emplacement_index = GameObject.Find("Text_index").GetComponent<Text>();
        emplacement_apercu = GameObject.Find("Image_ImageJeu").GetComponent<Image>();

        // ce qu'on veut afficher dans Text_Titre, c'est le contenu du bouton (le nom du jeu)
        titre_jeu = this.name;


        // Afficher les valeurs
        emplacement_titre.text = "  " + titre_jeu;
        emplacement_description.text = description_jeu;
        emplacement_apercu.sprite = apercu_jeu;
        emplacement_apercu.preserveAspect = true;
        emplacement_index.text = IndexJeu;

    }
}
