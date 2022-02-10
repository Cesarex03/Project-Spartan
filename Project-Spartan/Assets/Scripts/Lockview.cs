using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lockview : MonoBehaviour
{

    [SerializeField] GameObject target;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        LookAtTarget();
    }
    void LookAtTarget()
    {
        Quaternion newRotation = Quaternion.LookRotation(target.transform.position - transform.position);
        transform.rotation = newRotation;


    }
}
