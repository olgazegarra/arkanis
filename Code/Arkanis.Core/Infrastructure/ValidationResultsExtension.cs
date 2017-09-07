using Microsoft.Practices.EnterpriseLibrary.Validation;
using System;
using System.Text;

namespace Arkanis.Core.Infrastructure
{
    public static class ValidationResultsExtension
    {
		public static ApplicationException ToException(this ValidationResults Results)
		{
			StringBuilder sb = new StringBuilder();
			foreach (var item in Results)
			{
				sb.AppendLine(item.Message);
			}
			return new ApplicationException(sb.ToString());
		}
    }
}
