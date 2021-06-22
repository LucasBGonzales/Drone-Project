using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovementController : MonoBehaviour
{
    public float m_max_fan_force = 100f;
    public float m_stability_deadzone = 0.1f;
    public float m_liftAcceleration = 10f;
    public float m_maxTilt = 20f;
    public float m_tiltSpeed = 10f;
    public float m_turnSpeed = 10f;
    public float m_spinDampener = 10f;
    public float m_YDampener = 1f;
    public float m_YDampenerDeadzone = 0.2f;
    
    private Rigidbody m_rigidbody;
    private Accelerometer m_accelerometer;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_accelerometer = GetComponent<Accelerometer>();
    }

    // Update is called once per frame
    void Update()
    {
        float lift = Input.GetAxis("Lift");

        Vector3 acceleration = m_accelerometer.acceleration / m_rigidbody.mass;
        Vector3 add_force = Vector3.zero;

        float y_stabilization = acceleration.y > m_stability_deadzone || acceleration.y < -m_stability_deadzone ? acceleration.y * -1f : 0;

        add_force.y = y_stabilization + (lift * m_liftAcceleration);

        m_rigidbody.AddRelativeForce(add_force, ForceMode.Force);

        print("Add Force: " + add_force.ToString("F4"));
    }
}
