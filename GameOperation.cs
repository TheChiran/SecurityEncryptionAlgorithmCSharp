﻿using System;
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
			//CaesarCipher caeserCipher = new CaesarCipher(alphabeticValueObject, stringWhiteSpaceObject);
			//caeserCipher.setCipherText("QNXY ITBS YMJ FHYNANYNJX TK UWNRFWD WNXP FXXJXXRJSY");
			//caeserCipher.setEncryptionDecryptionKey(31);
			//caeserCipher.decryptCipherText();
			//Console.WriteLine($"Decrypted Text: {caeserCipher.getPlainText()}");
			//caeserCipher.setPlainText("EXPLAIN THE SECURITY RISK ASSESMENT");
			//caeserCipher.encryptPlainText();
			//Console.WriteLine($"Encrypted Text: {caeserCipher.getCipherText()}");

			//level 2-OneTimePod
			//OneTimePod oneTimePod = new OneTimePod(alphabeticValueObject, stringWhiteSpaceObject);
			//oneTimePod.setPlainText("LEMONADE");
			//oneTimePod.setEncryptionDecryptionKey("EGG");
			//oneTimePod.encryptPlainText();
			//Console.WriteLine($"Encrypted : {oneTimePod.getCipherText()}");
			//oneTimePod.setCipherText("QLTTUHIL");
			//oneTimePod.setEncryptionDecryptionKey("EGG");
			//oneTimePod.decryptCipherText();
			//Console.WriteLine($"Decrypted : {oneTimePod.getPlainText()}");

			//level 3-Transposition
			//Transposition transposition = new Transposition(stringWhiteSpaceObject);
			//transposition.setPlainText("THIS IS A WHITE BOARD");
			//transposition.setEncryptionDecryptionKey(972356);
			//transposition.encryptPlainText();
			//Console.WriteLine($"New Plain Text: {transposition.getCipherText()}");
			//transposition.setCipherText("WSLSWIRIEGWASSRNSSOOFRNPEBNHDLHPEUASINOIDO");
			//transposition.setEncryptionDecryptionKey(1749326);
			//transposition.decryptCipherText();
			//Console.WriteLine($"New Plain Text: {transposition.getPlainText()}");

			//level 4 -hill cliper
			alphabeticValueObject = new AlphabetValue(0);
			HillCliper hillCliper = new HillCliper(alphabeticValueObject, stringWhiteSpaceObject);
			hillCliper.setKeyMatrix(3, 3, 3, 4);
			//hillCliper.setPlainText("ORANGE");
			//hillCliper.encryptionOperation();
			//Console.WriteLine($"Encrypted Text: {hillCliper.getCipherText()}");
			hillCliper.setCipherText("DQRKIUFUJM");
			hillCliper.decryptionOperation();
			Console.WriteLine($"Decrypted Text: {hillCliper.getPlainText()}");
		}
	}
}
