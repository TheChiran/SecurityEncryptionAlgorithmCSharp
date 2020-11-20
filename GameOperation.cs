using System;
using EncryptionGame.Classes;
using EncryptionGame.Classes.Common;

namespace EncryptionGame
{
	class GameOperation
	{
		static void Main(string[] args)
		{
			AlphabetValue alphabeticValueObject = new AlphabetValue();
			StringWhiteSpace stringWhiteSpaceObject = new StringWhiteSpace();

			//level 1- caeser cipher
			CaesarCipher caeserCipher = new CaesarCipher(alphabeticValueObject, stringWhiteSpaceObject);
			caeserCipher.setCipherText("QNXY ITBS YMJ FHYNANYNJX TK UWNRFWD WNXP FXXJXXRJSY");
			caeserCipher.setEncryptionDecryptionKey(31);
			caeserCipher.decryptCipherText();
			Console.WriteLine($"Decrypted Text: {caeserCipher.getPlainText()}");
			caeserCipher.setPlainText("EXPLAIN THE SECURITY RISK ASSESMENT");
			caeserCipher.encryptPlainText();
			Console.WriteLine($"Encrypted Text: {caeserCipher.getCipherText()}");

			//level 2-OneTimePod
			
		}
	}
}
