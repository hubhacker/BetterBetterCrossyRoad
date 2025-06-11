using UnityEngine;

public class CloudMover : MonoBehaviour
{
    public float speed = 1;
    public int direction = 1;

    void Update()
    {
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);
    }
}