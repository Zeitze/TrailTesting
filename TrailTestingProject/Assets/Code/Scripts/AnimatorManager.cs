using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Fill and test the data of SO with an animator object data
/// </summary>
[RequireComponent(typeof(Animator))]
public class AnimatorManager : MonoBehaviour
{
    #region Public Members
    public SO_Animator m_AnimatorData;
    #endregion

    #region Private members
    #endregion

    #region Getter Setter
    #endregion

    #region Unity Methods
    private void OnEnable()
    {
        m_AnimatorData.animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown("n"))
        {
            m_AnimatorData.animator.SetBool(m_AnimatorData.m_ParameterNameA, true);
        }
    }
    #endregion

    #region Public Methods
    public void SwitchAnim()
    {
        m_AnimatorData.animator.SetBool(m_AnimatorData.m_ParameterNameA, false);
    }
    #endregion

}
