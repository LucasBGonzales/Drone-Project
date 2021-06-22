using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour
{
    private Rigidbody m_rigidbody;
    private Vector3 lastVelocity;
    public Vector3 acceleration;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        lastVelocity = m_rigidbody.velocity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 currentVelocity = m_rigidbody.velocity;
        acceleration = ((currentVelocity - lastVelocity) / Time.deltaTime) + Physics.gravity;
        lastVelocity = currentVelocity;

        print("Accelerometer: " + acceleration.ToString("F4"));
    }
}
