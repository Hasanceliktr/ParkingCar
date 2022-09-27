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
        if (collision.gameObject.CompareTag("DurusNoktasi"))
        {
            DurusNoktasiDurumu = true;
            _GameManager.DurusNoktasi.SetActive(false);
            //

        }

        if (collision.gameObject.CompareTag("Parking"))
        {
            ilerle = false;
            TekerLekesi[0].SetActive(false);
            TekerLekesi[1].SetActive(false);
            transform.SetParent(parent);

            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            _GameManager.YeniArabaGetir();

        }
        else if (collision.gameObject.CompareTag("OrtaGobek"))
        {
            Destroy(gameObject); // obje havuzunda arabayý false yapacaðýz. canvas cýkacak
        }

        else if (collision.gameObject.CompareTag("Araba"))
        {
            Destroy(gameObject); // obje havuzunda arabayý false yapacaðýz. canvas cýkacak
        }
    }
}
