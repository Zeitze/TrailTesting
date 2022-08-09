using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(Transform))]
public class TransformManager : MonoBehaviour
{
    #region Public members
    /// <summary>
    /// SO containing the data of the transform
    /// </summary>
    public SO_Transform m_TransformData;
    #endregion

    #region Private members
    #endregion

    #region Unity Methods
    public virtual void OnEnable()
    {
        FillData();
    }
    #endregion

    #region Public methods
    /// <summary>
    /// Fill the data of the SO with thetransform component data
    /// </summary>
    public virtual void FillData()
    {
        m_TransformData.transform = GetComponent<Transform>();
    }
    #endregion

    #region Private methods
    #endregion
}
