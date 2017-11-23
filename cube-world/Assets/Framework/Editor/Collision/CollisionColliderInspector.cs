using UnityEngine;
using UnityEditor;

// 可编辑多对象
[CanEditMultipleObjects]
// Inspector 对应的脚本,此脚本在序列化后可进行对象和属性的访问
// 通过 ScriptableObject 变量访问序列化后的对象
// 通过 target 访问挂载该脚本的 GameObject
[CustomEditor(typeof(CollisionCollider))]
public class CollisionColliderInspector : CollisionInspectorBase
{
    public override void OnInspectorGUI()
    {
        // 更新编辑器显示的序列化属性
        serializedObject.Update();

        GUILayout.Space(10);
        DrawTags();

        // 绘制 PropertyField 显示 collisionTime
        EditorGUILayout.PropertyField(serializedObject.FindProperty("collisionTime"));
        int index = serializedObject.FindProperty("collisionTime").intValue;

        // 如果是 OnCollisionStay
        if (index == 2)
            // 显示 frequency
            EditorGUILayout.PropertyField(serializedObject.FindProperty("frequency"));

        GUILayout.Space(10);
        DrawGameplayActions();
        DrawUnityEvents();

        if (GUI.changed)
            // 给序列化对象应用属性的修改,否则被序列化的对象(脚本)的属性并没有被修改
            serializedObject.ApplyModifiedProperties();
    }
}
