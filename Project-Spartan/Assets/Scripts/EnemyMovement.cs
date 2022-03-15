using System;
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
    [SerializeField] GameObject shootOrigin;
    [SerializeField] int shootCooldown = 1;
    [SerializeField] float timetoAttack = 0;
    private bool canAtack = true;
    [SerializeField] float rayDist = 10f;
    [SerializeField] GameObject enemyProjectile;



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
                //Movementforward();
                //MoveTowards();
                if (canAtack)
                {

                    projectRayCast();
                }
                else
                {
                    timetoAttack += Time.deltaTime;
                }
                if (timetoAttack > shootCooldown)
                {

                    canAtack = true;
                }
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
    void Attack()
    {

        if (canAtack)
        {

            projectRayCast();
        }
        else
        {
            timetoAttack += Time.deltaTime;
        }
        if (timetoAttack > shootCooldown)
        {

            canAtack = true;
        }
    }

    private void projectRayCast()
    {
        RaycastHit hit;

        if (Physics.Raycast(shootOrigin.transform.position, shootOrigin.transform.TransformDirection(Vector3.forward), out hit, rayDist))
        {
            if (hit.transform.tag == "Player")
            {
                canAtack = false;
                timetoAttack = 0;
                GameObject b = Instantiate(enemyProjectile, shootOrigin.transform.position, enemyProjectile.transform.rotation);
                b.GetComponent<Rigidbody>().AddForce(shootOrigin.transform.TransformDirection(Vector3.forward) * 10f, ForceMode.Impulse);
            }
        }

    }
    private void OnDrawGizmos()
    {
        if (canAtack)
        {
            Gizmos.color = Color.blue;
            Vector3 puntob = shootOrigin.transform.TransformDirection(Vector3.forward) * rayDist;
            Gizmos.DrawRay(shootOrigin.transform.position, puntob);
        }
    }
}
