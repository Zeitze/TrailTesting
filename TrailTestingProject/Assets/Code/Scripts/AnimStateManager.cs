using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimStateManager : StateMachineBehaviour
{
    #region Public Members
    public SO_Animator m_AnimatorData;
    public SO_TrailRenderer[] m_TrailsData;
    #endregion

    #region Private members
    #endregion

    #region Getter Setter
    #endregion

    #region Public Methods
    public void SwitchAnim(string paramName)
    {
        m_AnimatorData.animator.SetBool(paramName, false);
    }
    public void SetAreTrailsEmitting(string parmaName, bool isEmitting)
    {
        m_AnimatorData.animator.SetBool(parmaName, isEmitting);
    }
    public void ActivateTrail(SO_TrailRenderer trailData, bool isEmitting)
    {
        if (trailData.trailRenderer == null)
        {
            Debug.LogWarning("SO_TrailRenderer has not been yet assign, " + this + "will not be executed properly.");
            return;
        }
        trailData.trailRenderer.emitting = isEmitting;
    }
    #endregion
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SwitchAnim(m_AnimatorData.m_ParameterNameA);
        
        SetAreTrailsEmitting(m_AnimatorData.m_ParameterNameB, false);
        for (int i = 0; i < m_TrailsData.Length; i++)
        {
            ActivateTrail(m_TrailsData[i], m_AnimatorData.animator.GetBool(m_AnimatorData.m_ParameterNameB));
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SetAreTrailsEmitting(m_AnimatorData.m_ParameterNameB, false);
        for (int i = 0; i < m_TrailsData.Length; i++)
        {
            ActivateTrail(m_TrailsData[i], m_AnimatorData.animator.GetBool(m_AnimatorData.m_ParameterNameB));
        }
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
