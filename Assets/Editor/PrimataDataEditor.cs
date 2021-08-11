using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PrimataData)), CanEditMultipleObjects]
public class PrimataDataEditor : Editor
{
    PrimataData t;

    SerializedObject targetSerializedObject;

    SerializedProperty primataName;

    private void OnEnable()
    {
        t = (PrimataData)target;

        targetSerializedObject = new SerializedObject(t);
        primataName = targetSerializedObject.FindProperty("nama");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        //targetSerializedObject.Update();

        if (GUILayout.Button("Uppercase"))
        {
            primataName.stringValue = primataName.stringValue.ToUpper();
        }

        Apply();
    }
    

    void Apply()
    {
        targetSerializedObject.ApplyModifiedProperties();
    }
}
