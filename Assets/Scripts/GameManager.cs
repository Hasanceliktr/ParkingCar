using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    [Header("ARABA AYARLARI")]
    public GameObject[] Arabalar;
    public int KacArabaOlsun;
    int KalanAracSayisiDegeri;
    int AktifAracIndex = 0;

    [Header("CANVAS AYARLARI")]
    public Sprite AracGelmeGorseli;
    public TextMeshProUGUI KalanAracSayisi;
    public GameObject[] ArabaCanvasGorselleri;
    public TextMeshProUGUI[] Textler;
    public GameObject[] Panellerim;
    public GameObject[] TapToButonlar;

    [Header("PLATFORM AYARLARI")]
    
    public GameObject Platform1;
    public GameObject Platform2;
    public float[] DonusHizlari;
    bool DonusVarmi;

    [Header("---- LEVEL AYARLARI")]
    public ParticleSystem CarpmaEfekti;
    public int ElmasSayisi;

    void Start()
    {
        DonusVarmi = true;
        VarsayilanDegerleriKontrolEt();
        
        KalanAracSayisiDegeri = KacArabaOlsun;
        /*
        KalanAracSayisi.text = KalanAracSayisiDegeri.ToString();
        for (int i = 0; i<KacArabaOlsun;i++)
        {
            ArabaCanvasGorselleri[i].SetActive(true);
        }
         */   
        
    }

    public void YeniArabaGetir()
    {
        KalanAracSayisiDegeri--;
        if (AktifAracIndex<KacArabaOlsun)
        {
            Arabalar[AktifAracIndex].SetActive(true);
        }
        else
        {
            Kazandin();
        }
       
        /*
        ArabaCanvasGorselleri[AktifAracIndex-1].GetComponent<Image>().sprite = AracGelmeGorseli;
        
        KalanAracSayisi.text = KalanAracSayisiDegeri.ToString();
        */
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Arabalar[AktifAracIndex].GetComponent<Araba>().ilerle = true;
            AktifAracIndex++;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Panellerim[0].SetActive(false);
        }

        if (DonusVarmi)
        {
            Platform1.transform.Rotate(new Vector3(0, 0, -DonusHizlari[0]), Space.Self);
        }
        
    }

    public void Kaybettin()
    {
        DonusVarmi = false;
        //PlayerPrefs.SetInt("Elmas", PlayerPrefs.GetInt("Elmas") + ElmasSayisi);
        Textler[6].text = PlayerPrefs.GetInt("Elmas").ToString();
        Textler[7].text = SceneManager.GetActiveScene().name;
        Textler[8].text = (KacArabaOlsun - KalanAracSayisiDegeri).ToString();
        Textler[9].text = ElmasSayisi.ToString();

        

        Panellerim[1].SetActive(true);
        Invoke("KaybettinButonuOrtayaCikart",2f);
    }

    void KaybettinButonuOrtayaCikart()
    {
        TapToButonlar[0].SetActive(true);
    }
    void KazandinButonuOrtayaCikart()
    {
        TapToButonlar[1].SetActive(true);
    }

    public void Kazandin()
    {
        PlayerPrefs.SetInt("Elmas", PlayerPrefs.GetInt("Elmas") + ElmasSayisi);
        Textler[2].text = PlayerPrefs.GetInt("Elmas").ToString();
        Textler[3].text = SceneManager.GetActiveScene().name;
        Textler[4].text = (KacArabaOlsun - KalanAracSayisiDegeri).ToString();
        Textler[5].text = ElmasSayisi.ToString();
        Panellerim[2].SetActive(true);
        Invoke("KazandinButonuOrtayaCikart", 2f);
    }

    //BELLEK YONETÝMÝ

    void VarsayilanDegerleriKontrolEt()
    {
        if (!PlayerPrefs.HasKey("Elmas"))
        {
            PlayerPrefs.SetInt("Elmas", 0);
            PlayerPrefs.SetInt("Level",1);
        }

        Textler[0].text = PlayerPrefs.GetInt("Elmas").ToString();
        Textler[1].text = SceneManager.GetActiveScene().name;

    }

    public void izleVeDevamEt()
    {
        //Reklam kodlarý gelecek kaldýðý yerden devam edilecek
    }

    public void izleVeDahaFazlaKazan()
    {
        //Reklam kodlarý gelecek kaldýðý yerden devam edilecek
    }
    public void SonrakiLevel()
    {
        PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
