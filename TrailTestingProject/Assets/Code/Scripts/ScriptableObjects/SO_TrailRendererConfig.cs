using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

/// <summary>
/// The SO containing the configuration data for trail renderers
/// </summary>
[CreateAssetMenu(fileName = "TrailRendererConfig", menuName = "ScriptableObjects/TrailRendererConfig", order = 1)]
public class SO_TrailRendererConfig : ScriptableObject
{
    #region Public Members
    public AnimationCurve m_Width;
    public float m_Time = 5f;
    public float m_MinVertexDistance = 0.1f;
    public bool m_Autodestruct = false;
    public bool m_Emitting = true;
    public Gradient m_Color;
    public int m_CornerVertices = 0;
    public int m_EndCapVertices = 0;
    public LineAlignment m_Alignement = LineAlignment.View;
    public LineTextureMode m_TextureMode = LineTextureMode.Stretch;
    public bool m_GeneralLightingData = false;
    public float m_ShadowBias = 0.5f;
    public Material[] m_Materials;
    [Header("Lighting")]
    public ShadowCastingMode m_CastShadows = ShadowCastingMode.On;
    public bool m_StaticShadowCaster = false;
    [Header("Probes")]
    public LightProbeUsage m_LightProbes = LightProbeUsage.Off;
    [Header("Additional Settings")]
    public bool m_DynamicOcclusion = true;
    public SortingLayer m_SortingLayer;

    public int m_OrderInLayer = 0;
    public LayerMask m_RenderingLayerMask;
    #endregion

    #region Private members
    #endregion

    #region Getter Setter
    public int sortingLayer
    {
        get { return m_SortingLayer.id; }
    }
    public uint renderingLayerMask
    {
        get { return (uint)m_RenderingLayerMask.value; }
    }
    #endregion

    #region Public methods
    #endregion
}