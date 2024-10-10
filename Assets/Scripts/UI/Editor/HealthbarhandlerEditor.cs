using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
#if UNITY_EDITOR
[CustomEditor(typeof(HealthBarhandler))]
public class HealthbarhandlerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        HealthBarhandler _var = (HealthBarhandler)target;
        if(GUILayout.Button("Test damage"))
        {
            _var.TestDamage();
        }
        if(GUILayout.Button("Regen health"))
        {
            _var.TestRegen();
        }
    }
}
#endif