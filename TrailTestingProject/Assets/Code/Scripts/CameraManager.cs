using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    /*public virtual void Awake()
    {
        FillData();
        TestData();
    }*/
    public virtual void OnEnable()
    {
        FillData();
        TestData();
    }
    public virtual void FillData()
    {
        m_CameraData.camera = GetComponent<Camera>();
        
    }
    public virtual void TestData()
    {
        m_CameraData.TestCamera(gameObject, this);
    }
    #endregion
}
