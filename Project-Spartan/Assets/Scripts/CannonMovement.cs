using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMovement : MonoBehaviour
{
    [SerializeField] float speedcannon = 2f;
    float cameraAxisX;
    [SerializeField] float rayDist = 10f;
    [SerializeField] GameObject pointerOrigin;

    private InventoryManager mgInventory;

    // Start is called before the first frame update
    void Start()
    {
        mgInventory = GetComponent<InventoryManager>();
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
        CannonPointer();
        UseItemInventoryOne();

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
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Token"))
        {
            Debug.Log(other.GetComponent<GemType>().typeGem);
            Debug.Log((int)other.GetComponent<GemType>().typeGem);
            GameManager.instance.gemQuantity[(int)other.GetComponent<GemType>().typeGem]++;
            Debug.Log(name + " Trigger con " + other.gameObject.name);
            GameObject token = other.gameObject;
            token.SetActive(false);
            GameManager.instance.tokens += 1;
            GameManager.instance.score += 50;
            mgInventory.AddInventoryOne(token);
            Debug.Log("--------- INVETARIO 1 -----------");
            mgInventory.SeeInventoryOne();
        }
    }
    void CannonPointer()
    {
        RaycastHit hit;

        if (Physics.Raycast(pointerOrigin.transform.position, pointerOrigin.transform.TransformDirection(Vector3.forward), out hit, rayDist))
        {
            if (hit.transform)
            {

                Debug.Log(" ON TARGET ");
            }

        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 puntob = pointerOrigin.transform.TransformDirection(Vector3.right) * rayDist;
        Gizmos.DrawRay(pointerOrigin.transform.position, puntob);
    }
    private void UseItemInventoryOne()
    {
        if (Input.GetKeyDown(KeyCode.G) && mgInventory.InventoryOneHas())
        {
            GameObject token = mgInventory.GetInventoryOne();
            mgInventory.SeeInventoryOne();
            UseToken(token);
        }
    }

    private void UseToken(GameObject token)
    {
        token.SetActive(true);
        token.transform.position = transform.position + (Vector3.forward * 2f);
    }

}