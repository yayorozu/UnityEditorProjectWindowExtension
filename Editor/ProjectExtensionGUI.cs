using UnityEditor;
using UnityEngine;

namespace Yorozu.EditorTools.Project
{
	internal class ProjectExtensionGUI
	{
		[InitializeOnLoadMethod]
		internal static void Register()
		{
			if (!ProjectExtensionMenu.IsValid)
				return;

			EditorApplication.projectWindowItemOnGUI -= ProjectWindowGUI;
			EditorApplication.projectWindowItemOnGUI += ProjectWindowGUI;
		}

		private const float OFFSET = 5f;
		private static Vector2 _cacheSize;
		private static GUIStyle _cacheStyle;
		private static readonly GUIContent _cacheContent = new GUIContent();

		private static void ProjectWindowGUI(string guid, Rect rect)
		{
			if (!ProjectExtensionMenu.IsValid)
			{
				EditorApplication.projectWindowItemOnGUI -= ProjectWindowGUI;
				return;
			}

			if (_cacheStyle == null)
				_cacheStyle = "AssetLabel";

			var path = AssetDatabase.GUIDToAssetPath(guid);
			var pos = rect.x + rect.width;

			foreach (var type in ProjectExtension.ValidTypes)
			{
				_cacheContent.text = type.Display(path);

				if (string.IsNullOrEmpty(_cacheContent.text))
					continue;

				_cacheSize = _cacheStyle.CalcSize(_cacheContent);

				rect.width = _cacheSize.x;
				rect.x = pos - _cacheSize.x;
				GUI.Label(rect, _cacheContent, _cacheStyle);

				pos -= _cacheSize.x + OFFSET;
			}
		}
	}
}
