using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    [SerializeField] GameObject[] cameras;
    
    void Start()
    {
        cameras[0].SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1)){

            EnableCamera(0,true);
            EnableCamera(1,false);
            EnableCamera(2,false);
        }

        if (Input.GetKeyDown(KeyCode.F2)){

            EnableCamera(0,false);
            EnableCamera(1,true);
            EnableCamera(2,false);
        }
        if (Input.GetKeyDown(KeyCode.F3)){

            EnableCamera(0,false);
            EnableCamera(1,false);
            EnableCamera(2,true);
        }
    }
    
    void EnableCamera(int position, bool status){

        cameras[position].SetActive(status);

    }
}
