using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float maxReverseSpeed = -5f;
    public float acceleration = 5f;
    public float brakeAcceleration = -3f;
    public float turnSpeed = 10f;
    public AudioSource engineSound;
    public Rigidbody rb;
    public AnimationCurve pitchCurve;
    Vector3 localVelocity;
    public TrailRenderer tr;
    public TrailRenderer tr1;
    public AudioSource source;

    void Update()
    {
        print(rb.velocity.magnitude * 3.6f);
        var speedRatio = rb.velocity.magnitude / maxSpeed;
        engineSound.pitch = pitchCurve.Evaluate(speedRatio);
        localVelocity = transform.InverseTransformVector(rb.velocity); //drifting
        print(localVelocity);
        if (localVelocity.x < -1 || localVelocity.x > 1)
        {
            source.volume = 1;
            print("drift");
            tr.widthMultiplier = 0.5f;
            tr1.widthMultiplier = 0.5f;
            
        }
        else
        {
            source.volume = 0;
            tr.widthMultiplier = 0.0f;
            tr1.widthMultiplier = 0.0f;
        }

        rb.velocity += -transform.forward * localVelocity.z * 0.1f * Time.deltaTime;
        rb.velocity += -transform.forward * localVelocity.z * 1 * Time.deltaTime;
    }
    public void Gas()
    {
        if (localVelocity.z > maxSpeed) return;
        rb.velocity += transform.forward * acceleration * Time.deltaTime;
        
    }
    public void Brake()
    {
        if (localVelocity.z < maxReverseSpeed) return;
        rb.velocity += transform.forward * brakeAcceleration * Time.deltaTime;
    }
    public void Turn(float amount)
    {
        amount = Mathf.Clamp(amount, -1, 1);
        transform.Rotate(0, amount * turnSpeed * Time.deltaTime, 0);
    }

}
