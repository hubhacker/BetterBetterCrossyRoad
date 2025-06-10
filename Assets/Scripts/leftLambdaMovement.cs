using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftLambdaMovement : MonoBehaviour
{
    public float speed = 2f;
    public Vector3 moveDirection = Vector3.right;

    void Start(){
        if (speed == 0f)
        {
            speed = Random.Range(1f, 4f); // fallback

        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;
    }
}
