using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] int damage = 1;

    [SerializeField] Vector3 direction = new Vector3(1, 0, 0);
    GameObject CannonBullet;
    

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(damage);


    }

    // Update is called once per frame
    void Update()
    {

        Movementforward();

        if (Input.GetKey(KeyCode.Space))
            ScaleChange();


    }
    void Movementforward()
    {

        transform.Translate(speed * Time.deltaTime * direction);

    }
    void ScaleChange()
    {

        transform.localScale = new Vector3(2, 2, 2);

    }
    

}
