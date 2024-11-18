using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDataPlayer : MonoSingletonDontDestroyOnLoad<LoadDataPlayer>
{
    public ListPLayerDatas LoadData()
    {
        string dataJson = PlayerPrefs.GetString(KeyConstants.KEY_SAVEPLAYERDATA);
        if (string.IsNullOrEmpty(dataJson))
        {
            return new ListPLayerDatas();
        }
        return JsonUtility.FromJson<ListPLayerDatas>(dataJson);
    }

    public void SaveDataPlayer(ListPLayerDatas data)
    {
        string dataString = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(KeyConstants.KEY_SAVEPLAYERDATA, dataString);
    }
}
