using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
            StartCoroutine(DelayedGameOver());
        }
        if(chicken.position.z > transform.position.z+3.8f){
            desiredPosition = new Vector3(transform.position.x, transform.position.y, chicken.position.z - (float)3.8); // + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        }
     IEnumerator DelayedGameOver()
    {
        // Optional: freeze movement
        if (TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
        }

        yield return new WaitForSeconds(0.2f); 
        SceneManager.LoadScene("GameOver");
    }
    }
}