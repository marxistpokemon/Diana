using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(WorldManager))]
public class WorldManagerEditor : Editor {

	public override void OnInspectorGUI() {
		DrawDefaultInspector();

		/*
		if(GUILayout.Button("Load from XML")) {
			(target as WorldManager).LoadFromXML();
        }

		if((target as WorldManager).container != null){
			if(GUILayout.Button("Populate container from Scene")){
			}
			GUILayout.Space(20);
			if(GUILayout.Button("Write to XML")){
				(target as WorldManager).WriteToXML();
			}
		}
		*/
	}
}

