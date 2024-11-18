using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro ;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
public class GameController : MonoBehaviour
{
    public static GameController instance;

    public AudioClip RightSound;
    public AudioClip WrongSound;
    private AudioSource source;
    [SerializeField]
    private TMP_Text Score;
    [SerializeField]
    private TMP_Text NuGuess;
    public TMP_Text newNuGuess;
    public TMP_Text menuNuGuess;
    public int NuofGuess = 0;
    public int lastNuOfGuess = 50;
    
    [SerializeField]
    private Sprite BackgroundImg;
    private List<Button> btnList = new List<Button>();//Khai bao list cho Button
    public Sprite[] SourceSprite; 
    public List<Sprite> SptList = new List<Sprite>();

    private bool firstGuess, secondGuess;//ktra dung sai khi doan
    string firstName, secondName;
    int firstIndex, secondIndex, TotalGuess,CorrectGuess;

    public GameObject canvasUI;
    public GameObject CanvasInGame;

    public float time = 60;
    public float currentTime;
    public Text textTime;

    public float timePlay = 0;
    public float currentTimePlay;
    public Text textTimePlay;

    public TMP_Text playerNameText;
    private int timePlayerSave;

    void Awake()
    {
        currentTime = time;
        currentTimePlay = timePlay;


        canvasUI.SetActive(false);
        CanvasInGame.SetActive(true);

        lastNuOfGuess = PlayerPrefs.GetInt("MyGuess");

        string sceneName = SceneManager.GetActiveScene().name;

        // Kiểm tra tên Scene và load Sprite tương ứng
        if (sceneName == "Game1")
        {
            SourceSprite = Resources.LoadAll<Sprite>("Sprite/GameImg 1");
            Time.timeScale = 1;
            currentTime = 60f;
            currentTimePlay = 0f;
        }
        else if (sceneName == "Game2")
        {
            SourceSprite = Resources.LoadAll<Sprite>("Sprite/GameImg 2");
            Time.timeScale = 1;
            currentTime = 70f;
            currentTimePlay = 0f;
        }
        else if (sceneName == "Game3")
        {
            SourceSprite = Resources.LoadAll<Sprite>("Sprite/GameImg 3");
            Time.timeScale = 1;
            currentTime = 80f;
            currentTimePlay = 0f;
        }

        Score.text = "Score  " + CorrectGuess.ToString();
        NuGuess.text = "NuGuess  " + NuofGuess.ToString();
        source = (AudioSource)gameObject.AddComponent<AudioSource>();
    }
    void Start()//
    {
        GetButton();
        TotalGuess = btnList.Count / 2;
        AddListener();
        AddSprite();
        Shuffle(SptList);
        BestNuGuess();

        string playerName = GameManager.instance.namePlayer;
        playerNameText.text = "Player: " + playerName;
    }
    private void Update()
    {
        TimePlay();
        CalcuTime();
    }

    void CalcuTime()
    {
        currentTimePlay += Time.deltaTime;
        print("currentTimePlay " + currentTimePlay);
        int timePlayer = Mathf.FloorToInt(currentTimePlay);
        timePlayerSave = timePlayer;
        textTimePlay.text = "Time : " + timePlayer.ToString();

        if (CorrectGuess == TotalGuess)
        {
            Time.timeScale = 0;
        }


    }

    void TimePlay()
    {
        currentTime -= Time.deltaTime;
        int displayTime = Mathf.FloorToInt(currentTime);
        textTime.text = "Time: " + displayTime.ToString();

        if ((currentTime <= 0))
        {
            Time.timeScale = 0;
            //SceneIndex();
            SceneManager.LoadScene("Fail");

        }
    }

