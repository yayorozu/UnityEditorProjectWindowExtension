using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;

namespace Yorozu.EditorTools.Project
{
	internal class ProjectExtension
	{
		private const string SAVE_KEY = "ProjectWindowExtension:Types";
		private const char SEPARATE = ':';

		private static ProjectGUIModule[] _cacheTypes;
		internal static IEnumerable<ProjectGUIModule> TargetTypes =>
			_cacheTypes ?? (_cacheTypes = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(a => a.GetTypes())
				.Where(t => !t.IsAbstract && t.IsSubclassOf(typeof(ProjectGUIModule)))
				.Select(t => Activator.CreateInstance(t) as ProjectGUIModule)
				.ToArray());

		internal static IEnumerable<ProjectGUIModule> ValidTypes => TargetTypes.Where(t => IsValid(t.GetType()));

		private static string[] _cacheValidTypes;
		private static string[] _validTypes => _cacheValidTypes ?? (_cacheValidTypes = EditorPrefs.GetString(SAVE_KEY).Split(SEPARATE));

		internal static bool IsValid(Type type)
		{
			return _validTypes.Contains(type.Name);
		}

		internal static void Update(Type type, bool isSave)
		{
			if (IsValid(type) && isSave || !IsValid(type) && !isSave)
				return;

			var array = _validTypes;
			if (isSave)
				ArrayUtility.Add(ref array, type.Name);
			else
				ArrayUtility.Remove(ref array, type.Name);

			EditorPrefs.SetString(SAVE_KEY, string.Join(SEPARATE.ToString(), array));
			_cacheValidTypes = array;
		}
	}
}
