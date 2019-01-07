using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Admin : MonoBehaviour {

    private Text ms_serpent;
    private Text ms_mastermind;
	// Use this for initialization
	void Start () {
        MettreAJour();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void RemettreAZero()
    {
        int Temp = 0;
        PlayerPrefs.SetInt("HighScoreSerpent", Temp);
        PlayerPrefs.SetInt("HighScoreMastermind", Temp);
        MettreAJour();
    }

    void MettreAJour()
    {
        ms_serpent = GameObject.Find("Text_Serpent").GetComponent<Text>(); ;
        ms_mastermind = GameObject.Find("Text_Mastermind").GetComponent<Text>();

        ms_serpent.text = "Serpent : " + PlayerPrefs.GetInt("HighScoreSerpent", 5).ToString();
        ms_mastermind.text = "Mastermind : " + PlayerPrefs.GetInt("HighScoreMastermind", 5).ToString();
    }
}
