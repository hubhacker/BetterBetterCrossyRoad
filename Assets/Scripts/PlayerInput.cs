using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    ChickenMovement chicken;
    bool isGrounded = false;

    void Start()
    {
        chicken = GetComponent<ChickenMovement>();

        Vector3 pos = transform.position;
        transform.position = new Vector3(Mathf.Round(pos.x), Mathf.Round(pos.y), Mathf.Round(pos.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                GetComponent<ChickenMovement>().Jump(transform.forward);
                isGrounded = false;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                GetComponent<ChickenMovement>().Jump(-transform.forward);
                isGrounded = false;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                GetComponent<ChickenMovement>().Jump(-transform.right);
                isGrounded = false;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                GetComponent<ChickenMovement>().Jump(transform.right);
                isGrounded = false;
            }   
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
