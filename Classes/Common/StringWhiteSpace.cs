using System;
using System.Collections.Generic;
using System.Text;

namespace EncryptionGame.Classes.Common
{
	class StringWhiteSpace
	{
		private List<int> whiteSpaceList = new List<int>();

		public void extractWhiteSpaceIndexFromText(string text)
		{
			Boolean result;
			for (int i = 0; i < text.Length; i++)
			{
				result = Char.IsWhiteSpace(text[i]);
				if (result)
					this.whiteSpaceList.Add(i);

			}

		}
		public string extractWhiteSpacesFromText(string cipherOrPlainText)
		{
			cipherOrPlainText = cipherOrPlainText.Replace(" ", string.Empty);
			return cipherOrPlainText;

		}
		public string addWhiteSpacesAfterEncryptingOrDecryptingText(string text)
		{
			foreach (int index in this.whiteSpaceList)
			{
				text = text.Insert(index, " ");
			}
			return text;
		}
		public void clearWhiteSpaceList()
		{
			this.whiteSpaceList.Clear();
		}

	}
}
