using System;
using System.Collections.Generic;
using System.Text;
using EncryptionGame.Classes.Common;

namespace EncryptionGame.Classes
{
	class HillCliper
	{
		private AlphabetValue alphabeticValueObject;
		private StringWhiteSpace stringWhiteSpaceObject;
		private string plainText;
		private string cipherText;
		private int[,] keyMatrix = new int[2, 2];
		private List<int> plainOrCipherTextNumericValueList = new List<int>();
		private int determinant;
		private int kd;

		public HillCliper(AlphabetValue alphaveticValueObj, StringWhiteSpace stringWhiteSpaceObj)
		{
			this.alphabeticValueObject = alphaveticValueObj;
			this.alphabeticValueObject.setAlphabeticValueForNumerics();
			this.alphabeticValueObject.setNumericValueForAlphabets();
			this.stringWhiteSpaceObject = stringWhiteSpaceObj;
		}

		public void setKeyMatrix(int a11,int a12,int a21,int a22)
		{
			this.keyMatrix[0,0] = a11;
			this.keyMatrix[0,1] = a12;
			this.keyMatrix[1,0] = a21;
			this.keyMatrix[1,1] = a22;

		}

		public int[,] getKeyMetrix()
		{
			return this.keyMatrix;
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


		public void encryptionOperation()
		{
			this.stringWhiteSpaceObject.extractWhiteSpaceIndexFromText(this.getPlainText());
			this.setPlainText(this.stringWhiteSpaceObject.extractWhiteSpacesFromText(this.getPlainText()));
			this.setCipherText(this.encryptOrDecryptPlainOrCipherText(this.getPlainText()));
			this.setCipherText(this.stringWhiteSpaceObject.addWhiteSpacesAfterEncryptingOrDecryptingText(this.getCipherText()));
			this.clearAllUsedList();
		}

		public void decryptionOperation()
		{
			this.stringWhiteSpaceObject.extractWhiteSpaceIndexFromText(this.getCipherText());
			this.setCipherText(this.stringWhiteSpaceObject.extractWhiteSpacesFromText(this.getCipherText()));
			this.findDeterminant();
			this.calculateInverseMatrix();
			this.findValueOfKd();
			this.multiplyKeyValuesWithKd();
			this.setPlainText(this.encryptOrDecryptPlainOrCipherText(this.getCipherText()));
			this.setPlainText(this.stringWhiteSpaceObject.addWhiteSpacesAfterEncryptingOrDecryptingText(this.getPlainText()));
			this.clearAllUsedList();
		}
		public void multiplyKeyValuesWithKd()
		{
			float dividedValue;
			for(int i = 0; i < 2; i++)
			{
				for(int j = 0; j < 2; j++)
				{
					this.keyMatrix[i, j] *= this.kd;
					if (this.keyMatrix[i, j] > 26)
					{
						dividedValue = (float)(this.keyMatrix[i, j] / 26.0);
						dividedValue = (float)((dividedValue - Math.Floor(dividedValue)) * 26);
						if (dividedValue > 0.5)
						{
							dividedValue = (int)(Math.Round(dividedValue));
						}
						else
						{
							dividedValue = (int)(Math.Floor(dividedValue));
						}
						this.keyMatrix[i, j] = (int)(dividedValue);
					}
				}
			}
		}

		public void findValueOfKd()
		{
			int t1 = 0,
				t2 = 1,
				r1 = 26,
				r2 = this.determinant,
				R = 1,
				d,T;
			float dividedValue;
			

			while (R != 0)
			{
				dividedValue = r1 / r2;
				//Console.WriteLine($"r1: {r1}");
				//Console.WriteLine($"r2: {r2}");
				//Console.WriteLine($"divied: {dividedValue}");

				R = (int)(r1 - (r2 * Math.Floor(dividedValue)));
				//Console.WriteLine($"R: {R}");
				if (R == 0)
				{
					this.kd = t2;
				}
				d = (int)(Math.Floor(dividedValue));
				//Console.WriteLine($"D: {d}");

				T = t1 - (t2 * d);
				t1 = t2;
				t2 = T;
				r1 = r2;
				r2 = R;
				
			}
			//Console.WriteLine(this.kd);
		}

		public void calculateInverseMatrix()
		{
			int b11 = this.keyMatrix[1, 1];
			int b12 = -this.keyMatrix[0, 1];
			int b21 = -this.keyMatrix[1, 0];
			int b22 = this.keyMatrix[0, 0];
			this.keyMatrix[0, 0] = b11;
			this.keyMatrix[0, 1] = b12;
			this.keyMatrix[1, 0] = b21;
			this.keyMatrix[1, 1] = b22;
			for(int i = 0; i < 2; i++)
			{
				for(int j = 0; j < 2; j++)
				{
					if (this.keyMatrix[i, j] < 0)
					{
						while (this.keyMatrix[i, j] < 0)
						{
							this.keyMatrix[i, j] += 26;
						}
					}
				}
			}
		}

		public void findDeterminant()
		{
			this.determinant = (this.keyMatrix[0, 0] * this.keyMatrix[1, 1]) - (this.keyMatrix[0, 1] * this.keyMatrix[1, 0]);
			this.determinant = Math.Abs(this.determinant);
		}

		public string encryptOrDecryptPlainOrCipherText(string plainOrCipherText)
		{
			int multiplyResult = 0;
			double dividedValue;
			int newValue;
			for(int i = 0; i < plainOrCipherText.Length; i++)
			{
				if (i % 2 == 0)
				{
					//Console.WriteLine(this.getKeyMetrix()[0, 0]);
					//Console.WriteLine(this.getKeyMetrix()[0, 1]);
					multiplyResult =
						(this.getKeyMetrix()[0, 0] *
						this.alphabeticValueObject.getNumericValueForSpecificAlphabet(plainOrCipherText[i])) +
						(this.getKeyMetrix()[0, 1] *
						this.alphabeticValueObject.getNumericValueForSpecificAlphabet(plainOrCipherText[i + 1]));
					//Console.WriteLine(multiplyResult);
				}
				else if (i % 2 != 0)
				{
					//Console.WriteLine(this.getKeyMetrix()[1, 0]);
					//Console.WriteLine(this.getKeyMetrix()[1, 1]);
					multiplyResult =
						(this.getKeyMetrix()[1, 0] *
						this.alphabeticValueObject.getNumericValueForSpecificAlphabet(plainOrCipherText[i-1])) +
						(this.getKeyMetrix()[1, 1] *
						this.alphabeticValueObject.getNumericValueForSpecificAlphabet(plainOrCipherText[i ]));
					//Console.WriteLine(multiplyResult);

				}
				if (multiplyResult > 26)
				{
					dividedValue = (float)(multiplyResult / 26.0);
					dividedValue = (dividedValue - Math.Floor(dividedValue)) * 26;

					if (dividedValue > 0.5)
					{
						newValue = (int)(Math.Round(dividedValue));
					}
					else
					{
						newValue = (int)(Math.Floor(dividedValue));
					}

				}
				else
				{
					newValue = multiplyResult;
				}
				//Console.WriteLine(newValue);
				this.plainOrCipherTextNumericValueList.Add(newValue);
				//count++;
			}

			return this.calculateCipherOrPlainText(plainOrCipherText);
		}

		public string calculateCipherOrPlainText(string plainOrCipherText)
		{
			plainOrCipherText = "";
			foreach(var alphabetValue in this.plainOrCipherTextNumericValueList)
			{
				plainOrCipherText += this.alphabeticValueObject.getAlphabeticValueForSpecificNumber(alphabetValue);
			}
			return plainOrCipherText;
			//Console.WriteLine(plainOrCipherText);
		}

		public void clearAllUsedList()
		{
			this.plainOrCipherTextNumericValueList.Clear();
			this.stringWhiteSpaceObject.clearWhiteSpaceList();
		}



	}
}
