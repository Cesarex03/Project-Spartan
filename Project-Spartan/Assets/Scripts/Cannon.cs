using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] Vector3 direction = new Vector3(1, 0, 0);
    [SerializeField] int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
         Debug.Log(damage);


    }

    // Update is called once per frame
    void Update()
    {
        Movementforward();

    }
    void Movementforward()
    {

        transform.Translate(speed * Time.deltaTime * direction);

    }

}
