using System;
using System.Collections.Generic;

namespace DacsOnline.Model.RepostioriesInterfaces
{
	public interface IDocumentRepository
	{
		List<string> GetDocumentsInformation();
	}
}