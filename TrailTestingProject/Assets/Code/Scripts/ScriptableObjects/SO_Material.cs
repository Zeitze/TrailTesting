using UnityEditor;
using UnityEngine;

/// <summary>
/// The SO containing the data for a material
/// </summary>
[CreateAssetMenu(fileName = "Material", menuName = "ScriptableObjects/Material", order = 1)]
public class SO_Material : ScriptableObject
{
    #region Public Members
    /// <summary>
    /// Material managed
    /// </summary>
    public Material m_Material;
    /// <summary>
    /// Name of the material properties
    /// </summary>
    public string[] m_PropertiesNames;
    #endregion

    #region Private members
    #endregion

    #region Getter Setter
    #endregion

    #region Public methods
    /// <summary>
    /// Test the variables of the SO_Camera and desactivate the script if found empty
    /// </summary>
    /// <param name="go">GameObject tested</param>
    /// <param name="script">LineRendererManager script tested</param>
    public virtual void TestMaterial(GameObject go, MaterialManager script)
    {
        if (m_Material == null)
        {
            Debug.LogWarning("Attention ! " + go.name + "is missing a Material. The MaterialManager script on this will be disable", this);
            script.enabled = false;
            return;
        }
    }
    #endregion
}