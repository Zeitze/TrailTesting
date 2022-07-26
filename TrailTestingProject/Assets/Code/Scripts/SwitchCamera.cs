using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            int actCam = m_CamerasData.activeCameraIndex;
            actCam = actCam + 1 < m_CamerasData.m_Cameras.Length ? actCam + 1 : 0;
            m_CamerasData.activeCameraIndex = actCam;
            SwitchingCamera(actCam);
        }
    }
    #endregion

    #region Private Methods
    private void SwitchingCamera(int actCam)
    {
        for (int i = 0; i<m_CamerasData.m_Cameras.Length; i++)
        {
            m_CamerasData.m_Cameras[i].camera.enabled = i == actCam? true : false;
        }
    }
    #endregion
}
