using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

public class CollisionInspectorBase : InspectorBase
{
    protected ReorderableList gameplayActionList;
    protected string chosenTag;


    protected void OnEnable()
    {
        gameplayActionList = DrawReorderableList("Gameplay Actions", "gameplayActions");
    }

    protected void DrawGameplayActions()
    {
        // 标题
        EditorGUILayout.LabelField("Actions", EditorStyles.boldLabel);

        GUILayout.Space(5);

        // 绘制属性 onlyOnce
        // 用 EditorGUILayout.PropertyField 绘制无需给属性再赋值 Toggle、TagField 等需赋值，注意 Toggle 等只是获取的默认值
        EditorGUILayout.PropertyField(serializedObject.FindProperty("onlyOnce"));

        // 绘制 ReorderableList
        gameplayActionList.DoLayoutList();
    }

    protected void DrawUnityEvents()
    {
        // 获取 useUnityEvent 属性的默认值
        bool defaultValue = serializedObject.FindProperty("useUnityEvent").boolValue;

        // 根据默认值绘制一个 Toggle
        bool enable = EditorGUILayout.Toggle("Use Unity Events", defaultValue);

        // 如果已勾选
        if (enable)
            // 则绘制 unityEvents 属性(绘制类型为 PropertyField)
            EditorGUILayout.PropertyField(serializedObject.FindProperty("unityEvents"));

        // 为序列化对象对应的属性重新赋值
        serializedObject.FindProperty("useUnityEvent").boolValue = enable;
    }

    protected void DrawTags()
    {
        // 标题
        EditorGUILayout.LabelField("Settings", EditorStyles.boldLabel);

        GUILayout.Space(5);

        // 获取 enableCompare 属性的默认值
        bool defaultValue = serializedObject.FindProperty("enableCompare").boolValue;

        // 获取 compareFor 的默认值
        chosenTag = serializedObject.FindProperty("compareFor").stringValue;

        // 根据默认值绘制一个 Toggle
        bool enable = EditorGUILayout.Toggle("Enable Compare", defaultValue);

        if (enable)
            chosenTag = EditorGUILayout.TagField("Compare For", chosenTag);

        // 为序列化对象对应的属性重新赋值
        serializedObject.FindProperty("enableCompare").boolValue = enable;
    }
}
