using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingletonDontDestroyOnLoad<GameManager>
{
    public string namePlayer;
    public int pointPlayer;
    private void Start()
    {
        pointPlayer = 0;

    }

    public void StartGame(string name, int point)
    {
        namePlayer = name;
        pointPlayer = point;
    }

}
