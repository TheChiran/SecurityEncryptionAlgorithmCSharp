using System;
using System.Collections.Generic;
using System.Text;
using EncryptionGame.Classes.Common;
using System.Collections;

namespace EncryptionGame.Classes
{
	class Transposition
	{
		private StringWhiteSpace stringWhiteSpaceObject;
		private string plainText;
		private string cipherText;
		private string keyStirng;
		private float totalLengthOfPlainText;
		private List<KeyValuePair<char,char>> plainOrCipherTextkeyValueList = new List<KeyValuePair<char,char>>();
		private ArrayList newKeyStringList = new ArrayList();
		public Transposition(StringWhiteSpace stringWhiteSpaceObj)
		{
			this.stringWhiteSpaceObject = stringWhiteSpaceObj;
		}

		public void setPlainText(string plainText)
		{
			this.plainText = plainText;
		}

		public string getPlainText()
		{
			return this.plainText;
		}

		public void setCipherText(string cipherText)
		{
			this.cipherText = cipherText;
		}

		public string getCipherText()
		{
			return this.cipherText;
		}

		public void setEncryptionDecryptionKey(string keyString)
		{
			this.keyStirng = keyString;
		}

		public string getEncryptionDecryptionKey()
		{
			return this.keyStirng;
		}

		public void encryptPlainText()
		{
			this.stringWhiteSpaceObject.extractWhiteSpaceIndexFromText(this.getPlainText());
			this.setPlainText(this.stringWhiteSpaceObject.extractWhiteSpacesFromText(this.getPlainText()));
			this.setPlainText(this.checkIfThereIsAnySpaceLeftToBeFilled(this.getPlainText()));
			this.insertPlainOrCipherTextWithValues(this.getPlainText());
			//this.displayKeyValuePair();
			this.sortKeyString();
		}

		public string checkIfThereIsAnySpaceLeftToBeFilled(string plainOrCipherText)
		{
			float encryptionDecryptionKeyLength = this.getEncryptionDecryptionKey().Length;
			//Console.WriteLine($"Encryption length: {encryptionDecryptionKeyLength}");
			//Console.WriteLine($"Plain Text length: {plainOrCipherText.Length}");
			//this.totalLengthOfPlainText = (int)Math.Round(plainOrCipherText.Length / ((float)encryptionDecryptionKeyLength));
			this.totalLengthOfPlainText = (float)Math.Ceiling(plainOrCipherText.Length / encryptionDecryptionKeyLength);
			//this.totalLengthOfPlainText = (float)Math.Round(this.totalLengthOfPlainText);

			//Console.WriteLine(this.totalLengthOfPlainText);
			this.totalLengthOfPlainText = this.totalLengthOfPlainText * encryptionDecryptionKeyLength;
			//Console.WriteLine(this.totalLengthOfPlainText);
			if (this.totalLengthOfPlainText != plainOrCipherText.Length)
			{
				//Console.WriteLine("Must fill blank with Z");
				return this.fillPlainTextblankSpaceWithZ(plainOrCipherText,this.totalLengthOfPlainText);
			}
			else
			{
				return plainOrCipherText;
			}
		}

		public string fillPlainTextblankSpaceWithZ(string plainOrCipherText,float expectedTotalLengthOfPlainOrCipherText)
		{
			int startIndex = plainOrCipherText.Length - 1;
			for(int i = startIndex;i<expectedTotalLengthOfPlainOrCipherText-1; i++)
			{
				plainOrCipherText += 'Z';
			}
			return plainOrCipherText;
		}
		public void insertPlainOrCipherTextWithValues(string plainOrCipherText)
		{
			int keyStringIndex = 0;
			for(int i = 0; i < plainOrCipherText.Length; i++)
			{
				if(keyStringIndex > this.getEncryptionDecryptionKey().Length - 1)
				{
					keyStringIndex = 0;
					//Console.WriteLine(this.keyStirng[keyStringIndex]);
					this.plainOrCipherTextkeyValueList.Add(new KeyValuePair<char, char>(plainOrCipherText[i], this.keyStirng[keyStringIndex]));
				}
				else
				{
					//Console.WriteLine(this.keyStirng[keyStringIndex]);
					this.plainOrCipherTextkeyValueList.Add(new KeyValuePair<char, char>(plainOrCipherText[i], this.keyStirng[keyStringIndex]));
				}
				keyStringIndex++;
			}
		}

		public void displayKeyValuePair()
		{
			//ICollection key = this.plainOrCipherTextkeyValueList.Keys;
			foreach (var value in this.plainOrCipherTextkeyValueList)
			{
				Console.WriteLine(value.Key + ": " + value.Value);
			}
		}
		public void sortKeyString()
		{
			
			for(int i = 0; i < this.getEncryptionDecryptionKey().Length; i++)
			{
				this.newKeyStringList.Add(this.keyStirng[i]);
			}
			this.newKeyStringList.Sort();
			foreach(var number in this.newKeyStringList)
			{
				Console.WriteLine(number);
			}
		}



	}
}
