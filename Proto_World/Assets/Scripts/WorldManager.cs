using UnityEditor;
using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class WorldManager : MonoBehaviour
{
	[HideInInspector] public static WorldManager w;
	public TextAsset worldObjectsFile;
	public WorldObjectContainer container;

	public void Awake(){
		w = this;
	}

	#region XML Serialization
	public bool LoadFromXML(){
		container = WorldObjectContainer.LoadFromText(worldObjectsFile.text);
		return (container != null);
	}

	public void PopulateFromScene(){
		// TODO find out how to make this
		// Object[] allWO = FindObjectsOfType<WorldObject>();
	}

	public void WriteToXML(){
		container.Save(AssetDatabase.GetAssetPath(worldObjectsFile));
	
	}

	#endregion
}

