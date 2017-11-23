using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(InputEvent))]
public class InputEventInspector : EventInspectorBase
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        GUILayout.Space(10);
        EditorGUILayout.LabelField("Input", EditorStyles.boldLabel);

        // 绘制 inputMode 并修改 Label 为 Mode
        EditorGUILayout.PropertyField(serializedObject.FindProperty("inputMode"), new GUIContent("Mode"));
        int inputModeIndex = serializedObject.FindProperty("inputMode").intValue;

        // Joystick Mode
        if (inputModeIndex == 0)
            EditorGUILayout.PropertyField(serializedObject.FindProperty("buttonName"));

        // Keyboard Mode
        if (inputModeIndex == 1)
            EditorGUILayout.PropertyField(serializedObject.FindProperty("key"));

        // Mouse Mode
        if (inputModeIndex == 2)
            EditorGUILayout.PropertyField(serializedObject.FindProperty("mouseTypes"));

        EditorGUILayout.PropertyField(serializedObject.FindProperty("eventType"));

        // 间隔设置
        DrawInterval();

        GUILayout.Space(10);
        DrawAnimation();

        GUILayout.Space(10);
        DrawGameplayActions();
        DrawUnityEvents();

        if (GUI.changed)
            serializedObject.ApplyModifiedProperties();
    }
}
