using System;
using EncryptionGame.Classes;

namespace EncryptionGame
{
	class GameOperation
	{
		static void Main(string[] args)
		{
			CaesarCipher caeserCipher = new CaesarCipher();
			caeserCipher.setCipherText("QNXY ITBS YMJ FHYNANYNJX TK UWNRFWD WNXP FXXJXXRJSY");
			caeserCipher.setEncryptionDecryptionKey(31);
			caeserCipher.decryptCipherText();
			Console.WriteLine($"Decrypted Text: {caeserCipher.getPlainText()}");
			caeserCipher.setPlainText("LIST DOWN THE ACTIVITIES OF PRIMARY RISK ASSESSMENT");
			caeserCipher.encryptPlainText();
			Console.WriteLine($"Encrypted Text: {caeserCipher.getCipherText()}");

		}
	}
}
