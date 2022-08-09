using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TrailsManager : MonoBehaviour
{
    #region Public Members
    public SO_TrailRendererConfig[] m_TrailConfig;
    public SO_TrailRenderer[] m_TrailsData;
    #endregion

    #region Private members
    #endregion

    #region Getter Setter
    #endregion

    #region Unity methods
    private void OnEnable()
    {
        TestData();
        for (int i = 0; i < m_TrailsData.Length; i++)
        {
            if (m_TrailsData[i].trailRenderer == null)
            {
                Debug.LogWarning("Trail data null. A trail linked in the array of the trails manager is probably not active. Trail index :"+i);
                break;
            }
            m_TrailsData[i].trailRenderer.widthCurve = m_TrailConfig[m_TrailsData[i].m_TargetConfig].m_Width;
            m_TrailsData[i].trailRenderer.time = m_TrailConfig[m_TrailsData[i].m_TargetConfig].m_Time;
            m_TrailsData[i].trailRenderer.minVertexDistance = m_TrailConfig[m_TrailsData[i].m_TargetConfig].m_MinVertexDistance;
            m_TrailsData[i].trailRenderer.autodestruct = m_TrailConfig[m_TrailsData[i].m_TargetConfig].m_Autodestruct;
            m_TrailsData[i].trailRenderer.emitting = m_TrailConfig[m_TrailsData[i].m_TargetConfig].m_Emitting;
            m_TrailsData[i].trailRenderer.colorGradient = m_TrailConfig[m_TrailsData[i].m_TargetConfig].m_Color;
            m_TrailsData[i].trailRenderer.numCornerVertices = m_TrailConfig[m_TrailsData[i].m_TargetConfig].m_CornerVertices;
            m_TrailsData[i].trailRenderer.numCapVertices = m_TrailConfig[m_TrailsData[i].m_TargetConfig].m_EndCapVertices;
            m_TrailsData[i].trailRenderer.alignment = m_TrailConfig[m_TrailsData[i].m_TargetConfig].m_Alignement;
            m_TrailsData[i].trailRenderer.textureMode = m_TrailConfig[m_TrailsData[i].m_TargetConfig].m_TextureMode;
            m_TrailsData[i].trailRenderer.generateLightingData = m_TrailConfig[m_TrailsData[i].m_TargetConfig].m_GeneralLightingData;
            m_TrailsData[i].trailRenderer.shadowBias = m_TrailConfig[m_TrailsData[i].m_TargetConfig].m_ShadowBias;
            m_TrailsData[i].trailRenderer.materials = m_TrailConfig[m_TrailsData[i].m_TargetConfig].m_Materials;
            m_TrailsData[i].trailRenderer.shadowCastingMode = m_TrailConfig[m_TrailsData[i].m_TargetConfig].m_CastShadows;
            m_TrailsData[i].trailRenderer.staticShadowCaster = m_TrailConfig[m_TrailsData[i].m_TargetConfig].m_StaticShadowCaster;
            m_TrailsData[i].trailRenderer.lightProbeUsage = m_TrailConfig[m_TrailsData[i].m_TargetConfig].m_LightProbes;
            m_TrailsData[i].trailRenderer.allowOcclusionWhenDynamic = m_TrailConfig[m_TrailsData[i].m_TargetConfig].m_DynamicOcclusion;
            m_TrailsData[i].trailRenderer.sortingLayerID = m_TrailConfig[m_TrailsData[i].m_TargetConfig].sortingLayer;
            m_TrailsData[i].trailRenderer.sortingOrder = m_TrailConfig[m_TrailsData[i].m_TargetConfig].m_OrderInLayer;
            m_TrailsData[i].trailRenderer.renderingLayerMask = m_TrailConfig[m_TrailsData[i].m_TargetConfig].renderingLayerMask;

        }
    }
    private void Update()
    {
        
    }
    #endregion

    #region Public methods
    private void TestData()
    {
        if (m_TrailConfig == null || m_TrailConfig.Length <= 0)
        {
            Debug.LogWarning("Attention ! SO_TrailRendererConfig is not set. The TrailsManager script on this will be disable", this);
            this.enabled = false;
            return;
        }
        if (m_TrailsData == null || m_TrailsData.Length <= 0)
        {
            Debug.LogWarning("Attention ! SO_TrailsData array is empty. The TrailsManager script on this will be disable", this);
            this.enabled = false;
            return;
        }
    }
    #endregion
}
