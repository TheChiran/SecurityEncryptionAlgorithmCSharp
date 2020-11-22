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
		private string keyString;
		private string updatedKeyString;
		private float totalLengthOfPlainText;
		private List<KeyValuePair<char,char>> plainOrCipherTextkeyValueList = new List<KeyValuePair<char,char>>();
		private ArrayList newKeyStringList = new ArrayList();
		private List<int> decriptedStringIndexlist = new List<int>();


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

		public void setEncryptionDecryptionKey(long keyString)
		{
			this.keyString = Convert.ToString(keyString);
		}

		public string getEncryptionDecryptionKey()
		{
			return this.keyString;
		}

		public void encryptPlainText()
		{
			this.setPlainText(this.getPlainText().ToUpper());
			this.stringWhiteSpaceObject.extractWhiteSpaceIndexFromText(this.getPlainText());
			this.setPlainText(this.stringWhiteSpaceObject.extractWhiteSpacesFromText(this.getPlainText()));
			this.setPlainText(this.checkIfThereIsAnySpaceLeftToBeFilled(this.getPlainText()));
			this.insertPlainTextWithValues(this.getPlainText());
			this.sortKeyString();
			this.setCipherText(this.generatePlainOrCipherText(this.getCipherText()));
			this.setCipherText(this.stringWhiteSpaceObject.addWhiteSpacesAfterEncryptingOrDecryptingText(this.getCipherText()));
		}

		public void decryptCipherText()
		{
			this.setCipherText(this.getCipherText().ToUpper());
			this.stringWhiteSpaceObject.extractWhiteSpaceIndexFromText(this.getCipherText());
			this.setCipherText(this.stringWhiteSpaceObject.extractWhiteSpacesFromText(this.getCipherText()));
			//this.setPlainText(this.checkIfThereIsAnySpaceLeftToBeFilled(this.getPlainText()));
			this.sortKeyString();
			this.storeSortedArrayIntoNewString();
			this.insertCipherTextWithValues(this.getCipherText());
			this.setPlainText(this.generatePlainText(this.getPlainText()));
			this.setPlainText(this.stringWhiteSpaceObject.addWhiteSpacesAfterEncryptingOrDecryptingText(this.getPlainText()));

		}
		
		public void insertCipherTextWithValues(string cipherText)
		{
			int presentKeyIndex = 0;
			int totalCharacterInEachKey = this.getCipherText().Length / this.getEncryptionDecryptionKey().Length;
			int presentKeyIndexLimit = totalCharacterInEachKey;
			for(int i = 0; i < cipherText.Length; i++)
			{
				this.plainOrCipherTextkeyValueList.Add(new KeyValuePair<char, char>(cipherText[i], this.updatedKeyString[presentKeyIndex]));
				if (i + 1 == presentKeyIndexLimit)
				{
					presentKeyIndexLimit += totalCharacterInEachKey;
					presentKeyIndex++;
				}

			}
		}

		public string generatePlainText(string cipherOrPlainText)
		{
			cipherOrPlainText = "";
			int keyStringPresentIndex = 0;
			//Console.WriteLine(this.getEncryptionDecryptionKey().Length);
			for(int i = 0; i < this.plainOrCipherTextkeyValueList.Count; i++)
			{
				for (int j = 0; j < this.plainOrCipherTextkeyValueList.Count; j++)
				{
					
					if (!decriptedStringIndexlist.Contains(j)) 
					{
						
						if (this.keyString[keyStringPresentIndex] == this.plainOrCipherTextkeyValueList[j].Value)
						{
							
							cipherOrPlainText += this.plainOrCipherTextkeyValueList[j].Key;
							this.decriptedStringIndexlist.Add(j);
							//Console.WriteLine($"Alphabet: {this.plainOrCipherTextkeyValueList[j].Key}");
							if (keyStringPresentIndex == this.getEncryptionDecryptionKey().Length - 1)
							{
								keyStringPresentIndex = 0;
							}
							else
							{
								keyStringPresentIndex++;
							}
							
						}
					}

				}
			}
			return cipherOrPlainText;
		}

		public string checkIfThereIsAnySpaceLeftToBeFilled(string plainOrCipherText)
		{
			float encryptionDecryptionKeyLength = this.getEncryptionDecryptionKey().Length;
			this.totalLengthOfPlainText = (float)Math.Ceiling(plainOrCipherText.Length / encryptionDecryptionKeyLength);
			this.totalLengthOfPlainText = this.totalLengthOfPlainText * encryptionDecryptionKeyLength;
			
			if (this.totalLengthOfPlainText != plainOrCipherText.Length)
			{
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

		public void insertPlainTextWithValues(string plainOrCipherText)
		{
			int keyStringIndex = 0;
			for(int i = 0; i < plainOrCipherText.Length; i++)
			{
				if(keyStringIndex > this.getEncryptionDecryptionKey().Length - 1)
				{
					keyStringIndex = 0;
					this.plainOrCipherTextkeyValueList.Add(new KeyValuePair<char, char>(plainOrCipherText[i], this.keyString[keyStringIndex]));
				}
				else
				{
					this.plainOrCipherTextkeyValueList.Add(new KeyValuePair<char, char>(plainOrCipherText[i], this.keyString[keyStringIndex]));
				}
				keyStringIndex++;
			}
		}

		public void sortKeyString()
		{
			
			for(int i = 0; i < this.getEncryptionDecryptionKey().Length; i++)
			{
				this.newKeyStringList.Add(this.keyString[i]);
			}
			this.newKeyStringList.Sort();
		}

		public void storeSortedArrayIntoNewString()
		{
			foreach(var number in this.newKeyStringList)
			{
				this.updatedKeyString += number;
			}
		}

		public string generatePlainOrCipherText(string finalText)
		{
			finalText = "";
			foreach(var number in this.newKeyStringList)
			{
				foreach(var text in this.plainOrCipherTextkeyValueList)
				{
					if(Convert.ToChar(number) == text.Value)
					{
						finalText += text.Key;
					}
				}
			}
			return finalText;
		}



	}
}
