using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BoardData)), CanEditMultipleObjects]
public class BoardDataEditor : Editor
{
    private BoardData t;
    private SerializedObject GetTarget;
    private SerializedProperty nameList;

    private void OnEnable()
    {
        t = (BoardData)target;
        GetTarget = new SerializedObject(t);
        nameList = GetTarget.FindProperty("data");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GetTarget.Update();

        if(nameList.arraySize > 1)
        {
            for (int i = 0; i < nameList.arraySize; i++)
            {
                SerializedProperty stringName = nameList.GetArrayElementAtIndex(i);
                Debug.Log(stringName.exposedReferenceValue);
                GetTarget.ApplyModifiedProperties();
            }
        }
    }
}
