using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace EncryptionGame.Classes
{
	class AlphabetValue
	{
		private Hashtable numericValueHashTable = new Hashtable();
		private Hashtable alphabeticValueHashTable = new Hashtable();
		private char alphabet;
		private int alphabetIndex;
		private int startingIndex;
		public AlphabetValue(int startingIndex)
		{
			this.startingIndex = startingIndex;
		}
		
		public void setAlphabeticValueForNumerics()
		{

			this.alphabetIndex = this.startingIndex;
			for (this.alphabet = 'A'; this.alphabet <= 'Z'; this.alphabet++)
			{
				this.alphabeticValueHashTable.Add(this.alphabetIndex, this.alphabet);
				this.alphabetIndex++;
			}
		}

		public void setNumericValueForAlphabets()
		{

			this.alphabetIndex = this.startingIndex;
			for (this.alphabet = 'A'; this.alphabet <= 'Z'; this.alphabet++)
			{
				this.numericValueHashTable.Add(this.alphabet, this.alphabetIndex);
				this.alphabetIndex++;
			}
		}

		public int getNumericValueForSpecificAlphabet(char alphabet)
		{
			int result = Convert.ToInt32(this.numericValueHashTable[alphabet]);
			return result;
		}

		public char getAlphabeticValueForSpecificNumber(int numericValue)
		{
			if (numericValue == 0)
			{
				return 'Z';
			}
			else
			{
				char alphabeticValue = Convert.ToChar(this.alphabeticValueHashTable[numericValue]);
				return alphabeticValue;
			}
		}
	}
}
