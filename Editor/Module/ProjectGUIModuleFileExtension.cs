namespace Yorozu.EditorTools.Project
{
	/// <summary>
	/// ファイルの拡張子
	/// </summary>
	public class ProjectGUIModuleFileExtension : ProjectGUIModule
	{
		public override string Display(string path)
		{
			return System.IO.Path.GetExtension(path);
		}

		public override string PreferenceName()
		{
			return "FileExtension";
		}
	}
}
