using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiBlueTurtle : Enemies
{ 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Patrol();
        LookAtTarget();
        
    }
    private protected override void LookAtTarget()
    {

        Quaternion newRotation = Quaternion.LookRotation(targetview.transform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, enemiesStats.speed * Time.deltaTime);
    }
    private protected override void Patrol()
    {
        

        if (transform.position != patrolpoints[currentpoint].transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolpoints[currentpoint].transform.position, enemiesStats.speedpatrol * Time.deltaTime);
        }
        else
            currentpoint = (currentpoint + 1) % patrolpoints.Length;
    }
}
