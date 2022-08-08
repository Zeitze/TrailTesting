using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

/// <summary>
/// The SO containing the configuration data for trail renderers
/// </summary>
[CreateAssetMenu(fileName = "TrailRendererConfig", menuName = "ScriptableObjects/TrailRendererConfig", order = 1)]
public class SO_TrailRendererConfig : SO_LineRendererConfig
{
    #region Public Members
    public float m_Time = 5f;
    public float m_MinVertexDistance = 0.1f;
    public bool m_Autodestruct = false;
    public bool m_Emitting = true;
    #endregion

    #region Private members
    #endregion

    #region Getter Setter
    #endregion

    #region Public methods
    #endregion
}