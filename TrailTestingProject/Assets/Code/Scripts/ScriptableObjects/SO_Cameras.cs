using UnityEditor;
using UnityEngine;

/// <summary>
/// The SO containing the possible active cameras
/// </summary>
[CreateAssetMenu(fileName = "Cameras", menuName = "ScriptableObjects/Cameras", order = 1)]
public class SO_Cameras : ScriptableObject
{
    #region Public Members
    public SO_Camera[] m_Cameras;
    #endregion

    #region private members
    private int m_ActiveCameraIndex;
    #endregion

    #region Getter Setter
    
    public int activeCameraIndex
    {
        get { return m_ActiveCameraIndex; }
        set { m_ActiveCameraIndex = value; }
    }
    #endregion
}