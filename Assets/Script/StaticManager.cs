using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StaticManager : MonoBehaviour
{
    public ItemStatic itemStaticPrefab;
    public Transform parent;

    private void Start()
    {
        OnInit();
    }

    public void Back()
    {
        SceneManager.LoadScene("StartGame");
    }

    public void OnInit()
    {
        ListPLayerDatas listPLayerDatas = LoadDataPlayer.instance.LoadData();
        listPLayerDatas.listPlayerDatas.Sort((p1, p2) => p1.pointPlayer.CompareTo(p2.pointPlayer));
        for(int i = 0; i < listPLayerDatas.listPlayerDatas.Count; i++)
        {
            PlayerData playerData = listPLayerDatas.listPlayerDatas[i];
            ItemStatic item = Instantiate(itemStaticPrefab, parent);
            item.OnInit((i + 1).ToString(), playerData.namePlayer, playerData.pointPlayer.ToString());
        }
    }
}
