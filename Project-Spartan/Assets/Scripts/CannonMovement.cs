using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMovement : MonoBehaviour
{
    [SerializeField] float speedcannon = 2f;
    float cameraAxisX;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerRotatio();

        if (Input.GetKey(KeyCode.W))

            Move(Vector3.forward);

        if (Input.GetKey(KeyCode.S))

            Move(Vector3.back);

         if (Input.GetKey(KeyCode.A))

             Move(Vector3.left);

         if (Input.GetKey(KeyCode.D))

             Move(Vector3.right);

    }
    private void Move(Vector3 direction)
    {

        transform.Translate(speedcannon * Time.deltaTime * direction);

    }
    void PlayerRotatio()
    {
        cameraAxisX += (Input.GetAxis("Mouse X"));
        Quaternion angulo = Quaternion.Euler(0f, cameraAxisX, 0f);
        transform.localRotation = angulo;

    }

}