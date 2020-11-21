using System;
using EncryptionGame.Classes;
using EncryptionGame.Classes.Common;

namespace EncryptionGame
{
	class GameOperation
	{
		static void Main(string[] args)
		{
			CaesarCipher caeserCipher = new CaesarCipher(new AlphabetValue(),new StringWhiteSpace());
			caeserCipher.setCipherText("DSSOH");
			caeserCipher.setEncryptionDecryptionKey(3);
			caeserCipher.decryptCipherText();
			Console.WriteLine($"Decrypted Text: {caeserCipher.getPlainText()}");
			caeserCipher.setPlainText("Apple");
			caeserCipher.encryptPlainText();
			Console.WriteLine($"Encrypted Text: {caeserCipher.getCipherText()}");

		}
	}
}
