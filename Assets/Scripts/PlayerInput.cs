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
        bool blocked = false;
        
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                Vector3 targetPos = chicken.transform.position + Vector3.forward;
                blocked = Physics.CheckBox(
                    targetPos,
                    new Vector3(0.25f, 0.5f, 0.25f),
                    Quaternion.identity,
                    LayerMask.GetMask("tree")
                );

                if (!blocked)
                {
                    chicken.Jump(Vector3.forward);
                    isGrounded = false;
                }
            }
            else if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && transform.position.z > 0)
            {
                Vector3 targetPos = chicken.transform.position + Vector3.back;
                blocked = Physics.CheckBox(
                    targetPos,
                    new Vector3(0.25f, 0.5f, 0.25f),
                    Quaternion.identity,
                    LayerMask.GetMask("tree")
                );

                if (!blocked)
                {
                    chicken.Jump(Vector3.back);
                    isGrounded = false;
                }
            }
            else if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && transform.position.x > -19)
            {
                Vector3 targetPos = chicken.transform.position + Vector3.left;
                blocked = Physics.CheckBox(
                    targetPos,
                    new Vector3(0.25f, 0.5f, 0.25f),
                    Quaternion.identity,
                    LayerMask.GetMask("tree")
                );

                if (!blocked)
                {
                    chicken.Jump(Vector3.left);
                    isGrounded = false;
                }
            }
            else if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && transform.position.x < 19)
            {
                Vector3 targetPos = chicken.transform.position + Vector3.right;
                blocked = Physics.CheckBox(
                    targetPos,
                    new Vector3(0.25f, 0.5f, 0.25f),
                    Quaternion.identity,
                    LayerMask.GetMask("tree")
                );

                if (!blocked)
                {
                    chicken.Jump(Vector3.right);
                    isGrounded = false;
                }
            }
        }
    }
    
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
