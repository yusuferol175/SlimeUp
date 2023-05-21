using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buton_olay_oyun_sc : MonoBehaviour
{
    public GameObject rimuru;
    public GameObject ok;
    public GameObject parca;
    public GameObject pause_panel;
    public GameObject next_panel;

    public Text parca_text;

    private float hiz = 5f;
    public float yon;

    private bool hareket;

    private float rota;

    public List<GameObject> leveller;
    public List<GameObject> leveller_2;

    public AudioClip slm_ses_oyn;
    public AudioClip slm_ses;
    public GameObject ses_nesnesi;
    public void slm_up()
    {
        if (slime.yerdemi==true)
        {
            ses_nesnesi.GetComponent<AudioSource>().PlayOneShot(slm_ses_oyn);
            parca_durum--;
            parca_text.text = "x " + parca_durum.ToString();
            Destroy(Instantiate(parca, new Vector3(rimuru.transform.position.x, rimuru.transform.position.y, 0f), parca.transform.rotation),2f);
            
            if (ok.transform.rotation.z < 0f)
            {
                rota = ok.transform.rotation.z * -1f;
            }
            else if (ok.transform.rotation.z > 0f)
            {
                rota = ok.transform.rotation.z;
            }
            else if (ok.transform.rotation.z == 0f)
            {
                rota = 1f;
            }
            
            yon = ok.transform.position.x * rota * 15f;
            
            if (ok.transform.rotation.z < 0f)
            {
                if (yon < 0f)
                {
                    yon = yon * -1f;
                }
            }
            else if (ok.transform.rotation.z > 0f)
            {
                if (yon > 0f)
                {
                    yon = yon * -1f;
                }
            }


            hareket = true;
            rimuru.GetComponent<Rigidbody2D>().gravityScale = 0;
            Invoke("dur", 1f);
            ok.gameObject.SetActive(false);
        }
        
       
    }
    
    public void eve()
    {
        SceneManager.LoadScene("menu");
    }

    public void next()
    {
        SceneManager.LoadScene("oyun");
    }
    public void dur()
    {
        
        slime.sag = false;
        slime.sol = false;
        slime.ust = false;
        if (hiz < 0)
        {
            hiz = hiz * -1;
        }
        rimuru.GetComponent<Rigidbody2D>().gravityScale = 1;
        hareket = false;
    }

    public void oyun_dur()
    {
        ses_nesnesi.GetComponent<AudioSource>().PlayOneShot(slm_ses);
        Time.timeScale = 0f;
        pause_panel.SetActive(true);
    }
    public void devam_et()
    {
        ses_nesnesi.GetComponent<AudioSource>().PlayOneShot(slm_ses);
        Time.timeScale = 1f;
        pause_panel.SetActive(false);
    }
    public void res_button()
    {
        SceneManager.LoadScene("oyun");
    }
    public static int parca_durum;
    void Start()
    {
        pause_panel.SetActive(false);
        next_panel.SetActive(false);
        Time.timeScale = 1f;
        parca_durum = 3;
        parca_text.text = "x " + parca_durum.ToString();
        
        if (PlayerPrefs.GetInt("bolum")==0)
        {
            Instantiate(leveller[PlayerPrefs.GetInt("secilen_lvl")], new Vector3(leveller[PlayerPrefs.GetInt("secilen_lvl")].transform.position.x, leveller[PlayerPrefs.GetInt("secilen_lvl")].transform.position.y, 0f), leveller[PlayerPrefs.GetInt("secilen_lvl")].transform.rotation);
        }
        if (PlayerPrefs.GetInt("bolum") == 1)
        {
            Instantiate(leveller_2[PlayerPrefs.GetInt("secilen_lvl")], new Vector3(leveller_2[PlayerPrefs.GetInt("secilen_lvl")].transform.position.x, leveller_2[PlayerPrefs.GetInt("secilen_lvl")].transform.position.y, 0f), leveller_2[PlayerPrefs.GetInt("secilen_lvl")].transform.rotation);
        }
    }

   
    void Update()
    {
        
        if (hareket)
        {

            if (slime.sol == true)
                {
                    yon = yon * -1;
                    slime.sol = false;
                }
                if (slime.sag == true)
                {
                    yon = yon * -1;
                    slime.sag = false;
                }
                if (slime.ust==true)
                {
                    hiz = hiz * -1;
                    slime.ust = false;
                }
                
                rimuru.transform.position += new Vector3(yon * Time.deltaTime, hiz * Time.deltaTime, 0f);
            
           

        }
        else
        {
            if (slime.yerdemi == true)
            {
                if (parca_durum == 0)
                {
                    Invoke("degis", 0.2f);
                    
                }
            }
        }
        
    }
    public void degis()
    {
        SceneManager.LoadScene("olum");
    }
}
