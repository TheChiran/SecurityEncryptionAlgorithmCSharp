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
		private List<int> plainOrCipherTextAlphabetValuesList = new List<int>();
		private List<int> keyTextAlphabetValuesList = new List<int>();
		private List<int> combinedListOfKeyStringAndPlainOrCipherTextValuesList = new List<int>();
		private List<int> finalAlphabetValueList = new List<int>();
		private String encryptionDecryptionKey;
		private string plainText;
		private string cipherText;
		private int newNumericValueAfterAddingOrSubtractingPlainCipherAndKeyString;

		public OneTimePod(AlphabetValue alphabetic_value_object, StringWhiteSpace string_white_space_object)
		{
			this.alphabeticValueObject = alphabetic_value_object;
			this.alphabeticValueObject.setAlphabeticValueForNumerics();
			this.alphabeticValueObject.setNumericValueForAlphabets();
			this.stringWhiteSpaceObject = string_white_space_object;
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
			this.checkIfPlainOrCipherTextAndKeyStringHaveSameLengthOrNot(this.getPlainText());
			this.extractPlainOrCipherTextAlphabetValues(this.getPlainText());
			this.extractKeyStringAlphabetValues(this.getEncryptionDecryptionKey());
			this.combinePlainOrCipherTextValuesWithKeyStringValues(this.getPlainText(),this.getEncryptionDecryptionKey());
			this.setCipherText(this.createPlainOrCipherText());
			this.setCipherText(this.stringWhiteSpaceObject.addWhiteSpacesAfterEncryptingOrDecryptingText(this.getCipherText()));
			this.clearAllUsedList();
		}

		public void decryptCipherText()
		{
			this.setCipherText(this.getCipherText().ToUpper());
			this.stringWhiteSpaceObject.extractWhiteSpaceIndexFromText(this.getCipherText());
			this.setCipherText(this.stringWhiteSpaceObject.extractWhiteSpacesFromText(this.getCipherText()));
			this.checkIfPlainOrCipherTextAndKeyStringHaveSameLengthOrNot(this.getCipherText());
			this.extractPlainOrCipherTextAlphabetValues(this.getCipherText());
			this.extractKeyStringAlphabetValues(this.getEncryptionDecryptionKey());
			this.substractKeyStringValuesFromPlainOrCipherTextValues(this.getCipherText(), this.getEncryptionDecryptionKey());
			this.setPlainText(this.createPlainOrCipherText());
			this.setPlainText(this.stringWhiteSpaceObject.addWhiteSpacesAfterEncryptingOrDecryptingText(this.getPlainText()));
			this.clearAllUsedList();
		}

		public void substractKeyStringValuesFromPlainOrCipherTextValues(string plainOrCipherText, string keyString)
		{
			for (int i = 0; i < this.getCipherText().Length; i++)
			{
				this.newNumericValueAfterAddingOrSubtractingPlainCipherAndKeyString =
					this.alphabeticValueObject.getNumericValueForSpecificAlphabet(plainOrCipherText[i]) -
					this.alphabeticValueObject.getNumericValueForSpecificAlphabet(keyString[i]);
				if (this.newNumericValueAfterAddingOrSubtractingPlainCipherAndKeyString < 0)
				{
					do
					{
						this.newNumericValueAfterAddingOrSubtractingPlainCipherAndKeyString += 26;
					} while (this.newNumericValueAfterAddingOrSubtractingPlainCipherAndKeyString < 0);

					this.finalAlphabetValueList.Add(this.newNumericValueAfterAddingOrSubtractingPlainCipherAndKeyString);

				}
				else
				{
					this.finalAlphabetValueList.Add(this.newNumericValueAfterAddingOrSubtractingPlainCipherAndKeyString);
				}
			}
		}

		public void combinePlainOrCipherTextValuesWithKeyStringValues(string plainOrCipherText, string keyString)
		{
			double dividedValue;

			for (int i = 0; i < this.getPlainText().Length; i++)
			{
				this.newNumericValueAfterAddingOrSubtractingPlainCipherAndKeyString =
					this.alphabeticValueObject.getNumericValueForSpecificAlphabet(plainOrCipherText[i]) +
					this.alphabeticValueObject.getNumericValueForSpecificAlphabet(keyString[i]);
				if (this.newNumericValueAfterAddingOrSubtractingPlainCipherAndKeyString > 26)
				{
					dividedValue = this.newNumericValueAfterAddingOrSubtractingPlainCipherAndKeyString / 26.0;
					//Console.WriteLine("Divided Value: " + dividedValue);
					dividedValue = (dividedValue - Math.Floor(dividedValue)) * 26;
					//Console.WriteLine("new Value: " + dividedValue);
					if (dividedValue > 0.5)
					{
						this.newNumericValueAfterAddingOrSubtractingPlainCipherAndKeyString = (int)(Math.Round(dividedValue));
						//Console.WriteLine("new Value: " + newValue);
					}
					else
					{
						this.newNumericValueAfterAddingOrSubtractingPlainCipherAndKeyString = (int)(Math.Floor(dividedValue));
						//Console.WriteLine("new Value: " + newValue);
					}
					this.finalAlphabetValueList.Add(this.newNumericValueAfterAddingOrSubtractingPlainCipherAndKeyString);

				}
				else
				{
					this.finalAlphabetValueList.Add(this.newNumericValueAfterAddingOrSubtractingPlainCipherAndKeyString);
				}
			}
		}

		
		public string createPlainOrCipherText()
		{
			string finalSting = "";
			foreach(var number in this.finalAlphabetValueList)
			{
				finalSting += this.alphabeticValueObject.getAlphabeticValueForSpecificNumber(number);
			}
			return finalSting;
		}
		

		public void extractPlainOrCipherTextAlphabetValues(string plainOrCipherText)
		{
			for(int i = 0; i < plainOrCipherText.Length; i++)
			{
				this.plainOrCipherTextAlphabetValuesList.Add(this.alphabeticValueObject.getNumericValueForSpecificAlphabet(plainOrCipherText[i]));
			}
		}

		public void extractKeyStringAlphabetValues(string keyString)
		{
			for(int i = 0; i < keyString.Length; i++)
			{
				this.keyTextAlphabetValuesList.Add(this.alphabeticValueObject.getNumericValueForSpecificAlphabet(keyString[i]));
			}
		}

		public void checkIfPlainOrCipherTextAndKeyStringHaveSameLengthOrNot(string text)
		{
			if(text.Length != this.getEncryptionDecryptionKey().Length)
			{
				this.updateEncryptionDecryptionKeyString();
			}
		}

		public void updateEncryptionDecryptionKeyString()
		{
			int presentIndexOfKeyString = 0;
			int originalKeyStringLastIndex = this.getEncryptionDecryptionKey().Length - 1;
			//Console.WriteLine(originalKeyStringLastIndex);
			int plainTextLastIndex = this.getPlainText().Length - 1;
			
			for(int i = originalKeyStringLastIndex; i < plainTextLastIndex; i++)
			{
				if (presentIndexOfKeyString > originalKeyStringLastIndex)
				{
					presentIndexOfKeyString = 0;
				}
				//Console.WriteLine($"Present Index: {presentIndexOfKeyString}");
				//Console.WriteLine($"Present Character: {this.encryptionDecryptionKey[presentIndexOfKeyString]}");
				this.encryptionDecryptionKey += this.encryptionDecryptionKey[presentIndexOfKeyString];
				presentIndexOfKeyString++;
			}
			//this.setEncryptionDecryptionKey(newKey);
			//Console.WriteLine(this.getEncryptionDecryptionKey());

		}

		public void clearAllUsedList()
		{
			this.plainOrCipherTextAlphabetValuesList.Clear();
			this.keyTextAlphabetValuesList.Clear();
			this.combinedListOfKeyStringAndPlainOrCipherTextValuesList.Clear();
			this.finalAlphabetValueList.Clear();
			this.stringWhiteSpaceObject.clearWhiteSpaceList();
		}

	}
}
