using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float m_liftAcceleration = 10f;
    public float m_maxTilt = 20f;
    public float m_tiltSpeed = 10f;
    public float m_turnSpeed = 10f;
    public float m_spinDampener = 10f;
    public float m_YDampener = 1f;
    public float m_YDampenerDeadzone = 0.2f;
    [HideInInspector]
    public float m_acceleration_amount;

    //private CharacterController m_controller;
    private Rigidbody m_rigidbody;

    private void Start()
    {
        //m_controller = GetComponent<CharacterController>();
        m_rigidbody = GetComponent<Rigidbody>();
    }


    void LateUpdate()
    {
    }

    private void FixedUpdate()
    {
        // Get Inputs
        float roll = Input.GetAxis("Roll");
        float pitch = Input.GetAxis("Pitch");
        float lift = Input.GetAxis("Lift");
        float yaw = Input.GetAxis("Yaw");


        // Handle Rotation
        float target_rotation_x = pitch * m_maxTilt;
        float target_rotation_z = roll * m_maxTilt * -1;
        Quaternion target_rotation = Quaternion.Euler(new Vector3(target_rotation_x, transform.eulerAngles.y, target_rotation_z));
        transform.rotation = Quaternion.Lerp(transform.rotation, target_rotation, Time.deltaTime * m_tiltSpeed);


        // Yaw Rotation
        if (yaw != 0)
        {
            float rotation_y = yaw * m_turnSpeed * Time.deltaTime;
            m_rigidbody.AddTorque(new Vector3(0, rotation_y, 0), ForceMode.Acceleration);
        }
        else // Dampen
        {
            Vector3 velocity = m_rigidbody.angularVelocity;
            if (velocity.y != 0f)
            {
                velocity.Set(0, velocity.y * -m_spinDampener, 0);
                m_rigidbody.AddTorque(velocity);
            }
        }

        // Handle Movement
        Vector3 anti_gravity = Physics.gravity * -1f;
        float force_pool = anti_gravity.y + (m_liftAcceleration * lift);
        float x_force = transform.rotation.z * -1 * force_pool;
        print("z_rotation: " + transform.rotation.z + "\nx_rotation: " + transform.rotation.x);
        float z_force = transform.rotation.x * force_pool;
        float y_force = (force_pool - (Mathf.Abs(x_force) + Mathf.Abs(z_force)));

        // Determine State 
        m_acceleration_amount = lift;

        // Dampen Y-Movement
        if (lift == 0 /*&& (m_rigidbody.velocity.y > m_YDampenerDeadzone || m_rigidbody.velocity.y < -m_YDampenerDeadzone)*/)
        {
            y_force += (m_rigidbody.velocity.y * -m_YDampener);
        }

        Vector3 force_vector = new Vector3(x_force, y_force, z_force);
        print("Force Vector: " + force_vector.ToString());
        m_rigidbody.AddRelativeForce(force_vector, ForceMode.Acceleration);
    }
}
