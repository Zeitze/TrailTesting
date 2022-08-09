using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Enum Shader Variable type
/// </summary>
public enum EShaderVariableType
{
    Float,
    Vector2,
    Vector3,
    Vector4,
    Color,
    Boolean,
    Gradient,
    Texture2D,
    Texture2DArray,
    Texture3D,
    Cubemap,
    VirtualTexture,
    Matrix2,
    Matrix3,
    Matrix4,
    SamplerState
}

/// <summary>
/// The SO containing the data of a shader variable
/// </summary>
[CreateAssetMenu(fileName = "ShaderVariable", menuName = "ScriptableObjects/ShaderVariable")]
public class SO_ShaderProperty : ScriptableObject
{
    #region Public Members
    /// <summary>
    /// Name of the property
    /// </summary>    
    public string m_PropertyName;
    /// <summary>
    /// Type of the property
    /// </summary>
    public EShaderVariableType m_Type;

    /// <summary>
    /// float value
    /// </summary>
    public float m_FloatValue;
    /// <summary>
    /// Vector2 value
    /// </summary>
    public Vector2 m_Vector2Value;
    /// <summary>
    /// Vector3 value
    /// </summary>
    public Vector3 m_Vector3Value;
    /// <summary>
    /// Vector4 value
    /// </summary>
    public Vector4 m_Vector4Value;
    /// <summary>
    /// Color value
    /// </summary>
    public Color m_ColorValue;
    /// <summary>
    /// Boolean value
    /// </summary>
    public bool m_BooleanValue;
    /// <summary>
    /// Gradient value
    /// </summary>
    public Gradient m_GradientValue;
    /// <summary>
    /// Texture 2D asset
    /// </summary>
    public Texture2D m_Texture2D;
    /// <summary>
    /// Texture 2D array asset
    /// </summary>
    public Texture2DArray m_Texture2DArray;
    /// <summary>
    /// Texture3D asset
    /// </summary>
    public Texture3D m_Texture3D;
    /// <summary>
    /// Cubemap asset
    /// </summary>
    public Cubemap m_Cubemap;
    #endregion

    #region Public Methods
    /// <summary>
    /// Test the variables of the SO_Button and desavtivate the script if found empty
    /// </summary>
    /// <param name="go">GameObject tested</param>
    /// <param name="script">MaterialManager script tested</param>
    public void TestShaderVariable(GameObject go, MaterialManager script)
    {
        switch (m_Type)
        {
            case EShaderVariableType.Float:
                break;
            case EShaderVariableType.Vector2:
                break;
            case EShaderVariableType.Vector3:
                break;
            case EShaderVariableType.Vector4:
                break;
            case EShaderVariableType.Color:
                break;
            case EShaderVariableType.Boolean:
                break;
            case EShaderVariableType.Gradient:
                break;
            case EShaderVariableType.Texture2D:
                break;
            case EShaderVariableType.Texture2DArray:
                break;
            case EShaderVariableType.Texture3D:
                break;
            case EShaderVariableType.Cubemap:
                break;
            case EShaderVariableType.VirtualTexture:
                break;
            case EShaderVariableType.Matrix2:
                break;
            case EShaderVariableType.Matrix3:
                break;
            case EShaderVariableType.Matrix4:
                break;
            case EShaderVariableType.SamplerState:
                break;
            default:
                break;
        }
    }
    #endregion
}


/// <summary>
/// Cutom Editor, switch between the variables field input according to the selected type of the property
/// </summary>
[CustomEditor (typeof(SO_ShaderProperty)), CanEditMultipleObjects]
public class ButtonEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        SO_ShaderProperty property = (SO_ShaderProperty)target;

        property.m_Type = (EShaderVariableType)EditorGUILayout.EnumPopup("Shader Variable Type", property.m_Type);

        string fieldName01 = "Property Name";
        string fieldName02 = "Value";
        if (property.m_Type == EShaderVariableType.Float)
        {
            property.m_PropertyName = EditorGUILayout.TextField(fieldName01, property.m_PropertyName);
            property.m_FloatValue = EditorGUILayout.FloatField(fieldName02, property.m_FloatValue);
        }
        if (property.m_Type == EShaderVariableType.Vector2)
        {
            property.m_PropertyName = EditorGUILayout.TextField(fieldName01, property.m_PropertyName);
            property.m_Vector2Value = EditorGUILayout.Vector2Field(fieldName02, property.m_Vector2Value);
        }
        if (property.m_Type == EShaderVariableType.Vector3)
        {
            property.m_PropertyName = EditorGUILayout.TextField(fieldName01, property.m_PropertyName);
            property.m_Vector3Value = EditorGUILayout.Vector3Field(fieldName02, property.m_Vector3Value);
        }
        if (property.m_Type == EShaderVariableType.Vector4)
        {
            property.m_PropertyName = EditorGUILayout.TextField(fieldName01, property.m_PropertyName);
            property.m_Vector4Value = EditorGUILayout.Vector4Field(fieldName02, property.m_Vector4Value);
        }

    }
}
