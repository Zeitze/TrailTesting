using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailPositionsGetter : MonoBehaviour
{
    #region Public members
    public SO_AnimatedTrailRenderer m_TrailRendererData;
    public SO_Vector3Array m_PositionsData;
    #endregion

    #region Public Methods
    public void FillPositions()
    {
        m_PositionsData.array = new Vector3[m_TrailRendererData.trailRenderer.positionCount];
        m_TrailRendererData.trailRenderer.GetPositions(m_PositionsData.array);
    }
    #endregion
}
