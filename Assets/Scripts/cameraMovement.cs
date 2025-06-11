using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class cameraMovement : MonoBehaviour
{
    public float speed = 5f;
    public float smoothSpeed = 1.5f;
    public Transform chicken;

    void Update(){
        transform.position += Vector3.forward * speed * Time.deltaTime;

        Vector3 desiredPosition = new Vector3(chicken.position.x + (float)0.5, transform.position.y, transform.position.z); // + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        
        if(transform.position.z > chicken.position.z){
            Debug.Log("Camera overtook chicken");
            Time.timeScale = 0;
        }
    }
}