using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedTrailRendererManager : TrailRendererManager
{
    #region Public Members
    [Range(0f, 1f)] public float m_FadeDefault;
    [Range(0f, 1f)] public float m_FadeAdjust;
    #endregion

    #region Private members
    #endregion

    #region Getter Setter
    #endregion

    #region Unity Methods
    private void Start()
    {

    }
    private void Update()
    {
        if (m_TrailRendererData.trailRenderer.emitting)
        {
            m_TrailRendererData.trailRenderer.sharedMaterial.SetFloat("_FadeAnim", 0f);
            return;
        }
        float percent = 1f / ((float)m_TrailRendererData.trailRenderer.positionCount*m_FadeAdjust + 0.0000000001f);
        m_TrailRendererData.trailRenderer.sharedMaterial.SetFloat("_FadeAnim", Mathf.Clamp01(percent));
    }
    #endregion

    #region Public methods
    #endregion
}
