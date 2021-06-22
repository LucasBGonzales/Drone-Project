using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovement : MonoBehaviour
{
    public float m_liftAcceleration = 10f;
    public float m_maxTilt = 20f;
    public float m_tiltSpeed = 10f;
    public float m_turnSpeed = 10f;
    public float m_spinDampener = 10f;
    public float m_YDampener = 1f;
    public float m_YDampenerDeadzone = 0.2f;

    private Rigidbody m_rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
