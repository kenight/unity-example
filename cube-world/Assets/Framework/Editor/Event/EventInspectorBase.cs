using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

public class EventInspectorBase : InspectorBase
{
    protected ReorderableList gameplayActionList;

    protected void OnEnable()
    {
        gameplayActionList = DrawReorderableList("Gameplay Actions", "gameplayActions");
    }

    protected void DrawGameplayActions()
    {
        EditorGUILayout.LabelField("Actions", EditorStyles.boldLabel);
        GUILayout.Space(5);

        EditorGUILayout.PropertyField(serializedObject.FindProperty("onlyOnce"));
        gameplayActionList.DoLayoutList();
    }

    protected void DrawUnityEvents()
    {
        bool defaultValue = serializedObject.FindProperty("useUnityEvent").boolValue;
        bool enable = EditorGUILayout.Toggle("Use Unity Events", defaultValue);
        if (enable)
            EditorGUILayout.PropertyField(serializedObject.FindProperty("unityEvents"));
        serializedObject.FindProperty("useUnityEvent").boolValue = enable;
    }

    protected void DrawAnimation()
    {
        EditorGUILayout.LabelField("Animation", EditorStyles.boldLabel);
        GUILayout.Space(5);

        bool defaultValue = serializedObject.FindProperty("useAnimation").boolValue;
        bool enable = EditorGUILayout.Toggle("Use Animation", defaultValue);
        if (enable)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("parameterTypes"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("parameterName"));
        }
        serializedObject.FindProperty("useAnimation").boolValue = enable;
    }

    protected void DrawInterval()
    {
        bool defaultValue = serializedObject.FindProperty("hasInterval").boolValue;
        bool enable = EditorGUILayout.Toggle("Interval", defaultValue);
        if (enable)
            EditorGUILayout.PropertyField(serializedObject.FindProperty("frequency"));
        serializedObject.FindProperty("hasInterval").boolValue = enable;
    }
}
