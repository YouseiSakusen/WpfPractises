namespace WpfPrism72.CommonDialogs
{
	public abstract class DialogSettingsBase : ICommonDialogSettings
	{
		public string InitialDirectory { get; set; } = string.Empty;

		public string Title { get; set; } = string.Empty;
	}
}
