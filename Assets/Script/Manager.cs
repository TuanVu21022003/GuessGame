using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;

public enum TypeScene
{
    STARTGAME,
    LEVEL1,
    LEVEL2,
    LEVEL3,
    WIN
}

public class Manager : MonoBehaviour
{
    public static bool showLevel2 = false;
    public static bool showLevel3 = false;

    public GameObject goOn;
    public GameObject menu;

    //public GameObject ;

    //Save score
    public GameObject canvasMain;
    public GameObject canvasMenu;

    public InputField nameText;
    public TextMeshProUGUI notify;

    public TypeScene typeScene;



    public void Awake()
    {

        //scoreOld = PlayerPrefs.GetInt("MyScore");
        canvasMain.SetActive(true);
        canvasMenu.SetActive(false);
    }

    public void Start()
    {
        if(notify != null)
        {
            notify.gameObject.SetActive(false);
        }
        if(goOn != null && menu != null)
        {
            goOn.SetActive(false);
            menu.SetActive(false);

        }

        //level2.SetActive(false);
        //level3.SetActive(false);
        

    }



    public void SaveName()
    {
        string playerName = nameText.text;
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save();
    }

    private void Update()
    {
        //SaveName();
       // MenuOnGame2();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            goOn.SetActive(true);
            menu.SetActive(true);
            Time.timeScale = 0;
        }

    }

    public void StartGame()
    {
        if(nameText.text.Equals(""))
        {
            notify.gameObject.SetActive(true);
            StartCoroutine(Utils.DelayedActionCoroutine(2f, () =>
            {
                notify.gameObject.SetActive(false);
            }));
            return;
        }
        LoadLevel1();
        GameManager.instance.StartGame(nameText.text, 0);
    }

    public void LoadLevel1()
    {
        Next();
        SceneManager.LoadScene("Game1");
        //GetComponent<Manager>().enabled = true;
        Time.timeScale = 1;
    }
    public void LoadLevel2()
    {
        Next();
        SceneManager.LoadScene("Game2");
        Time.timeScale = 1;

    }
    public void LoadLevel3()
    {
        Next();
        SceneManager.LoadScene("Game3");
        //level3BT.SetActive(true);
        Time.timeScale = 1;
    }
    public void Quit()
    {
        EditorApplication.isPlaying = false;
        UnityEngine.Application.Quit();
    }

    public void Next()
    {
        print("Noi ban muon den :" + name);
    }

    public void Menu()
    {
        canvasMain.SetActive(false);
        canvasMenu.SetActive(true);
        Time.timeScale = 1;
    }

    public void Back()
    {
        canvasMain.SetActive(true);
        canvasMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void MenuOnGame2()
    {
        Manager.showLevel2 = true;
        SceneManager.LoadScene("StartGame");

        Time.timeScale = 1;;
    }

    public void MenuOnGame3()
    {
        Manager.showLevel3 = true;
        SceneManager.LoadScene("StartGame");
        Time.timeScale = 1;
    }

    public void GoOn()
    {
        goOn.SetActive(false);
        menu.SetActive(false);
        Time.timeScale = 1;
    }


    public void WinGame()
    {
        SceneManager.LoadScene("Win1");
    }

    public void TouchTopScore()
    {
        SceneManager.LoadScene("Static");
    }
}
