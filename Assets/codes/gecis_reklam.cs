using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class gecis_reklam : MonoBehaviour
{
    private InterstitialAd reklamObjesi;

    public void reklamvar()
    {
        PlayerPrefs.SetInt("reklamvar", 0);
    }

    void Start()
    {
        MobileAds.Initialize(reklamDurumu => { });
        if (reklamObjesi != null)
            reklamObjesi.Destroy();
        reklamObjesi = new InterstitialAd("ca-app-pub-3940256099942544/1033173712");//Interstitial ad test id
        AdRequest reklamIstegi = new AdRequest.Builder().Build();
        reklamObjesi.LoadAd(reklamIstegi);


        Debug.Log(PlayerPrefs.GetInt("olumsayisi"));
        if (PlayerPrefs.GetInt("olumsayisi") == 2)
        {
            PlayerPrefs.SetInt("reklamvar", 1);
            Debug.Log((PlayerPrefs.GetInt("reklamvar")));
            Invoke("reklamvar", 1f);
            StartCoroutine(ReklamiGoster());
        }
        if (PlayerPrefs.GetInt("olumsayisi") == 2)
        {
            PlayerPrefs.SetInt("olumsayisi", 0);
        }
    }
    IEnumerator ReklamiGoster()
    {
        while (!reklamObjesi.IsLoaded())
            yield return null;
        reklamObjesi.Show();
    }
    void OnDestroy()
    {
        if (reklamObjesi != null)
            reklamObjesi.Destroy();
    }
}
