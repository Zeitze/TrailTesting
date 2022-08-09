using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class MaterialManager : MonoBehaviour
{
    #region Public members
    /// <summary>
    /// SO containing the data of the material
    /// </summary>
    public SO_Material m_MaterialData;
    #endregion

    #region Private members
    #endregion

    #region Unity Methods
    public virtual void OnEnable()
    {
        TestData();
    }
    #endregion

    #region Public methods
    /// <summary>
    /// Test if the material reference is filled
    /// </summary>
    public virtual void TestData()
    {
        m_MaterialData.TestMaterial(gameObject, this);
    }
    #endregion

    #region Private methods
    #endregion
}
