namespace Prism.Services.Dialogs.Extensions
{
	public static class IDialogServiceExtensions
	{
		public static IDialogResult ShowDialog(this IDialogService dlgService, string dialogViewName)
		{
			return IDialogServiceExtensions.ShowDialog(dlgService, dialogViewName, null);
		}

		public static IDialogResult ShowDialog(this IDialogService dlgService, string dialogViewName, IDialogParameters parameters)
		{
			IDialogResult ret = null;

			dlgService.ShowDialog(dialogViewName, parameters, r => ret = r);

			return ret;
		}
	}
}
