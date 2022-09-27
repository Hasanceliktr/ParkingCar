using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("ARABA AYARLARI")]
    public GameObject[] Arabalar;
    public int KacArabaOlsun;
    public GameObject DurusNoktasi;

    int AktifAracIndex = 0;

    [Header("PLATFORM AYARLARI")]
    
    public GameObject Platform1;
    public GameObject Platform2;

    public float[] DonusHizlari;
    void Start()
    {
       
            
        
    }

    public void YeniArabaGetir()
    {
        DurusNoktasi.SetActive(true);
        if (AktifAracIndex<KacArabaOlsun)
        {
            Arabalar[AktifAracIndex].SetActive(true);
        }
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
