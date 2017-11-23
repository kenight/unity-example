using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

// 可编辑多对象
[CanEditMultipleObjects]
// Inspector 对应的脚本,此脚本在序列化后可进行对象和属性的访问
// 通过 ScriptableObject 变量访问序列化后的对象
// 通过 target 访问挂载该脚本的 GameObject
[CustomEditor(typeof(MoveWithAxes))]
public class MoveWithAxesInspector : Editor
{
    void OnEnable() { }

    // 重写 Editor OnInspectorGUI 方法进行绘制
    public override void OnInspectorGUI()
    {
        // 更新编辑器显示的序列化属性
        serializedObject.Update();

        GUILayout.Space(10);
        DrawMovement();

        GUILayout.Space(10);
        DrawChangeFacing();

        GUILayout.Space(10);
        DrawMovingAnimation();

        if (GUI.changed)
            // 给序列化对象应用属性的修改,否则被序列化的对象(脚本)的属性并没有被修改
            serializedObject.ApplyModifiedProperties();
    }

    void DrawMovement()
    {
        // Label
        EditorGUILayout.LabelField("Movement", EditorStyles.boldLabel);
        GUILayout.Space(5);

        // 绘制属性
        EditorGUILayout.PropertyField(serializedObject.FindProperty("horizontalAxis"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("verticalAxis"));

        EditorGUILayout.PropertyField(serializedObject.FindProperty("movementType"));

        EditorGUILayout.PropertyField(serializedObject.FindProperty("speed"));
        EditorGUILayout.HelpBox("You need to set Rigidbody2D \"Linear Drag\" (maybe 20) to control the speed", MessageType.Info);
    }

    void DrawChangeFacing()
    {
        // Label
        EditorGUILayout.LabelField("Facing", EditorStyles.boldLabel);
        GUILayout.Space(5);

        // 获取 changeFacing 属性的默认值
        bool defaultValue = serializedObject.FindProperty("changeFacing").boolValue;

        // 根据默认值绘制一个 Toggle
        bool enable = EditorGUILayout.Toggle("Change Facing", defaultValue);

        if (enable)
            // 绘制 facingLeft 属性
            EditorGUILayout.PropertyField(serializedObject.FindProperty("facingLeft"));

        // 为序列化对象对应的属性重新赋值
        serializedObject.FindProperty("changeFacing").boolValue = enable;
    }

    void DrawMovingAnimation()
    {
        // Label
        EditorGUILayout.LabelField("Animation", EditorStyles.boldLabel);
        GUILayout.Space(5);

        // 获取 useAnimation 属性的默认值
        bool defaultValue = serializedObject.FindProperty("useAnimation").boolValue;

        // 根据默认值绘制一个 Toggle
        bool enable = EditorGUILayout.Toggle("Use Animation", defaultValue);

        if (enable)
        {
            // 绘制 parameterName 属性
            EditorGUILayout.PropertyField(serializedObject.FindProperty("parameterName"));
            // 绘制一个提示信息
            EditorGUILayout.HelpBox("Need a float parameter to check if play animation", MessageType.Info);
        }

        // 为序列化对象对应的属性重新赋值
        serializedObject.FindProperty("useAnimation").boolValue = enable;
    }
}