    void SceneIndex()
    {
        int sceneName = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneName);
    }

    void AddSprite()
    {
        int size = btnList.Count;
        int sourceSize = SourceSprite.Length;
        int index = 0;
        for (int i = 0; i < size; i++)
        {
            if (index >= TotalGuess)
            {
                index = 0; // Đặt lại index nếu vượt quá số lượng sprite
            }
            SptList.Add(SourceSprite[index]);
            index++;
        }
    }

    void GetButton()
    {
        // lay het tat ca cac Button them vao list
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");
        for (int i = 0; i < objects.Length; i++)
        {
            btnList.Add(objects[i].GetComponent<Button>());
            btnList[i].image.sprite = BackgroundImg;

        }
    }
    void AddListener()
    {
        foreach(Button btn in btnList)
        {
            btn.onClick.AddListener( () => PickPuzzle());
        }
    }
    void PickPuzzle()
    {
        //string name = EventSystem.current.currentSelectedGameObject.name;//Hien tai
        if (!firstGuess)//neu sai la chua click,thi bat len
        {
            firstGuess = true;
            firstIndex = int.Parse(EventSystem.current.currentSelectedGameObject.name);
            firstName = SptList[firstIndex].name;
            btnList[firstIndex].image.sprite = SptList[firstIndex];
            print("1st Index : " + firstIndex + "  1st Name = " + firstName);
        }
        else if (!secondGuess)
        {
            secondGuess = true;
            secondIndex = int.Parse(EventSystem.current.currentSelectedGameObject.name);
            secondName = SptList[secondIndex].name;
            btnList[secondIndex].image.sprite = SptList[secondIndex];
            print("2nd Index : " + secondIndex + "  2nd Name = " + secondName);
            NuofGuess++;//tang so lan minh doan them 1 lan
            StartCoroutine(CheckIfPuzzleMatched());
        }
        //else if (!thirdGuess)
        //{
        //    thirdGuess = true;
        //    thirdIndex = int.Parse(EventSystem.current.currentSelectedGameObject.name);
        //    thirdName = SptList[thirdIndex].name;
        //    btnList[thirdIndex].image.sprite = SptList[thirdIndex];
        //    print("3nd Index : " + thirdIndex + " 3nd Name = " + thirdName);
        //    NuofGuess++;//tang so lan minh doan them 1 lan
        //    StartCoroutine(CheckIfPuzzleMatched());
        //}
    }
    IEnumerator CheckIfPuzzleMatched()
    {
        yield return new WaitForSeconds (1);
        if (firstName == secondName  && firstIndex != secondIndex)
        {
            source.PlayOneShot(RightSound,0.75f);
            CorrectGuess++;//tang so lan doan Dung them 1 lan
            //combo neu dung se bien mat
            btnList[firstIndex].interactable = false;
            btnList[secondIndex].interactable = false;
            //btnList[thirdIndex].interactable = false;//

            btnList[firstIndex].image.color =new Color(0, 0, 0, 0);
            btnList[secondIndex].image.color = new Color(0, 0, 0, 0);
           // btnList[thirdIndex].image.color = new Color(0, 0, 0, 0);
            CheckIfFinished();
        }
        else
        {
            source.PlayOneShot(WrongSound,0.75f);

            //cho ve mau cua Background
            btnList[firstIndex].image.sprite = BackgroundImg;
            btnList[secondIndex].image.sprite = BackgroundImg;
            //btnList[thirdIndex].image.sprite = BackgroundImg;
        }
        //neu sai,hai hinh ta chon se tro lai style ban dau
        NuGuess.text = "NuGuess " + NuofGuess.ToString();

        if(NuofGuess > lastNuOfGuess)
        {
            newNuGuess.text = "NuGuess" + NuofGuess.ToString();
           
        }
        else
        {
            newNuGuess.text = " New NuGuess" + NuofGuess.ToString();
        }
        Score.text = "Score " + CorrectGuess.ToString();

        firstGuess = secondGuess =  false;
        //CheckIfFinished();
    }
    void CheckIfFinished()
    {
        if(CorrectGuess == TotalGuess)//so lan doan trung la 4,bang vs so luong ta cho phep doan la 4 cap
        {
            print("Win with :" + NuofGuess + " Guess");
            canvasUI.SetActive(true);
            CanvasInGame.SetActive(false);
            GameManager.instance.pointPlayer += timePlayerSave;
            //if (NuofGuess < lastNuOfGuess)
            //{
            //    PlayerPrefs.SetInt("MyGuess", NuofGuess);
            //    PlayerPrefs.Save();
            //}
            //else
            //{
            //    PlayerPrefs.SetInt("MyGuess", NuofGuess);
            //    PlayerPrefs.Save();
            //}
        }
    }
    void Shuffle(List<Sprite> list) //Random vitri cua cac Sprite
    {
        Sprite temp;
        for(int i =0;i < list.Count; i++)
        {
            temp = list[i];
            int random = Random.Range(i, list.Count);
            list[i] = list[random];
            list[random] = temp;

        }
    }

    public void BestNuGuess()
    {
       
    }
}
