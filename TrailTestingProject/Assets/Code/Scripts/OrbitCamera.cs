using UnityEngine;

[RequireComponent(typeof(Camera))]
public class OrbitCamera : MonoBehaviour
{
    #region Private members

    [SerializeField] Transform m_Focus = default;
    [SerializeField, Range(1f, 20f)] float m_Distance = 5f;
    [SerializeField, Min(0f)] float m_ZoomSpeed = 1f;
    [SerializeField, Min(0f)] float m_FocusRadius = 1f;

    [SerializeField, Range(0f, 1f)] float m_FocusCentering = 0.5f;
    [SerializeField, Range(1f, 360f)] float m_RotationSpeed = 90f;
    [SerializeField, Range(-89f, 89f)] float m_MinVerticalAngle = -30f, m_MaxVerticalAngle = 60f;

    [SerializeField, Min(0f)] float m_AlignDelay = 5f;
    [SerializeField, Range(0f, 90f)] float m_AlignSmoothRange = 45f;
    [SerializeField] LayerMask m_ObstructionMask = -1;

    float m_OneByAlignSmoothRange;
    float m_LastManualRotationTime;

    Vector3 m_FocusPoint, m_PreviousFocusPoint;
    Vector2 m_OrbitAngles = new Vector2(45f, 0f);

    Camera m_RegularCamera;

    Vector3 CameraHalfExtends
    {
        get
        {
            Vector3 halfExtends;
            halfExtends.y = m_RegularCamera.nearClipPlane * Mathf.Tan(0.5f * Mathf.Deg2Rad * m_RegularCamera.fieldOfView);
            halfExtends.x = halfExtends.y * m_RegularCamera.aspect;
            halfExtends.z = 0f;
            return halfExtends;
        }
    }
    #endregion
    #region Unity Methods

    private void Awake()
    {
        m_RegularCamera = GetComponent<Camera>();
        m_FocusPoint = m_Focus.position;
        transform.localRotation = Quaternion.Euler(m_OrbitAngles);
        m_OneByAlignSmoothRange = 1 / m_AlignSmoothRange;
    }
    private void LateUpdate()
    {
        UpdateFocusPoint();
        Quaternion lookRotation;
        if (ManualRotation() || AutomaticRotation())
        {
            ConstrainAngles();
            lookRotation = Quaternion.Euler(m_OrbitAngles);
        }
        else
        {
            lookRotation = transform.localRotation;
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            Vector2 input = new Vector2(Input.GetAxis("Mouse ScrollWheel"), 0);
            m_Distance = Mathf.Clamp(m_Distance += m_ZoomSpeed * Time.unscaledDeltaTime * -Mathf.Sign(input.x), 1f, 20f);
        }

        Vector3 lookDirection = lookRotation * Vector3.forward;
        Vector3 lookPosition = m_FocusPoint - lookDirection * m_Distance;

        Vector3 rectOffset = lookDirection * m_RegularCamera.nearClipPlane;
        Vector3 rectPosition = lookPosition + rectOffset;
        Vector3 castFrom = m_Focus.position;
        Vector3 castLine = rectPosition - castFrom;
        float castDistance = castLine.magnitude;
        Vector3 castDirection = castLine / castDistance;

        if (Physics.BoxCast(castFrom, CameraHalfExtends, castDirection, out RaycastHit hit, lookRotation, castDistance, m_ObstructionMask))
        {
            rectPosition = castFrom + castDirection * hit.distance;
            lookPosition = rectPosition - rectOffset;
        }

        transform.SetPositionAndRotation(lookPosition, lookRotation);
        
        
    }
    private void OnValidate()
    {
        if (m_MaxVerticalAngle < m_MinVerticalAngle)
        {
            m_MaxVerticalAngle = m_MinVerticalAngle;
        }
    }
    #endregion
    #region Private Methods

    void UpdateFocusPoint()
    {
        

        m_PreviousFocusPoint = m_FocusPoint;
        Vector3 targetPoint = m_Focus.position;
        if (m_FocusRadius > 0f)
        {
            float distance = Vector3.Distance(targetPoint, m_FocusPoint);
            float t = 1f;
            if (distance > 0.01f && m_FocusCentering > 0f)
            {
                t = Mathf.Pow(1f - m_FocusCentering, Time.unscaledDeltaTime);
            }
            if (distance > m_FocusRadius)
            {
                t = Mathf.Min(t, m_FocusRadius / distance);
            }
            m_FocusPoint = Vector3.Lerp(targetPoint, m_FocusPoint, t);
        }
        else
        {
            m_FocusPoint = targetPoint;
        }
    }
    bool ManualRotation()
    {
        Vector2 input = new Vector2(Input.GetAxis("Vertical Camera"), Input.GetAxis("Horizontal Camera"));
        const float e = 0.001f;
        if (input.x < -e || input.x > e || input.y < -e || input.y > e)
        {
            m_OrbitAngles += m_RotationSpeed * Time.unscaledDeltaTime * input;
            m_LastManualRotationTime = Time.unscaledTime;
            return true;
        }
        return false;
    }
    void ConstrainAngles()
    {
        m_OrbitAngles.x = Mathf.Clamp(m_OrbitAngles.x, m_MinVerticalAngle, m_MaxVerticalAngle);

        if (m_OrbitAngles.y < 0f)
        {
            m_OrbitAngles.y += 360f;
        }
        else if (m_OrbitAngles.y >= 360f)
        {
            m_OrbitAngles.y -= 360f;
        }
    }
    bool AutomaticRotation()
    {
        if (Time.unscaledTime - m_LastManualRotationTime < m_AlignDelay)
        {
            return false;
        }

        Vector2 movement = new Vector2(m_FocusPoint.x - m_PreviousFocusPoint.x, m_FocusPoint.z - m_PreviousFocusPoint.z);
        float movementDeltaSqr = movement.sqrMagnitude;
        if (movementDeltaSqr < 0.000001f)
        {
            return false;
        }
        float headingAngle = GetAngle(movement / Mathf.Sqrt(movementDeltaSqr));
        float deltaAbs = Mathf.Abs(Mathf.DeltaAngle(m_OrbitAngles.y, headingAngle));
        //float rotationChange = m_RotationSpeed * Mathf.Min(Time.unscaledDeltaTime, movementDeltaSqr);
        float rotationChange = m_RotationSpeed * Time.unscaledDeltaTime;
        if (deltaAbs < m_AlignSmoothRange)
        {
            rotationChange *= deltaAbs * m_OneByAlignSmoothRange;
        }
        else if (180f - deltaAbs < m_AlignSmoothRange)
        {
            rotationChange *= (180f - deltaAbs) * m_OneByAlignSmoothRange;
        }
        m_OrbitAngles.y = Mathf.MoveTowardsAngle(m_OrbitAngles.y, headingAngle, rotationChange);
        return true;
    }
    static float GetAngle(Vector2 direction)
    {
        float angle = Mathf.Acos(direction.y) * Mathf.Rad2Deg;
        return direction.x < 0f ? 360f - angle : angle;
    }

    #endregion
}