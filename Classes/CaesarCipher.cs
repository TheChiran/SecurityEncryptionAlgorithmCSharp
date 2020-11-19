using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace EncryptionGame.Classes
{
	class CaesarCipher
	{
		private string plainText;
		private string cipherText;
		private Hashtable numericValueHashTable = new Hashtable();
		private Hashtable alphabeticValueHashTable = new Hashtable();
		private List<int> whiteSpaceList = new List<int>();
		private char alphabet;
		private int alphabetIndex;
		private int encryptionOrDecryptionKey;

		public void setAlphabeticValueForNumerics()
		{
			
			this.alphabetIndex = 1;
			for (this.alphabet = 'A'; this.alphabet <= 'Z'; this.alphabet++)
			{
				this.alphabeticValueHashTable.Add(this.alphabetIndex, this.alphabet);
				this.alphabetIndex++;
			}
		}

		public void setNumericValueForAlphabets()
		{
			
			this.alphabetIndex = 1;
			for (this.alphabet = 'A'; this.alphabet <= 'Z'; this.alphabet++)
			{
				this.numericValueHashTable.Add(this.alphabet, this.alphabetIndex);
				this.alphabetIndex++;
			}
		}

		public void setEncryptionDecryptionKey(int key)
		{
			this.encryptionOrDecryptionKey = key;
		}

		public int getEncryptionDecryptionKey()
		{
			return this.encryptionOrDecryptionKey;
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

		public int getNumericValueForSpecificAlphabet(char alphabet)
		{
			int result = Convert.ToInt32(this.numericValueHashTable[alphabet]);
			return result;
		}

		public char getAlphabeticValueForSpecificNumber(int numericValue)
		{
			if(numericValue == 0)
			{
				return 'Z';
			}
			else
			{
				char alphabeticValue = Convert.ToChar(this.alphabeticValueHashTable[numericValue]);
				return alphabeticValue;
			}
		}

		public void extractWhiteSpaceIndex(string text)
		{
			Boolean result;
			for (int i = 0; i < text.Length; i++)
			{
				result = Char.IsWhiteSpace(text[i]);
				if (result)
					this.whiteSpaceList.Add(i);

			}

		}

		public void setPlainText(string text)
		{
			text = text.ToUpper();
			this.extractWhiteSpaceIndex(text);
			this.plainText = text.Replace(" ",string.Empty);
		}

		public string getPlainText()
		{
			return this.plainText;
		}

		public void setCipherText(string text)
		{
			text = text.ToUpper();
			this.extractWhiteSpaceIndex(text);
			this.cipherText = text.Replace(" ", string.Empty);
		}

		public string getCipherText()
		{
			return this.cipherText;
		}

		public void encryptPlainText()
		{
			//Console.WriteLine(this.getPlainText());
			List<int> alphabeticValueList = new List<int>();
			this.cipherText = "";
			for(int i = 0; i < this.getPlainText().Length; i++)
			{
				//Console.WriteLine(getNumericValueForSpecificAlphabet(this.plainText[i]));
				alphabeticValueList.Add(this.getNumericValueForSpecificAlphabet(this.plainText[i]));
			}
			List<int> keyAddedAlphabeticValueList = new List<int>();
			double dividedValue;
			int newValue;
			foreach(var number in alphabeticValueList)
			{
				newValue = number + this.getEncryptionDecryptionKey();
				if (newValue > 26)
				{
					dividedValue = newValue / 26.0;
					//Console.WriteLine("Divided Value: " + dividedValue);
					dividedValue = (dividedValue - Math.Floor(dividedValue)) * 26;
					//Console.WriteLine("new Value: " + dividedValue);
					if (dividedValue > 0.5)
					{
						newValue = (int)(Math.Round(dividedValue));
						//Console.WriteLine("new Value: " + newValue);
					}
					else
					{
						newValue = (int)(Math.Floor(dividedValue));
						//Console.WriteLine("new Value: " + newValue);
					}
					keyAddedAlphabeticValueList.Add(newValue);

				}
				else
				{
					keyAddedAlphabeticValueList.Add(newValue);
				}
				
			}
			
			//ArrayList encryptedText = new ArrayList();
			foreach (var newNumber in keyAddedAlphabeticValueList)
			{
				//encryptedText.Add();
				this.cipherText+=this.getAlphabeticValueForSpecificNumber(newNumber);
			}
			//Console.WriteLine(encryptedText);
			
			foreach(int index in this.whiteSpaceList)
			{
				this.cipherText = this.cipherText.Insert(index, " ");
			}
			Console.WriteLine(this.getCipherText());

		}

		public void decryptCipherText()
		{
			//Console.WriteLine(this.getPlainText());
			this.plainText = "";
			List<int> alphabeticValueList = new List<int>();
			for (int i = 0; i < this.getCipherText().Length; i++)
			{
				//Console.WriteLine(getNumericValueForSpecificAlphabet(this.plainText[i]));
				alphabeticValueList.Add(this.getNumericValueForSpecificAlphabet(this.cipherText[i]));
			}
			List<int> keyAddedAlphabeticValueList = new List<int>();
			
			int newValue;
			foreach (var number in alphabeticValueList)
			{
				newValue = number - this.getEncryptionDecryptionKey();
				//Console.WriteLine($"New Value {newValue}");
				if (newValue < 0)
				{
					do
					{
						newValue += 26;
					} while (newValue<0);
					keyAddedAlphabeticValueList.Add(newValue);

				}
				else
				{
					keyAddedAlphabeticValueList.Add(newValue);
				}

			}

			//ArrayList encryptedText = new ArrayList();
			foreach (var newNumber in keyAddedAlphabeticValueList)
			{
				//encryptedText.Add();
				this.plainText += this.getAlphabeticValueForSpecificNumber(newNumber);
			}
			//Console.WriteLine(encryptedText);

			foreach (int index in this.whiteSpaceList)
			{
				this.plainText = this.plainText.Insert(index, " ");
			}
			Console.WriteLine(this.getPlainText());

		}
	}
}
