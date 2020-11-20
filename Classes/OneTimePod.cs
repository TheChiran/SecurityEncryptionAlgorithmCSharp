using System;
using System.Collections.Generic;
using System.Text;
using EncryptionGame.Classes.Common;

namespace EncryptionGame.Classes
{
	class OneTimePod
	{
		private AlphabetValue alphabeticValueObject;
		private StringWhiteSpace stringWhiteSpaceObject;
		private List<int> plainOrCipherTextAlphabetValues = new List<int>();
		private List<int> keyTextAlphabetValues = new List<int>();
		private String encryptionDecryptionKey;
		private string plainText;
		private string cipherText;


		public OneTimePod(alphabeticValueObj, stringWhiteSpaceObject)
		{
			this.alphabeticValueObject = alphabeticValueObject;
			this.alphabeticValueObject.setAlphabeticValueForNumerics();
			this.alphabeticValueObject.setNumericValueForAlphabets();
			this.stringWhiteSpaceObject = stringWhiteSpaceObject;
		}

		public void setPlainText(string text)
		{
			this.plainText = text;
		}
		public string getPlainText()
		{
			return this.plainText;
		}
		public void setCipherText(string text)
		{
			this.cipherText = text;
		}

		public string getCipherText()
		{
			return this.cipherText;
		}

		public void setEncryptionDecryptionKey(string key)
		{
			this.encryptionDecryptionKey = key;
		}
		public string getEncryptionDecryptionKey()
		{
			return this.encryptionDecryptionKey;
		}

		public void encryptPlainText()
		{
			this.setPlainText(this.getPlainText().ToUpper());
			this.stringWhiteSpaceObject.extractWhiteSpaceIndexFromText(this.getPlainText());
			this.setPlainText(this.stringWhiteSpaceObject.extractWhiteSpacesFromText(this.getPlainText()));
			this.checkIfPlainOrCipherTextAndKeyStringHaveSameLengthOrNot();
		}
		public void checkIfPlainOrCipherTextAndKeyStringHaveSameLengthOrNot()
		{

		}

	}
}
