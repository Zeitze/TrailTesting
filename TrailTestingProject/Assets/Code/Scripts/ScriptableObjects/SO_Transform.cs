using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

/// <summary>
/// The SO containing the data of a transform component
/// </summary>
[CreateAssetMenu(fileName = "Transform", menuName = "ScriptableObjects/Transform", order = 1)]
public class SO_Transform : ScriptableObject
{
    #region Public Members
    #endregion

    #region Private members
    private Transform m_Transform;
    #endregion

    #region Getter Setter
    public Transform transform
    {
        get { return m_Transform; }
        set { m_Transform = value; }
    }
    #endregion

    #region Public methods
    #endregion
}