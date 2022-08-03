using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedTrailRendererManager : TrailRendererManager
{
    #region Public Members
    public float m_FadeDebug;
    public AnimationCurve m_FadeCurve;
    #endregion

    #region Private members
    private float m_CurrentTime;
    //private int m_SegmentCount;
    #endregion

    #region Getter Setter
    #endregion

    #region Unity Methods
    private void Start()
    {

    }
    private void Update()
    {

    }
    private void FixedUpdate()
    {
        Test();
    }
    #endregion

    #region Public methods
    public void Test()
    {
        
        if (m_TrailRendererData.trailRenderer.emitting)
        {
            m_TrailRendererData.trailRenderer.sharedMaterial.SetFloat("_FadeAnim", 0f);
            m_CurrentTime = 0;
            //m_SegmentCount = m_TrailRendererData.trailRenderer.positionCount;
            return;
        }
        m_CurrentTime += Time.unscaledDeltaTime;
        float percentTime = m_CurrentTime / m_TrailRendererData.trailRenderer.time;
        float percentCurve = m_FadeCurve.Evaluate(percentTime);
        /*
        m_SegmentCount -= 1;
        float percentGeo = (float)m_SegmentCount / (float)m_TrailRendererData.trailRenderer.positionCount;
        */
        m_TrailRendererData.trailRenderer.sharedMaterial.SetFloat("_FadeAnim",percentCurve);
        m_FadeDebug = m_TrailRendererData.trailRenderer.material.GetFloat("_FadeAnim");

    }
    #endregion
}
