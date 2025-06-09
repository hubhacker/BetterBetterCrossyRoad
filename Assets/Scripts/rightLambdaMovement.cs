using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightLambdaMovement : MonoBehaviour
{
    public float speed = 2f;
    public Vector3 moveDirection = Vector3.left;

    void Start(){
        speed = Random.Range(1f, 4f);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;
    }
}
