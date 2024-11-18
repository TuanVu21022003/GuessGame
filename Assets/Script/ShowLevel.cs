using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowLevel : MonoBehaviour
{

    public GameObject level2BT;
    public GameObject level3BT;
    public GameObject level2Text;
    public GameObject level3Text;

    // Start is called before the first frame update

    private void Update()
    {
        CheckShowLevel2();
        CheckShowLevel3();
    }

    void CheckShowLevel2()
    {
        if(Manager.showLevel2 == true)
        {
            level2BT.SetActive(true);
            level2Text.SetActive(false);

        }
    }

    void CheckShowLevel3()
    {
        if (Manager.showLevel3 == true)
        {
            level3BT.SetActive(true);
            level3Text.SetActive(false);
        }

    }


}
