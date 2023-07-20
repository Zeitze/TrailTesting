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
    /// <summary>
    /// SOs containing the data of the exposed material properties
    /// </summary>
    public SO_ShaderProperty[] m_ShaderProperties;
    #endregion

    #region Private members
    #endregion

    #region Unity Methods
    public virtual void OnEnable()
    {
        TestData();

        if (m_ShaderProperties.Length <= 0)
        {
            Debug.LogWarning("No materiel property found");
            return;
        }

        for (int i = 0; i < m_ShaderProperties.Length; i++)
        {
            //m_ShaderProperties[i].m_PropertyName
        }
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
