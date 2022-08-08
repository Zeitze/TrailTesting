using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LinesManager : MonoBehaviour
{
    #region Public Members
    public SO_LineRendererConfig[] m_LineConfig;
    public SO_LineRenderer[] m_LinesData;
    #endregion

    #region Private members
    #endregion

    #region Getter Setter
    #endregion

    #region Unity methods
    private void OnEnable()
    {
        TestData();
        for (int i = 0; i < m_LinesData.Length; i++)
        {
            m_LinesData[i].lineRenderer.widthCurve = m_LineConfig[m_LinesData[i].m_TargetConfig].m_Width;
            m_LinesData[i].lineRenderer.colorGradient = m_LineConfig[m_LinesData[i].m_TargetConfig].m_Color;
            m_LinesData[i].lineRenderer.numCornerVertices = m_LineConfig[m_LinesData[i].m_TargetConfig].m_CornerVertices;
            m_LinesData[i].lineRenderer.numCapVertices = m_LineConfig[m_LinesData[i].m_TargetConfig].m_EndCapVertices;
            m_LinesData[i].lineRenderer.alignment = m_LineConfig[m_LinesData[i].m_TargetConfig].m_Alignement;
            m_LinesData[i].lineRenderer.textureMode = m_LineConfig[m_LinesData[i].m_TargetConfig].m_TextureMode;
            m_LinesData[i].lineRenderer.generateLightingData = m_LineConfig[m_LinesData[i].m_TargetConfig].m_GeneralLightingData;
            m_LinesData[i].lineRenderer.shadowBias = m_LineConfig[m_LinesData[i].m_TargetConfig].m_ShadowBias;
            m_LinesData[i].lineRenderer.materials = m_LineConfig[m_LinesData[i].m_TargetConfig].m_Materials;
            m_LinesData[i].lineRenderer.shadowCastingMode = m_LineConfig[m_LinesData[i].m_TargetConfig].m_CastShadows;
            m_LinesData[i].lineRenderer.staticShadowCaster = m_LineConfig[m_LinesData[i].m_TargetConfig].m_StaticShadowCaster;
            m_LinesData[i].lineRenderer.lightProbeUsage = m_LineConfig[m_LinesData[i].m_TargetConfig].m_LightProbes;
            m_LinesData[i].lineRenderer.allowOcclusionWhenDynamic = m_LineConfig[m_LinesData[i].m_TargetConfig].m_DynamicOcclusion;
            m_LinesData[i].lineRenderer.sortingLayerID = m_LineConfig[m_LinesData[i].m_TargetConfig].sortingLayer;
            m_LinesData[i].lineRenderer.sortingOrder = m_LineConfig[m_LinesData[i].m_TargetConfig].m_OrderInLayer;
            m_LinesData[i].lineRenderer.renderingLayerMask = m_LineConfig[m_LinesData[i].m_TargetConfig].renderingLayerMask;

        }
    }
    private void Update()
    {

    }
    #endregion

    #region Public methods
    private void TestData()
    {
        if (m_LineConfig == null || m_LineConfig.Length <= 0)
        {
            Debug.LogWarning("Attention ! m_LineConfig is not set. The LinesManager script on this will be disable", this);
            this.enabled = false;
            return;
        }
        if (m_LinesData == null || m_LinesData.Length <= 0)
        {
            Debug.LogWarning("Attention ! m_LinesData array is empty. The LinesManager script on this will be disable", this);
            this.enabled = false;
            return;
        }
    }
    #endregion
}
