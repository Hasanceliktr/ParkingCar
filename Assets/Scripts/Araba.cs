using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Araba : MonoBehaviour
{
    public bool ilerle;
    //
    public GameObject[] TekerLekesi;
    //
    public Transform parent;
    void Start()
    {
        
    }

   
    void Update()
    {
        if (ilerle)
        {
            transform.Translate(15f * Time.deltaTime * transform.forward);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Parking"))
        {
            ilerle = false;
            TekerLekesi[0].SetActive(false);
            TekerLekesi[1].SetActive(false);
            transform.SetParent(parent);

        }
        if (collision.gameObject.CompareTag("OrtaGobek"))
        {
            Destroy(gameObject); // obje havuzunda arabayý false yapacaðýz.
        }
    }
}
