using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Fill and test the data of a camera object meant to be switched in between at runtime with other cameras at one targeted display 
/// </summary>
[RequireComponent(typeof(Camera))]
public class CameraManager : MonoBehaviour
{
    #region Public members
    /// <summary>
    /// SO containing the data of the camera
    /// </summary>
    public SO_Camera m_CameraData;
    #endregion

    #region Private members
    #endregion

    #region Unity Methods
    public virtual void OnEnable()
    {
        FillData();
        TestData();
    }
    public virtual void OnDisable()
    {
        ResetTargetDisplay();
    }
    #endregion

    #region Public methods
    /// <summary>
    /// Fill the data of the SO with the camera object data
    /// </summary>
    public virtual void FillData()
    {
        m_CameraData.camera = GetComponent<Camera>();
        m_CameraData.displayIndex = m_CameraData.camera.targetDisplay;
        
    }
    /// <summary>
    /// Test if the data is correctly filled
    /// </summary>
    public virtual void TestData()
    {
        m_CameraData.TestCamera(gameObject, this);
    }
    /// <summary>
    /// Retargeting the camera at its original display in edit mode
    /// </summary>
    public virtual void ResetTargetDisplay()
    {
        m_CameraData.camera.targetDisplay = m_CameraData.displayIndex;
    }
    #endregion

    #region Private methods
    #endregion
}
