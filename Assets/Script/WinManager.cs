using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ListPLayerDatas listPLayerDatas = LoadDataPlayer.instance.LoadData();
        PlayerData playerData = new PlayerData(GameManager.instance.namePlayer, GameManager.instance.pointPlayer);
        listPLayerDatas.AddPlayerData(playerData);
        LoadDataPlayer.instance.SaveDataPlayer(listPLayerDatas);
        GameManager.instance.pointPlayer = 0;
    }

    public void Back()
    {
        SceneManager.LoadScene("StartGame");
    }

}
