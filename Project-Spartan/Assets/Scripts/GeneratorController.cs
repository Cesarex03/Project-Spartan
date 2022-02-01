using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorController : MonoBehaviour
{
    [SerializeField] GameObject cannonBullet;
    [SerializeField] GameObject cannonBullet2;
    [SerializeField] GameObject cannonBullet3;
    [SerializeField] bool canShoot = true;
    [SerializeField] float timpePass = 0f;

    [SerializeField] float cooldown = 2f;

    //[SerializeField] float spawnrate = 3f;
    //[SerializeField] float spawndelay = 0.3f;

    // Start is called before the first frame update
    void Start()
    {                 //ACTIVAR O DESACTIVAR PARA DESAFIO DE INSTANCIAS//
        //InvokeRepeating("FireCannonBullet", spawndelay, spawnrate);
        //InvokeRepeating("FireCannonBullet2", spawndelay, spawnrate);
        //InvokeRepeating("FireCannonBullet3", spawndelay, spawnrate);



    }

    // Update is called once per frame
    void Update()
    {
        //ACTIVAR O DESACTIVAR PARA DESAFIO COMPLEMENTARIO//
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

        if (Input.GetKeyDown(KeyCode.J) && canShoot)
        {

            FireCannonBullet();
            canShoot = false;

        }
        if (Input.GetKeyDown(KeyCode.K) && canShoot)
        {

            FireCannonBullet2();
            canShoot = false;
        }
        if (Input.GetKeyDown(KeyCode.L) && canShoot)
        {

            FireCannonBullet3();
            canShoot = false;
        }
        if (!canShoot)
        {
            timpePass += Time.deltaTime;
        }
        if (timpePass > cooldown)
        {
            timpePass = 0;
            canShoot = true;
        }


    }



}
