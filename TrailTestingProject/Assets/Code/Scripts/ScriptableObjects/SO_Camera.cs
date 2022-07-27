using UnityEditor;
using UnityEngine;

/// <summary>
/// The SO containing the data of a camera meant to be stocked in a SO_Cameras
/// </summary>
[CreateAssetMenu(fileName = "Camera", menuName = "ScriptableObjects/Camera", order = 1)]
public class SO_Camera : ScriptableObject
{
    #region Public Members
    #endregion

    #region Private Members
    /// <summary>
    /// The target display index of the camera in editor mode
    /// </summary>
    private int m_DisplayIndex;
    /// <summary>
    /// the Camera obkect
    /// </summary>
    private Camera m_Camera;
    #endregion

    #region Getter Setter
    /// <summary>
    /// Getter setter of the m_DisplayIndex, use to stock  the target display index of the camera in editor mode
    /// </summary>
    public int displayIndex
    {
        get { return m_DisplayIndex; }
        set { m_DisplayIndex = value; }
    }
    /// <summary>
    /// Getter Setter of the camera object
    /// </summary>
    public Camera camera
    {
        get { return m_Camera; }
        set { m_Camera = value; }
    }
    #endregion

    #region Public Methods
    /// <summary>
    /// Test the variables of the SO_Camera and desactivate the script if found empty
    /// </summary>
    /// <param name="go">GameObject tested</param>
    /// <param name="buttonScript">CameraManager script tested</param>
    public void TestCamera(GameObject go, CameraManager script)
    {
        if (m_Camera == null)
        {
            Debug.LogWarning("Attention ! " + go.name + "is missing a Camera element. The Button script on this will be disable", this);
            script.enabled = false;
            return;
        }
    }
    #endregion

}