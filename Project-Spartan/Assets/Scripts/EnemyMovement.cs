using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyMovement : MonoBehaviour
{
    private enum EnemyState
    {
        Patroling,
        Attacking,
    }
    [SerializeField] GameObject[] patrolpoints;
    [SerializeField] float speed = 20f;
    [SerializeField] float speedpatrol = 0f;
    [SerializeField] Vector3 direction = new Vector3(0, 0, 1);
    [SerializeField] GameObject targetview;
    [SerializeField] EnemyState enemyState;

    private int currentpoint;

    private GameObject Cannon_1;

    // Start is called before the first frame update
    void Start()
    {
        Cannon_1 = GameObject.Find("Cannon_1");
        currentpoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (enemyState)
        {

            case EnemyState.Patroling:
                LookAtTarget();
                Patrol();
                break;
            case EnemyState.Attacking:
                LookAtTarget();
                Movementforward();
                MoveTowards();
                break;


        }



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

    void LookAtTarget()
    {

        Quaternion newRotation = Quaternion.LookRotation(targetview.transform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, speed * Time.deltaTime);
    }

    void Patrol()
    {

        if (transform.position != patrolpoints[currentpoint].transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolpoints[currentpoint].transform.position, speedpatrol * Time.deltaTime);
        }
        else
            currentpoint = (currentpoint + 1) % patrolpoints.Length;





    }


}
