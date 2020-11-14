using UnityEditor;
using UnityEngine;

namespace Yorozu.EditorTools.Project
{
	public class ProjectGUIModuleScriptableObjectName : ProjectGUIModule
	{
		public override string Display(string path)
		{
			var obj = AssetDatabase.LoadAssetAtPath<ScriptableObject>(path);

			if (obj == null)
				return string.Empty;

			return obj.GetType().Name;
		}

		public override string DisplayName()
		{
			return "ScriptableObjectName";
		}
	}
}
