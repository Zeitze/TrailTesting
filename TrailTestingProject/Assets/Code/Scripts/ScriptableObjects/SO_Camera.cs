using UnityEditor;
using UnityEngine;

/// <summary>
/// The SO containing the possible active cameras
/// </summary>
[CreateAssetMenu(fileName = "Camera", menuName = "ScriptableObjects/Camera", order = 1)]
public class SO_Camera : ScriptableObject
{
    #region Private Members
    private Camera m_Camera;
    #endregion

    #region Getter Setter
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