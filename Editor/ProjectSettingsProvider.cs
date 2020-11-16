using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Yorozu.EditorTools.Project
{
	internal class ProjectSettingsProvider : SettingsProvider
	{
		private ProjectSettingsProvider(string path, SettingsScope scopes, IEnumerable<string> keywords = null) : base(path, scopes, keywords) { }

		[SettingsProvider]
		public static SettingsProvider RegisterUser()
		{
			return new ProjectSettingsProvider("Tools/", SettingsScope.User, new []{"Project"})
			{
				label = "ProjectWindowExtension",
			};
		}

		public override void OnGUI(string searchContext)
		{
			EditorGUIUtility.labelWidth = 250f;
			using (var check = new EditorGUI.ChangeCheckScope())
			{
				var isValid = EditorGUILayout.Toggle("ProjectWindow Enable", ProjectExtensionMenu.IsValid);
				if (check.changed)
				{
					EditorPrefs.SetBool(ProjectExtensionMenu.VALID_SAVE_KEY, isValid);
					ProjectExtensionGUI.Register();
				}
			}

			EditorGUILayout.Space();
			EditorGUILayout.LabelField("Modules", EditorStyles.boldLabel);

			using (new EditorGUI.DisabledScope(!ProjectExtensionMenu.IsValid))
			{
				foreach (var type in ProjectExtension.TargetTypes)
				{
					using (var check = new EditorGUI.ChangeCheckScope())
					{
						var isValid = EditorGUILayout.Toggle(type.PreferenceName(), ProjectExtension.IsValid(type.GetType()));
						if (check.changed)
						{
							ProjectExtension.Update(type.GetType(), isValid);
						}
					}
				}
			}
		}
	}
}
