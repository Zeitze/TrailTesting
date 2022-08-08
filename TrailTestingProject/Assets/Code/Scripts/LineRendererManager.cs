using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(LineRenderer))]
public class LineRendererManager : MonoBehaviour
{
    #region Public members
    /// <summary>
    /// SO containing the data of the line renderer
    /// </summary>
    public SO_LineRenderer m_LineRendererData;
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
    /// Fill the data of the SO with the line renderer object data
    /// </summary>
    public virtual void FillData()
    {
        m_LineRendererData.lineRenderer = GetComponent<LineRenderer>();
    }
    /// <summary>
    /// Test if the data is correctly filled
    /// </summary>
    public virtual void TestData()
    {
        m_LineRendererData.TestLineRenderer(gameObject, this);
    }
    #endregion

    #region Private methods
    #endregion
}
