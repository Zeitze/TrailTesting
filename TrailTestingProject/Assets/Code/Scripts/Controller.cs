using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Rigidbody m_Rigidbody;

    [Header("Movement")]
    [SerializeField] Transform m_PlayerInputSpace = default;
    [SerializeField, Range(0f, 100f)] float m_MaxSpeed = 10f;
    Vector3 m_Velocity;
    Vector3 m_DesiredVelocity;
    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerInput;
        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.y = Input.GetAxis("Vertical");
        playerInput = Vector2.ClampMagnitude(playerInput, 1f);

        if (m_PlayerInputSpace)
        {
            Vector3 forward = m_PlayerInputSpace.forward;
            forward.y = 0f;
            forward.Normalize();
            Vector3 right = m_PlayerInputSpace.right;
            right.y = 0f;
            right.Normalize();
            m_DesiredVelocity = (forward * playerInput.y + right * playerInput.x) * m_MaxSpeed;
        }
        else
        {
            m_DesiredVelocity = new Vector3(playerInput.x, 0f, playerInput.y) * m_MaxSpeed;
        }
    }
    private void FixedUpdate()
    {
        m_Rigidbody.velocity = m_DesiredVelocity;
    }
    
}