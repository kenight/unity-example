using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

public class InspectorBase : Editor
{
    // 绘制一个 ReorderableList，必须在继承类的 OnEnable 方法中调用，并在 OnInspectorGUI 中调用 DoLayoutList 进行绘制
    protected ReorderableList DrawReorderableList(string label, string propertyName)
    {
        ReorderableList list = new ReorderableList(serializedObject, serializedObject.FindProperty(propertyName), true, true, true, true);

        // 绘制列表元素
        list.drawElementCallback =
            (Rect rect, int index, bool isActive, bool isFocused) =>
            {
                SerializedProperty element = list.serializedProperty.GetArrayElementAtIndex(index);
                rect.y += 2;
                Rect r = new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight);
                EditorGUI.PropertyField(r, element, GUIContent.none, false);
            };

        // 绘制列表表头
        list.drawHeaderCallback = (Rect rect) =>
        {
            EditorGUI.LabelField(rect, label);
        };

        return list;
    }
}
