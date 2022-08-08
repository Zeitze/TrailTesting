using UnityEditor;
using UnityEngine;

/// <summary>
/// The SO containing the data for a line renderer
/// </summary>
[CreateAssetMenu(fileName = "LineRenderer", menuName = "ScriptableObjects/LineRenderer", order = 1)]
public class SO_LineRenderer : ScriptableObject
{
    #region Public Members
    /// <summary>
    /// Index of the configuration targeted by this line renderer
    /// </summary>
    public int m_TargetConfig = 0;
    #endregion

    #region Private members
    private LineRenderer m_LineRenderer;
    #endregion

    #region Getter Setter
    public LineRenderer lineRenderer
    {
        get { return m_LineRenderer; }
        set { m_LineRenderer = value; }
    }
    #endregion

    #region Public methods
    /// <summary>
    /// Test the variables of the SO_Camera and desactivate the script if found empty
    /// </summary>
    /// <param name="go">GameObject tested</param>
    /// <param name="script">LineRendererManager script tested</param>
    public virtual void TestLineRenderer(GameObject go, LineRendererManager script)
    {
        if (m_LineRenderer == null)
        {
            Debug.LogWarning("Attention ! " + go.name + "is missing a LineRenderer element. The LineRendererManager script on this will be disable", this);
            script.enabled = false;
            return;
        }
    }
    #endregion
}