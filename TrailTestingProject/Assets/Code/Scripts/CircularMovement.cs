using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CircularMovement : MonoBehaviour
{
    #region Public members
    public Transform m_RotationCenter;
    [Min(0f)] public float m_RotationRadius = 1f;
    public float m_RotationSpeed = 1f;
    #endregion

    #region Private members
    private float m_Angle = 0f;
    #endregion

    #region Unity methods
    private void LateUpdate()
    {
        float posX = m_RotationCenter.position.x + Mathf.Cos(m_Angle) * m_RotationRadius;
        float posY = m_RotationCenter.position.y + Mathf.Sin(m_Angle) * m_RotationRadius;
        transform.position = new Vector3(posX, posY, 0);
        m_Angle = m_Angle + Time.unscaledDeltaTime * m_RotationSpeed;
    }
    #endregion
}
