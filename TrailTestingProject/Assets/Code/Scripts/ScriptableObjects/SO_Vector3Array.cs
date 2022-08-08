using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

/// <summary>
/// The SO containing the data of an array of vector3
/// </summary>
[CreateAssetMenu(fileName = "Vector3Array", menuName = "ScriptableObjects/Vector3Array", order = 1)]
public class SO_Vector3Array : ScriptableObject
{
    #region Public Members
    public Vector3[] m_Array;
    #endregion

    #region Private members
    #endregion

    #region Getter Setter
    public Vector3[] array
    {
        get { return m_Array; }
        set { m_Array = value; }
    }
    #endregion

    #region Public methods
    #endregion
}