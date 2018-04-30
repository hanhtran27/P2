using System;
namespace Application
{
    public class p2
    {
        private const int NUMBER_OF_ENCRYPTORS = 10;
        private const int NUMBER_OF_ALPHABET_CHARS = 26;
        private const int MAX_GUESSES = 10;
        private const string GUESSED_WORDS[] = {"yolo", "Output", "understand",
                                         "Summon", "Uno", "cHICken", "kIss",
                                         "Eat", "Donut"};
        private const size_t NUMBER_OF_GUESSED_WORDS = 9;


        // Description: Print out the welcome message for the testing program.
        //
        // Pre-condition: NONE
        //
        // Post-condition: NONE
        public void Welcome(){
            Console.WriteLine("WELCOME TO THE WORD ENCRYPTION TEST!");
        }

        // Description: Display the goodbye message at the end of the testing program.
        //
        // Pre-condition: NONE
        //
        // Post-condition: NONE
        public void Goodbye(){
            Console.WriteLine("THANK YOU FOR USING WORD ENCRYPTION TESTING PROGRAM!");
        }

        public static void Main(string[] args)
        {
            Random random = new Random();
            int RandNum = random.Next() % NUMBER_OF_GUESSED_WORDS;

            // A collection of EncryptWord objects for demonstrating EncryptWord's
            // behavior.
            encryptWord encryptors[NUMBER_OF_ENCRYPTORS];

            // A typical interaction with an EncryptWord is calling the
            // EncryptWord::GetEncryptForWord method with some word with length greater
            // than 4. Base on the result encryption, guess the value of |shift_value|
            // using the EncryptWord::GuessShiftValue method. If the guess value is not
            // equal to |shift_value|, continue to either enter a new guess integer
            // value, or a new word. If the guessed value is correct, then the state is
            // switched to OFF, and the statistic is printed using the
            // EncryptWord::GetStatistic method.
            size_t current_index = 0;
            for (int encryptor = 0; encryptor < encryptors.Length; encryptor++)
            {

                // Display welcome message
                Welcome();

                // Initialize a random shift value between 0 and 25.
                encryptors[encryptor] = new EncryptWord(RandNum);

                Console.WriteLine("ENCRYPTOR #", ++current_index);

                while (true)
                {

                    string guess_word =
                        GUESSED_WORDS[RandNum];

                    Console.WriteLine("The encryption of ", guess_word, " is ",
                                      encryptors[encryptor].GetEncryptForWord(guess_word);

                    int guess_value = random.Next() % NUMBER_OF_ALPHABET_CHARS;

                    Console.WriteLine("Guessed value is ", guess_value);

                    if (encryptors[encryptor].GuessShiftValue(guess_value))
                    {
                        // Correct guess, switch the status to OFF,
                        // and print the statistic.
                        Console.WriteLine("The guessed value is CORRECT. The system is OFF.");
                        encryptors[encryptor].GetStatistic();
                        Console.WriteLine();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("The guessed was INCORRECT");
                        if (encryptors[encryptor].GetCountGuesses() >= MAX_GUESSES)
                        {
                            Console.WriteLine("MAX NUMBER OF GUESSES REACHED!!!!.");
                            Console.WriteLine("The system is reset.");
                            Console.WriteLine("The correct shift value is ",
                                              encryptors[encryptor].GetShiftValue()
                                              encryptors[encryptor].GetStatistic());
                            Console.WriteLine();
                            break;
                        }
                    }
                }
            }
        }
    }
}
