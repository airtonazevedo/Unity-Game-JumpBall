#if UNITY_EDITOR

using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(TrilhoNovo))]
public class ObjectBuilderEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		
		TrilhoNovo myScript = (TrilhoNovo)target;
		if(GUILayout.Button("CriarPonto"))
		{
			myScript.AddPonto();
		}
	}
    void Start()
    {
        Debug.Log("xxx");
    }
}

#endif