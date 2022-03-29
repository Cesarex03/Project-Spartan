using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiiRedTurtle : Enemies
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        LookAtTarget();
    }
    private protected override void LookAtTarget()
    {

        Quaternion newRotation = Quaternion.LookRotation(targetview.transform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, enemiesStats.speed * Time.deltaTime);
    }
}
