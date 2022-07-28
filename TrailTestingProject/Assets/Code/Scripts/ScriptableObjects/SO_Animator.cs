using UnityEditor;
using UnityEngine;

/// <summary>
/// The SO containing the possible active cameras for one display
/// </summary>
[CreateAssetMenu(fileName = "Animator", menuName = "ScriptableObjects/Animator", order = 1)]
public class SO_Animator : ScriptableObject
{
    #region Public Members
    public string m_ParameterNameA;
    #endregion

    #region private members
    private Animator m_Animator;
    #endregion

    #region Getter Setter
    public Animator animator
    {
        get { return m_Animator; }
        set { m_Animator = value; }
    }
    #endregion
}