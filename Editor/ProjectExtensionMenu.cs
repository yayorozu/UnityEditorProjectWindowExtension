using UnityEditor;

namespace Yorozu.EditorTools.Project
{
	internal class ProjectExtensionMenu
	{
		private const string MENU_PATH = "Tools/ProjectWindowExtension";
		internal const string VALID_SAVE_KEY = "ProjectWindowExtension";

		internal static bool IsValid => EditorPrefs.GetBool(VALID_SAVE_KEY, false);

		[MenuItem(MENU_PATH)]
		private static void MenuToggle()
		{
			EditorPrefs.SetBool(VALID_SAVE_KEY, !IsValid);
		}

		[MenuItem(MENU_PATH, true)]
		private static bool MenuToggleValidate()
		{
			Menu.SetChecked(MENU_PATH, IsValid);

			return true;
		}
	}
}
