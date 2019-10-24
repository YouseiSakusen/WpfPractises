using PrismNetCoreApp.ExamManagements;
using PrismNetCoreApp.PhysicalManagements;

namespace PrismNetCoreApp
{
	public class PrismNetCoreAgent
	{
		public IPrismNetCoreData LoadData(string filePath)
		{
			if (string.IsNullOrEmpty(filePath))
				return this.createNewData();
			else
				return this.LoadFromFile(filePath);

		}

		private PrismNetCoreData createNewData()
		{
			var person = new PersonalInformation("新しい生徒");

			person.Physicals.Add(new PhysicalRecord());
			person.ExsamResults.Add(new ExamRecord());

			return new PrismNetCoreData(person);
		}

		private IPrismNetCoreData LoadFromFile(string filePath)
			=> new PrismNetCoreData();
	}
}
