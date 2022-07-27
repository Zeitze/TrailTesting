using UnityEditor;
using UnityEngine;

/// <summary>
/// The SO containing the possible active cameras for one display
/// </summary>
[CreateAssetMenu(fileName = "Cameras", menuName = "ScriptableObjects/Cameras", order = 1)]
public class SO_Cameras : ScriptableObject
{
    #region Public Members
    /// <summary>
    /// The index of the display targeted at runtime by the cameras
    /// </summary>
    public int m_DisplayIndex;
    /// <summary>
    /// The array containing the data of the cameras
    /// </summary>
    public SO_Camera[] m_Cameras;
    #endregion

    #region private members
    /// <summary>
    /// The index of the active camera
    /// </summary>
    private int m_ActiveCameraIndex;
    #endregion

    #region Getter Setter
    /// <summary>
    /// Getter setter of the active camera index
    /// </summary>
    public int activeCameraIndex
    {
        get { return m_ActiveCameraIndex; }
        set { m_ActiveCameraIndex = value; }
    }
    #endregion
}