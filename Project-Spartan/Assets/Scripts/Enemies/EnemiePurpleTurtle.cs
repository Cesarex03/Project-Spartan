using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiePurpleTurtle : Enemies
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }
    private protected override void Attack()
    {
        if (canAtack)
        {

            projectRayCast();
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
}
