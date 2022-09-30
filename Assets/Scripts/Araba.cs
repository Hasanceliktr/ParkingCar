using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Araba : MonoBehaviour
{
    public bool ilerle;
    bool DurusNoktasiDurumu = false;
    

    //
    public GameObject[] TekerLekesi;
    //
    public Transform parent;
    public GameManager _GameManager;
    
    public GameObject PartPoint;



    void Update()
    {
        if (!DurusNoktasiDurumu)
        {
            transform.Translate(6f * Time.deltaTime * transform.forward);
        }

        if (ilerle)
        {
            transform.Translate(15f * Time.deltaTime * transform.forward);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.CompareTag("Parking"))
        {
            ArabaTeknikIslemler();
            transform.SetParent(parent);

            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            _GameManager.YeniArabaGetir();

        }
        

        else if (collision.gameObject.CompareTag("Araba"))
        {
            _GameManager.CarpmaEfekti.transform.position = PartPoint.transform.position;
            _GameManager.CarpmaEfekti.Play();
            ArabaTeknikIslemler();
            Destroy(gameObject); // obje havuzunda arabayý false yapacaðýz. canvas cýkacak
            _GameManager.Kaybettin();
        }
        
    }

    void ArabaTeknikIslemler()
    {
        ilerle = false;
        TekerLekesi[0].SetActive(false);
        TekerLekesi[1].SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DurusNoktasi"))
        {
            DurusNoktasiDurumu = true;
            
            //

        }
       

        else if (other.gameObject.CompareTag("Elmas"))
        {
            other.gameObject.SetActive(false);
            _GameManager.ElmasSayisi++;
        }

        else if (other.gameObject.CompareTag("OrtaGobek"))
        {
            _GameManager.CarpmaEfekti.transform.position = PartPoint.transform.position;
            _GameManager.CarpmaEfekti.Play();
            ArabaTeknikIslemler();
            //Destroy(gameObject); // obje havuzunda arabayý false yapacaðýz. canvas cýkacak
            _GameManager.Kaybettin();
        }

        else if (other.gameObject.CompareTag("OnParking"))
        {
            other.gameObject.GetComponent<OnParking>().ParkingAktiflestir();
        }
    }
}
