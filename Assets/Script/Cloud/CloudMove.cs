using UnityEngine;

public class CloudMove : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < -200f)
        {
            Destroy(gameObject);
        }
    }
}