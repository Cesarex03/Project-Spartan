using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] int damage = 1;

    [SerializeField] Vector3 direction = new Vector3(1, 0, 0);
     GameObject CannonBullet;
     [SerializeField] float destroyposition = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(damage);


    }

    // Update is called once per frame
    void Update()
    {

        Movementforward();

if (transform.position.x > destroyposition)
            Destroy(gameObject);

    }
    void Movementforward()
    {

        transform.Translate(speed * Time.deltaTime * direction);

    }

}
