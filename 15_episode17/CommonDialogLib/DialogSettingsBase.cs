namespace WpfPrism72.CommonDialogs
{
	public abstract class DialogSettingsBase : IDialogSettings
	{
		public string InitialDirectory { get; set; } = string.Empty;

		public string Title { get; set; } = string.Empty;
	}
}
