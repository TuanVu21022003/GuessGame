using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetNuGuess : MonoBehaviour
{
    public TMP_Text menuNuGuess;

    public GameObject scoreTextMenu;
    public GameObject soundMenu;


    void Start()
    {
        scoreTextMenu.SetActive(false);
        soundMenu.SetActive(false);

    }


    // Update is called once per frame
    void Update()
    {
        int scoreNumGuess = PlayerPrefs.GetInt("MyGuess");
        menuNuGuess.text = "Score:   " + scoreNumGuess.ToString();
    }

    public void ScoreShow()
    {
        scoreTextMenu.SetActive(true);
        soundMenu.SetActive(false);

    }
    public void Sound()
    {
        soundMenu.SetActive(true);
        scoreTextMenu.SetActive(false);

    }

}
