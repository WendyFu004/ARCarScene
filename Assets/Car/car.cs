using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    public float moveSpeed = 2f;
    float tiltAngle = 60f;
    Vector3 temp;
    // Start is called before the first frame update
    void Start()
    {
        temp = transform.localScale;
 
    }

    // Update is called once per frame
    void Update()
    {
        //use arrow keys to control the car moving left and right
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector3 direction = new Vector3(horizontal, 0f, 0f);
        direction = direction.normalized;

        // Translate the gameobject
        transform.position += direction * moveSpeed * Time.deltaTime;

        // Scaling the car
        temp = transform.localScale;

        if (Input.GetKey(KeyCode.Minus))
        {
            transform.localScale = Vector3.Lerp(temp, temp - new Vector3(0.01f, 0.01f, 0.01f), 0.1f);
        }
        if (Input.GetKey(KeyCode.Equals))
        {
            transform.localScale = Vector3.Lerp(temp, temp + new Vector3(0.01f, 0.01f, 0.01f), 0.1f);
        }

        //without any key, the car will rotating with constant angle
        if (Input.GetKey(KeyCode.UpArrow))
            //transform.rotation = Quaternion.Inverse(transform.rotation);
            transform.Rotate(-new Vector3(0f, 100f, 0f) * Time.deltaTime);
        else
            transform.Rotate(new Vector3(0f, 100f, 0f) * Time.deltaTime);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation,
                //Quaternion.LookRotation(new Vector3(0,0,0), Vector3.up),
                //rotationSpeed * Time.deltaTime);
    }
}
