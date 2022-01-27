using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorController : MonoBehaviour
{
    [SerializeField] GameObject cannonBullet;
    [SerializeField] GameObject cannonBullet2;
    [SerializeField] GameObject cannonBullet3;

    [SerializeField] float spawnrate = 3f;
    [SerializeField] float spawndelay = 0.3f;

    // Start is called before the first frame update
    void Start()
    {                 //ACTIVAR PARA DESAFIO DE INSTANCIAS//
        //InvokeRepeating("FireCannonBullet", spawndelay, spawnrate);
        //InvokeRepeating("FireCannonBullet2", spawndelay, spawnrate);
        //InvokeRepeating("FireCannonBullet3", spawndelay, spawnrate);



    }

    // Update is called once per frame
    void Update()
    {
        //PARA DESAFIO COMPLEMENTARIO//
        Inputs();
    }
    void FireCannonBullet()
    {
        Instantiate(cannonBullet, transform.position, transform.rotation);
    }
    void FireCannonBullet2()
    {
        Instantiate(cannonBullet2, transform.position, transform.rotation);
    }
    void FireCannonBullet3()
    {
        Instantiate(cannonBullet3, transform.position, transform.rotation);
    }
    void Inputs()
    {

        if (Input.GetKeyDown(KeyCode.J))
        {

            FireCannonBullet();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {

            FireCannonBullet2();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {

            FireCannonBullet3();
        }

    }



}
