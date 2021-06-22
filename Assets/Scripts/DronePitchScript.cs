using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronePitchScript : MonoBehaviour
{
    public float m_pitchVariability;

    private AudioSource m_audioSource;
    private Rigidbody  m_rigidBody;
    private float m_defaultPitch;

    // Start is called before the first frame update
    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
        m_rigidBody = GetComponent<Rigidbody>();
        m_defaultPitch = m_audioSource.pitch;
    }

    // Update is called once per frame
    void Update()
    {
        float amount = GetComponent<PlayerMovement>().m_acceleration_amount;
        amount = amount < 0f ? amount * 0.75f : amount;
        m_audioSource.pitch = m_defaultPitch + m_pitchVariability * amount;
    }
}
