using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AddButton : MonoBehaviour
{
    [SerializeField]
    private Transform Panel;
    [SerializeField]
    private GameObject Button;
    GameObject btn;

    public float countImage;
    void Awake()
    {
        for(int i =1; i<countImage; i++)
        {
            //tao 8 cai button
            //gan 8 cai do vo panel
            btn = Instantiate(Button);//khoi tao Button
            btn.name = "" + i;
            Debug.Log("Name" + btn);
            btn.transform.SetParent(Panel, false);
        }
    }


}
