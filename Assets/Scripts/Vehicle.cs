using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public float speed = 10f;
    public float turnSpeed = 10f;
    public AudioSource engineSound;
    public Rigidbody rb;

    void Update()
    {
        print(rb.velocity.magnitude * 3.6f);
        engineSound.pitch = 1 + rb.velocity.magnitude * 0.1f;
    }
    public void Gas()
    {
        rb.velocity += transform.forward * speed * Time.deltaTime;
        
    }
    public void Brake()
    {

    }
    public void Turn(float amount)
    {
        transform.Rotate(0, amount * turnSpeed, 0);
    }

}
