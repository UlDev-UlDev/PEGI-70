using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
    public int IndexSceneALancer;
    public Text IndexScene_SldJ;
    private int IndexScene_Sldj_Int;

    public void OuvrirScene()
    {
        SceneManager.LoadScene(IndexSceneALancer);
    }
    public void OuvrirScene_SldJ()
    {
        IndexScene_SldJ = GameObject.Find("Text_index").GetComponent<Text>();
        IndexScene_Sldj_Int = int.Parse(IndexScene_SldJ.text);

        if (IndexScene_Sldj_Int != 0)
        {
            SceneManager.LoadScene(IndexScene_Sldj_Int);
        }
    }
}
