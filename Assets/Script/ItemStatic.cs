using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemStatic : MonoBehaviour
{
    public TextMeshProUGUI stt;
    public TextMeshProUGUI name;
    public TextMeshProUGUI score;

    public void OnInit(string stt, string name, string score)
    {
        this.stt.text = stt;
        this.name.text = name;
        this.score.text = score;

    }
}
