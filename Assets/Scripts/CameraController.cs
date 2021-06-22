using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject m_target;
    public float m_height;
    public float m_distance;

    private Vector3 m_velocity;
    private Vector3 m_offset;

    void Start()
    {
        m_velocity = Vector3.zero;
        m_offset = m_target.transform.position - m_target.transform.forward * m_distance;
    }

    void FixedUpdate()
    {
        // update offset

        m_offset = m_target.transform.forward * m_distance;
        m_offset.y = -m_height;
        m_offset = m_target.transform.position - m_offset;

        // update position
        Vector3 targetPosition = m_offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref m_velocity, 0.3f);

        // update rotation
        transform.LookAt(m_target.transform);

        /*Vector3 move_direction = m_target.transform.position - m_prevPosition;
        move_direction.Normalize();
        transform.position = m_target.transform.position - move_direction * m_distance;
        transform.LookAt(m_target.transform.position);
        m_prevPosition = m_target.transform.position;*/

        /*transform.position = m_target.transform.position - m_target.transform.forward * m_distance;
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y + 5, transform.position.z), 0.2f);
        transform.LookAt(m_target.transform.position);*/
    }
}
