using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class olum_sc : MonoBehaviour
{
    public void resle()
    {
        if (PlayerPrefs.GetInt("reklamvar") == 1)
        {

        }
        else
        {
            SceneManager.LoadScene("oyun");
        }
    }
    public void menu_but()
    {
        if (PlayerPrefs.GetInt("reklamvar") == 1)
        {

        }
        else
        {
            SceneManager.LoadScene("menu");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("olumsayisi", PlayerPrefs.GetInt("olumsayisi")+1);
    }

  
}
