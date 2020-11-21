using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using EncryptionGame.Classes.Common;

namespace EncryptionGame.Classes
{
	class CaesarCipher
	{
		private string plainText;
		private string cipherText;
		private int encryptionOrDecryptionKey;
		private AlphabetValue alphabeticValueObject;
		private StringWhiteSpace stringWhiteSpace;
		private List<int> alphabeticValueList = new List<int>();
		private List<int> keyAddedAlphabeticValueList = new List<int>();
		private double dividedValue;
		private int newValue;

		public CaesarCipher(AlphabetValue alphabetValueObject, StringWhiteSpace stringWhiteSpaceObject)
		{
			this.stringWhiteSpace = stringWhiteSpaceObject;
			this.alphabeticValueObject = alphabetValueObject;
			this.alphabeticValueObject.setAlphabeticValueForNumerics();
			this.alphabeticValueObject.setNumericValueForAlphabets();
		}



		//public void displayAlphabeticValuesOfnumerics()
		//{
		//	ICollection key = numericValueHashTable.Keys;

		//	foreach (int k in key)
		//	{
		//		Console.WriteLine(k + ": " + numericValueHashTable[k]);
		//	}
		//	Console.ReadKey();
		//}

		//public void displayNumericValuesOfAlphabets()
		//{
		//	ICollection key = alphabeticValueHashTable.Keys;

		//	foreach (char k in key)
		//	{
		//		Console.WriteLine(k + ": " + alphabeticValueHashTable[k]);
		//	}
		//	Console.ReadKey();
		//}

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

		public void setEncryptionDecryptionKey(int key)
		{
			this.encryptionOrDecryptionKey = key;
		}

		public int getEncryptionDecryptionKey()
		{
			return this.encryptionOrDecryptionKey;
		}



		public void encryptPlainText()
		{
			//Console.WriteLine(this.getPlainText());

			//this.cipherText = null;
			this.setPlainText(this.getPlainText().ToUpper());
			this.stringWhiteSpace.extractWhiteSpaceIndexFromText(this.getPlainText());
			this.setPlainText(this.stringWhiteSpace.extractWhiteSpacesFromText(this.getPlainText()));
			this.addPlainOrCipherTextAlphabetValues(this.getPlainText());
			this.calculatePlainTextAlphabetValuesAfterAddingKeyValue();
			this.setCipherText(this.createPlainOrCipherText());
			this.setCipherText(this.stringWhiteSpace.addWhiteSpacesAfterEncryptingOrDecryptingText(this.getCipherText()));
			this.clearAllUsedListInEncryptionOrDecryption();
			//ArrayList encryptedText = new ArrayList();

			//Console.WriteLine(encryptedText);


			//Console.WriteLine(this.getCipherText());

		}

		public void decryptCipherText()
		{
			//this.plainText = null;
			this.setCipherText(this.getCipherText().ToUpper());
			this.stringWhiteSpace.extractWhiteSpaceIndexFromText(this.getCipherText());
			this.setCipherText(this.stringWhiteSpace.extractWhiteSpacesFromText(this.getCipherText()));
			this.addPlainOrCipherTextAlphabetValues(this.getCipherText());
			this.calculateCipherTextAlphabetValuesAfterAddingKeyValue();
			this.setPlainText(this.createPlainOrCipherText());
			this.setPlainText(this.stringWhiteSpace.addWhiteSpacesAfterEncryptingOrDecryptingText(this.getPlainText()));
			this.clearAllUsedListInEncryptionOrDecryption();

			//ArrayList encryptedText = new ArrayList();

			//Console.WriteLine(encryptedText);


			//Console.WriteLine(this.getPlainText());

		}

		//public string convertTextIntoUpperCase(string cipherOrPLainText)
		//{
		//	cipherOrPLainText = cipherOrPLainText.ToUpper();
		//	return cipherOrPLainText;
		//}



		public void addPlainOrCipherTextAlphabetValues(string plainOrCipherText)
		{
			for (int i = 0; i < plainOrCipherText.Length; i++)
			{
				this.alphabeticValueList.Add(this.alphabeticValueObject.getNumericValueForSpecificAlphabet(plainOrCipherText[i]));
			}
		}

		public void calculatePlainTextAlphabetValuesAfterAddingKeyValue()
		{
			foreach (var number in this.alphabeticValueList)
			{
				this.newValue = number + this.getEncryptionDecryptionKey();
				if (this.newValue > 26)
				{
					this.dividedValue = this.newValue / 26.0;
					//Console.WriteLine("Divided Value: " + dividedValue);
					this.dividedValue = (this.dividedValue - Math.Floor(this.dividedValue)) * 26;
					//Console.WriteLine("new Value: " + dividedValue);
					if (this.dividedValue > 0.5)
					{
						this.newValue = (int)(Math.Round(this.dividedValue));
						//Console.WriteLine("new Value: " + newValue);
					}
					else
					{
						this.newValue = (int)(Math.Floor(this.dividedValue));
						//Console.WriteLine("new Value: " + newValue);
					}
					this.keyAddedAlphabeticValueList.Add(this.newValue);

				}
				else
				{
					this.keyAddedAlphabeticValueList.Add(this.newValue);
				}

			}
		}
		public void calculateCipherTextAlphabetValuesAfterAddingKeyValue()
		{
			foreach (var number in this.alphabeticValueList)
			{
				this.newValue = number - this.getEncryptionDecryptionKey();
				//Console.WriteLine($"New Value {newValue}");
				if (this.newValue < 0)
				{
					do
					{
						this.newValue += 26;
					} while (this.newValue < 0);
					this.keyAddedAlphabeticValueList.Add(this.newValue);

				}
				else
				{
					this.keyAddedAlphabeticValueList.Add(this.newValue);
				}

			}
		}

		public string createPlainOrCipherText()
		{
			string createdText = "";
			foreach (var newNumber in this.keyAddedAlphabeticValueList)
			{
				//encryptedText.Add();
				createdText += this.alphabeticValueObject.getAlphabeticValueForSpecificNumber(newNumber);
			}
			return createdText;
		}



		public void clearAllUsedListInEncryptionOrDecryption()
		{
			this.alphabeticValueList.Clear();
			this.keyAddedAlphabeticValueList.Clear();
			this.stringWhiteSpace.clearWhiteSpaceList();
		}
	}
}