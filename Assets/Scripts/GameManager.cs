using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("PLATFORM AYARLARI")]
    public GameObject Araba;
    public GameObject Platform1;
    public GameObject Platform2;

    public float[] DonusHizlari;
    void Start()
    {
        
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Araba.GetComponent<Araba>().ilerle = true;
        }

        Platform1.transform.Rotate(new Vector3(0, 0, -DonusHizlari[0]),Space.Self);
    }
}
