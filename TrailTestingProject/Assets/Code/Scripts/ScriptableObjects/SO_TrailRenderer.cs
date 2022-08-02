using UnityEditor;
using UnityEngine;

/// <summary>
/// The SO containing the data for a trail renderer
/// </summary>
[CreateAssetMenu(fileName = "TrailRenderer", menuName = "ScriptableObjects/TrailRenderer", order = 1)]
public class SO_TrailRenderer : ScriptableObject
{
    #region Public Members
    /// <summary>
    /// Index of the configuration targeted by this trail renderer
    /// </summary>
    public int m_TargetConfig = 0;
    #endregion

    #region Private members
    private TrailRenderer m_TrailRenderer;
    #endregion

    #region Getter Setter
    public TrailRenderer trailRenderer
    {
        get { return m_TrailRenderer; }
        set { m_TrailRenderer = value; }
    }
    #endregion

    #region Public methods
    /// <summary>
    /// Test the variables of the SO_Camera and desactivate the script if found empty
    /// </summary>
    /// <param name="go">GameObject tested</param>
    /// <param name="buttonScript">TrailRendererManager script tested</param>
    public virtual void TestTrailRenderer(GameObject go, TrailRendererManager script)
    {
        if (m_TrailRenderer == null)
        {
            Debug.LogWarning("Attention ! " + go.name + "is missing a TrailRenderer element. The TrailManager script on this will be disable", this);
            script.enabled = false;
            return;
        }
    }
    #endregion
}