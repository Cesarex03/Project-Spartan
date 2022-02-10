using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] Vector3 direction = new Vector3(0, 0, 1);

    private GameObject Cannon_1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movementforward();
        MoveTowards();

    }
    void Movementforward()
    {

        transform.Translate(speed * Time.deltaTime * direction);
    }
    private void MoveTowards()
    {
        Vector3 direction = (Cannon_1.transform.position - transform.position);

        if (direction.magnitude > 3)
        {
        transform.position += speed * direction.normalized * Time.deltaTime;
        }
    }
}
