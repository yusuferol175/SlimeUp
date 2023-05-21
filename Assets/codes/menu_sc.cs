using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu_sc : MonoBehaviour
{
    public GameObject bolumler;
    //public GameObject bolum1;
    public GameObject ev_but;
    public GameObject level_panel;
    public GameObject bolum_kilit;
    public Button bolum_2_but;

    public List<Button> level_1_butonlar;
    public List<GameObject> kilitler;

    public AudioClip slm_ses;
    public GameObject ses_nesne;
    public void basla()
    {
        bolumler.SetActive(true);
        ev_but.SetActive(true);
        ses_nesne.GetComponent<AudioSource>().PlayOneShot(slm_ses);
    }

    public void eve_gel()
    {
        ses_nesne.GetComponent<AudioSource>().PlayOneShot(slm_ses);
        bolumler.SetActive(false);
        ev_but.SetActive(false);
        level_panel.SetActive(false);
        foreach (var item in kilitler)
        {
            item.SetActive(false);
        }
    }

    public void bolum_1()
    {
        ses_nesne.GetComponent<AudioSource>().PlayOneShot(slm_ses);
        PlayerPrefs.SetInt("bolum", 0);
        bolumler.SetActive(false);
        level_panel.SetActive(true);

        foreach (var item in level_1_butonlar)
        {
            if (int.Parse(item.tag) > PlayerPrefs.GetInt("seviye_1"))
            {
                item.enabled = false;
                kilitler[int.Parse(item.tag)].SetActive(true);
            }
        }
    }
    public void bolum_2()
    {
        ses_nesne.GetComponent<AudioSource>().PlayOneShot(slm_ses);
        PlayerPrefs.SetInt("bolum", 1);
        bolumler.SetActive(false);
        level_panel.SetActive(true);

        foreach (var item in level_1_butonlar)
        {
            if (int.Parse(item.tag) > PlayerPrefs.GetInt("seviye_2"))
            {
                item.enabled = false;
                kilitler[int.Parse(item.tag)].SetActive(true);
            }
        }
    }

    public void level_but(Object sender)
    {
        ses_nesne.GetComponent<AudioSource>().PlayOneShot(slm_ses);
        GameObject tiklanan = sender as GameObject;
        Debug.Log(tiklanan.tag);
        PlayerPrefs.SetInt("secilen_lvl", int.Parse( tiklanan.tag));
        SceneManager.LoadScene("oyun");
        PlayerPrefs.SetInt("bannerdurum", 1);
    }
    void Start()
    {
        //PlayerPrefs.DeleteAll();

        if (PlayerPrefs.GetInt("tamam_1")==1)
        {
            bolum_kilit.SetActive(false);
            bolum_2_but.enabled = true;
        }
        else if(PlayerPrefs.GetInt("tamam_1") == 0)
        {
            bolum_2_but.enabled = false;
        }

        bolumler.SetActive(false);
        ev_but.SetActive(false);
        level_panel.SetActive(false);

        foreach (var item in kilitler)
        {
            item.SetActive(false);
        }
        

    }

    
}
