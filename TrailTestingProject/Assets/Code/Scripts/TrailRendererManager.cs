using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(TrailRenderer))]
public class TrailRendererManager : MonoBehaviour
{
    #region Public members
    /// <summary>
    /// SO containing the data of the camera
    /// </summary>
    public SO_TrailRenderer m_TrailRendererData;
    #endregion

    #region Private members
    #endregion

    #region Unity Methods
    public virtual void OnEnable()
    {
        FillData();
        TestData();
    }
    #endregion

    #region Public methods
    /// <summary>
    /// Fill the data of the SO with the trail renderer object data
    /// </summary>
    public virtual void FillData()
    {
        m_TrailRendererData.trailRenderer = GetComponent<TrailRenderer>();
    }
    /// <summary>
    /// Test if the data is correctly filled
    /// </summary>
    public virtual void TestData()
    {
        m_TrailRendererData.TestTrailRenderer(gameObject, this);
    }
    #endregion

    #region Private methods
    #endregion
}
