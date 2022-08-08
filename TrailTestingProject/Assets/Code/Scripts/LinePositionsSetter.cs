using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(LineRenderer))]
public class LinePositionsSetter : MonoBehaviour
{
    public SO_Vector3Array m_Positions;

    private LineRenderer m_LineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        m_LineRenderer = GetComponent<LineRenderer>();
        m_LineRenderer.positionCount = m_Positions.array.Length;
        m_LineRenderer.SetPositions(m_Positions.array);
    }

}
