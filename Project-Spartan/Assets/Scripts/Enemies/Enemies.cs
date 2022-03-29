using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    //DESING DATA
    [SerializeField] protected EnemiesData enemiesStats;
    //RUNTIME DATA
    protected int currentpoint;
    [SerializeField] protected Vector3 direction = new Vector3(0, 0, 1);
    [SerializeField] protected GameObject Cannon_1;
    [SerializeField] protected GameObject[] patrolpoints;
    [SerializeField] protected GameObject shootOrigin;
    [SerializeField] protected GameObject enemyProjectile;
    [SerializeField] protected GameObject targetview;
    private protected bool canAtack = true;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private protected virtual void Movementforward()
    {

        transform.Translate(enemiesStats.speed * Time.deltaTime * direction);
    }
    private protected virtual void MoveTowards()
    {
        Vector3 direction = (Cannon_1.transform.position - transform.position);

        if (direction.magnitude > 3)
        {
            transform.position += enemiesStats.speed * direction.normalized * Time.deltaTime;
        }
    }
    private protected virtual void Patrol()
    {

        if (transform.position != patrolpoints[currentpoint].transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolpoints[currentpoint].transform.position, enemiesStats.speedpatrol * Time.deltaTime);
        }
        else
            currentpoint = (currentpoint + 1) % patrolpoints.Length;
    }
    private protected virtual void LookAtTarget()
    {

        Quaternion newRotation = Quaternion.LookRotation(targetview.transform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, enemiesStats.speed * Time.deltaTime);
    }
    private protected virtual void Attack()
    {

        if (canAtack)
        {

            MoveTowards();
        }
        else
        {
            enemiesStats.timetoAttack += Time.deltaTime;
        }
        if (enemiesStats.timetoAttack > enemiesStats.shootCooldown)
        {

            canAtack = true;
        }
    }
    private protected virtual void projectRayCast()
    {
        RaycastHit hit;

        if (Physics.Raycast(shootOrigin.transform.position, shootOrigin.transform.TransformDirection(Vector3.forward), out hit, enemiesStats.rayDist))
        {
            if (hit.transform.tag == "Player")
            {
                canAtack = false;
                enemiesStats.timetoAttack = 0;
                GameObject b = Instantiate(enemyProjectile, shootOrigin.transform.position, enemyProjectile.transform.rotation);
                b.GetComponent<Rigidbody>().AddForce(shootOrigin.transform.TransformDirection(Vector3.forward) * 10f, ForceMode.Impulse);
            }
        }

    }
    private protected virtual void OnDrawGizmos()
    {
        if (canAtack)
        {
            Gizmos.color = Color.blue;
            Vector3 puntob = shootOrigin.transform.TransformDirection(Vector3.forward) * enemiesStats.rayDist;
            Gizmos.DrawRay(shootOrigin.transform.position, puntob);
        }
    }
    private protected virtual void OnCollisionEnter(Collision other) {
        
        if(other.gameObject.CompareTag("Bullet")){

            Destroy(gameObject);
            Destroy(other.gameObject);

        }
    }
}
