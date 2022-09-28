using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{


    [Header("ARABA AYARLARI")]
    public GameObject[] Arabalar;
    public int KacArabaOlsun;
    public GameObject DurusNoktasi;
    int KalanAracSayisiDegeri;
    int AktifAracIndex = 0;

    [Header("CANVAS AYARLARI")]
    public Sprite AracGelmeGorseli;
    public TextMeshProUGUI KalanAracSayisi;
    public GameObject[] ArabaCanvasGorselleri;

    [Header("PLATFORM AYARLARI")]
    
    public GameObject Platform1;
    public GameObject Platform2;

    public float[] DonusHizlari;

    [Header("---- LEVEL AYARLARI")]
    public int ElmasSayisi;

    void Start()
    {
        /*
        KalanAracSayisiDegeri = KacArabaOlsun;
        KalanAracSayisi.text = KalanAracSayisiDegeri.ToString();
        for (int i = 0; i<KacArabaOlsun;i++)
        {
            ArabaCanvasGorselleri[i].SetActive(true);
        }
         */   
        
    }

    public void YeniArabaGetir()
    {
        DurusNoktasi.SetActive(true);
        if (AktifAracIndex<KacArabaOlsun)
        {
            Arabalar[AktifAracIndex].SetActive(true);
        }
        /*
        ArabaCanvasGorselleri[AktifAracIndex-1].GetComponent<Image>().sprite = AracGelmeGorseli;
        KalanAracSayisiDegeri--;
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

        Platform1.transform.Rotate(new Vector3(0, 0, -DonusHizlari[0]),Space.Self);
    }
}
