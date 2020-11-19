using System;
using EncryptionGame.Classes;

namespace EncryptionGame
{
	class GameOperation
	{
		static void Main(string[] args)
		{
			CaesarCipher caeserCipher = new CaesarCipher();
			//caeserCipher.setNumericValuesToAlphabets();
			//caeserCipher.displayAlphabeticValuesOfnumerics();
			//caeserCipher.getSpecificAlphabetValue('A');
			caeserCipher.setAlphabeticValueForNumerics();
			//caeserCipher.displayNumericValuesOfAlphabets();
			caeserCipher.setNumericValueForAlphabets();
			//Console.WriteLine(caeserCipher.getNumericValueForSpecificAlphabet('G'));
			//Console.WriteLine(caeserCipher.getAlphabeticValueForSpecificNumber(7));
			caeserCipher.setPlainText("Method in which each letter in the plaintext is replaced");
			caeserCipher.setEncryptionDecryptionKey(31);
			caeserCipher.encryptPlainText();

		}
	}
}
