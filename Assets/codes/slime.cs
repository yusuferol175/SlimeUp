using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cinemachine;

public class slime : MonoBehaviour
{
    public GameObject ok;
    public GameObject takiipli_kam;
    public GameObject next_panel;
    public static bool  sol;
    public static bool  sag;
    public static bool  ust;

    public static bool yerdemi;

    public Text parca_text;

    public AudioClip win;
    public AudioClip nom;
    public GameObject ses_nesnesi;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="trap")
        {
            SceneManager.LoadScene("olum");
        }
        if (collision.gameObject.tag=="yer")
        {
            yerdemi = true;
            ok.SetActive(true);
            

        }
        if (collision.gameObject.tag=="sol_duvar")
        {
            sol = true;
        }
        if (collision.gameObject.tag == "sag_duvar")
        {
            sag = true;
        }
        if (collision.gameObject.tag=="duvar")
        {
            ust = true;
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "yer")
        {
            yerdemi = false;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="duvar")
        {
            var vcam = takiipli_kam.GetComponent<CinemachineVirtualCamera>();
            vcam.Follow = null;
        }
        if (collision.gameObject.tag == "level_1")
        {
            ses_nesnesi.GetComponent<AudioSource>().PlayOneShot(win);
            next_panel.SetActive(true);
            PlayerPrefs.SetInt("secilen_lvl", 1);
            Time.timeScale = 0f;
            if (PlayerPrefs.GetInt("seviye_1") ==0)
            {
                PlayerPrefs.SetInt("seviye_1", 1);
                
            }
            if (PlayerPrefs.GetInt("tamam_1") == 1)
            {
                if (PlayerPrefs.GetInt("seviye_2") == 0)
                {
                    PlayerPrefs.SetInt("seviye_2", 1);

                }
            }


        }
        if (collision.gameObject.tag == "level_2")
        {
            ses_nesnesi.GetComponent<AudioSource>().PlayOneShot(win);
            next_panel.SetActive(true);
            PlayerPrefs.SetInt("secilen_lvl", 2);
            Debug.Log("tebrikler");
            Time.timeScale = 0f;
            if (PlayerPrefs.GetInt("seviye_1") == 1)
            {
                PlayerPrefs.SetInt("seviye_1", 2);
                
            }
            if (PlayerPrefs.GetInt("tamam_1") == 1)
            {
                if (PlayerPrefs.GetInt("seviye_2") == 1)
                {
                    PlayerPrefs.SetInt("seviye_2", 2);

                }
            }

        }
        if (collision.gameObject.tag == "level_3")
        {
            ses_nesnesi.GetComponent<AudioSource>().PlayOneShot(win);
            next_panel.SetActive(true);
            PlayerPrefs.SetInt("secilen_lvl", 3);
            Debug.Log("tebrikler");
            Time.timeScale = 0f;
            if (PlayerPrefs.GetInt("seviye_1") == 2)
            {
                PlayerPrefs.SetInt("seviye_1", 3);

            }
            if (PlayerPrefs.GetInt("tamam_1") == 1)
            {
                if (PlayerPrefs.GetInt("seviye_2") == 2)
                {
                    PlayerPrefs.SetInt("seviye_2", 3);

                }
            }

        }
        if (collision.gameObject.tag == "level_4")
        {
            ses_nesnesi.GetComponent<AudioSource>().PlayOneShot(win);
            next_panel.SetActive(true);
            PlayerPrefs.SetInt("secilen_lvl", 4);
            Debug.Log("tebrikler");
            Time.timeScale = 0f;
            if (PlayerPrefs.GetInt("seviye_1") == 3)
            {
                PlayerPrefs.SetInt("seviye_1", 4);

            }
            if (PlayerPrefs.GetInt("tamam_1") == 1)
            {
                if (PlayerPrefs.GetInt("seviye_2") == 3)
                {
                    PlayerPrefs.SetInt("seviye_2", 4);

                }
            }

        }
        if (collision.gameObject.tag == "level_5")
        {
            ses_nesnesi.GetComponent<AudioSource>().PlayOneShot(win);
            SceneManager.LoadScene("menu");
            PlayerPrefs.SetInt("secilen_lvl", 5);
            PlayerPrefs.SetInt("tamam_1", 1);
            Debug.Log("tebrikler");
            Time.timeScale = 0f;
            if (PlayerPrefs.GetInt("seviye_1") == 4)
            {
                PlayerPrefs.SetInt("seviye_1", 5);

            }
            if (PlayerPrefs.GetInt("tamam_1") == 1)
            {
                if (PlayerPrefs.GetInt("seviye_2") == 1)
                {
                    PlayerPrefs.SetInt("seviye_2", 5);

                }
            }

        }
        if (collision.gameObject.tag=="dusman1")
        {
            ses_nesnesi.GetComponent<AudioSource>().PlayOneShot(nom);
            Destroy(collision.gameObject);
            buton_olay_oyun_sc.parca_durum++;
            parca_text.text = "x " + buton_olay_oyun_sc.parca_durum.ToString();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "duvar")
        {
            var vcam = takiipli_kam.GetComponent<CinemachineVirtualCamera>();
            vcam.Follow = gameObject.transform;
        }

    }

}


