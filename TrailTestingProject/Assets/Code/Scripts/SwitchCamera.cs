using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Switch between cameras at runtime at one targeted display 
/// </summary>
public class SwitchCamera : MonoBehaviour
{
    #region Public members
    public SO_Cameras m_CamerasData;
    #endregion

    #region Private members
    #endregion

    #region Unity Methods
    private void Start()
    {
        int actCam = m_CamerasData.activeCameraIndex = 0;
        m_CamerasData.m_Cameras[actCam].camera.enabled = true;
        SwitchingCamera(actCam);
    }
    private void OnEnable()
    {
        //Forcing all the camera on display 1 at runtime
        for (int i = 0; i < m_CamerasData.m_Cameras.Length; i++)
        {
            m_CamerasData.m_Cameras[i].camera.targetDisplay = m_CamerasData.m_DisplayIndex;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            m_CamerasData.activeCameraIndex = NextCamIndex(m_CamerasData.activeCameraIndex);
            SwitchingCamera(m_CamerasData.activeCameraIndex);
        }
    }
    #endregion

    #region Private Methods
    /// <summary>
    /// Change the index of tha active camera to the index of the next element of the array
    /// </summary>
    /// <param name="actCam">current active camera</param>
    /// <returns></returns>
    private int NextCamIndex(int actCam)
    {
        actCam = actCam + 1 < m_CamerasData.m_Cameras.Length ? actCam + 1 : 0;
        return actCam;
    }
    /// <summary>
    /// Switch to the next camera
    /// </summary>
    /// <param name="nextCam">next active camera</param>
    private void SwitchingCamera(int nextCam)
    {
        for (int i = 0; i<m_CamerasData.m_Cameras.Length; i++)
        {
            m_CamerasData.m_Cameras[i].camera.enabled = i == nextCam? true : false;
        }
    }
    #endregion
}
