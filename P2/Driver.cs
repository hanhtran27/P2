using System;

namespace P2
{
    class Driver {
        public const int NUMBER_OF_ENCRYPTORS = 10;
        public const int NUMBER_OF_ALPHABET_CHARS = 26;
        public const int MAX_GUESSES = 10;
        public static readonly string[] GUESSED_WORDS = 
            {"yolo", "Output", "understand", "Summon", 
             "Uno", "cHICken", "kIss", "Eat", "Donut"};

        // Description: Print out the welcome message for the testing program.
        //
        // Pre-condition: NONE
        //
        // Post-condition: NONE
        public void Welcome() {
            Console.WriteLine("WELCOME TO THE WORD ENCRYPTION TEST!");
        }

        // Description: Display the goodbye message at the end of the testing program.
        //
        // Pre-condition: NONE
        //
        // Post-condition: NONE
        public void Goodbye() {
            Console.WriteLine("THANK YOU FOR USING WORD ENCRYPTION TESTING PROGRAM!");
        }

        // Running the guessing game with the provided word.
        public void Run(string guess_word) {
            Welcome();

            Random random = new Random();
            int randomValue = random.Next(NUMBER_OF_ALPHABET_CHARS);
            EncryptWord encryptor = new EncryptWord(randomValue);

            while (true) {
                Console.WriteLine("The encryption of {0} is {1}.", guess_word,
                                  encryptor.GetEncryptForWord(guess_word));
                int guessed_string = random.Next(NUMBER_OF_ALPHABET_CHARS);
                Console.WriteLine("Guessed value is {0}.", guessed_string);

                if (encryptor.GuessShiftValue(guessed_string)) {
                    // Correct guess, switch the status to OFF,
                    // and print the statistic.
                    Console.WriteLine("The guessed value is CORRECT. The system is OFF.");
                    encryptor.GetStatistic();
                    Console.WriteLine();
                    break;
                }
                else {
                    Console.WriteLine("The guessed was INCORRECT");
                    if (encryptor.GetCountGuesses() >= MAX_GUESSES) {
                        Console.WriteLine("MAX NUMBER OF GUESSES REACHED!!!!.");
                        Console.WriteLine("The system is reset.");
                        Console.WriteLine("The correct shift value is {0}",
                                          encryptor.GetShiftValue());
                        encryptor.GetStatistic();
                        Console.WriteLine();
                        break;
                    }
                }
            }
            Goodbye();
        }
    }
}
