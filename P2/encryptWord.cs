// AUTHOR: tranh10
// FILENAME: encryptWord.cs
// DATE: 4/12/2018

// Description: This class provide functions that available in Encryptword
// class, does NOT hold any encrypt word. The word is passed through encrypt
// function and the function returns encrypted word with each character shifted
// by the |shift_value| attribute. This class is a helper class, that later
// will be called in main function.

// Legal Input:
// *** EncryptWord: NONE
// *** TurnOn: NONE
// *** TurnOff: NONE
// *** Reset: NONE
// *** Reset: Take in an positive integer for |shift_val|
// *** GetEncryptForWord: Take in a string of 4 or more characters of input
//     word.
// *** GetDecryptedForWord: Take in a string of 4 or more characters of input 
//     word.
// *** GuessShiftValue: Take in a positive integer as value.
// *** GetStatistic: NONE
// *** GetCountGuesses: NONE

// Illega Input: NULL, string that has less then 4 characters and negative
// integer.

// Assumption: all int variable that input must be an integer greater or equal
// 0.
// shift value is limited from 1 to number of alphabet character.
// Object includes 3 states: ON, OFF, and RESET.

using System;

namespace Application
{
    public class EncryptWord
    {
        private int shift_value_;
        private int count_guesses;
        private int high_guesses;
        private int low_guesses;
        private int total_guess_value;
        private bool status;
        private const int NUM_ALPHABET = 26;

        // Description: Randomize a integer value, and assigns it to
        // |shift_value|. At the beginning, the state of object is ON.
        //
        // Pre-condition: None.
        //
        // Post-condition: |count_guess|, |total_guess_value|, |high_guess|,
        // |low_guess| are zeroes, and |shift_value| is an integer between 0
        // and 25.
        public EncryptWord(int value) {
            shift_value = value;
            count_guesses = 0;
            high_guesses = 0;
            low_guesses = 0;
            total_guess_value = 0;        
        }

        // Description: Checks if the object status is on/off.
        //
        // Pre-condition: None.
        //
        // Post-condition: Return a boolean represent the state of the system.
        public bool IsOn() {
            return status;
        }

        // Description: Change status of |this| Encryptor from off to on.
        //
        // Pre-condition: |status| is off.
        //
        // Post-condition: |status| is on.
        public void TurnOn() {
            status = true;
        }

        // Description: Change status of |this| Encryptor from on to off.
        //
        // Pre-condition: |status| is on.
        //
        // Post-condition: |status| is off.
        public void TurnOff() {
            status = false;
        }

        // Description: To reset the statistic of the Encryptor, and turn the state
        // to ON
        //
        // Pre-condition: State of object must be OFF
        //
        // Post-condition: State of object ON, reset the statistic
        public void Reset() {
            TurnOn();
            Random random = new Random();
            shift_value_ = random.Next(NUM_ALPHABET);
            count_guesses = 0;
            high_guesses = 0;
            low_guesses = 0;
            total_guess_value = 0;
        }

        // Description: Calling the default Reset(), and set |shift_value_| to the
        // given |shift_val|.
        //
        // Pre-condition: NULL
        //
        // Post-condition: Reset statistic
        public void Reset(int shift_val) {
            Reset();
            shift_value_ = shift_val;
        }


        // Description: Returns a string that is the encryption of the given string
        // by shifting each character by the shift value.
        //
        // Pre-condition: |word| is a string of characters, with each char is an
        // ASCII character.
        //
        // Post-condition:
        //   - If |word| has length less than 4, return an empty string, and print
        //   an error message to the console.
        //   - Otherwise, return the encrypted string, where each alphabet
        //   character (between 'a' - 'z' and 'A' - 'Z') is shifted |shift_value|.
        //   The special characters (i.e. Not in the alphabet) is kept the same.
        public string GetEncryptForWord(string word) {
            if (!status)
            {
                Console.WriteLine("System is off!");
                return "";
            }
            string result = "";
            for (size_t i = 0; i < word.length(); i++)
            {
                if (word[i] < 'A' || word[i] > 'z' || (word[i] > 'Z' && word[i] < 'a'))
                {
                    result += word[i];
                    continue;
                }

                bool is_not_capitalized = ('a' <= word[i] && word[i] <= 'z');

                int baseNum = is_not_capitalized ? 'a' : 'A';
                int offset = word[i] - baseNum;
                int index = is_not_capitalized ? offset : offset + NUM_ALPHABET;

                result += decrypted_chars_[index];
            }
            return result;
        }

        // Description: Returns a string that is the decryption of the given string
        // by shifting each character by the shift value.
        //
        // Pre-condition: |word| is a string of characters, with each char is an
        // ASCII character.
        //
        // Post-condition:
        //   - If |word| has length less than 4, return an empty string, and print
        //   an error message to the console.
        //   - Otherwise, return the encrypted string, where each alphabet
        //   character (between 'a' - 'z' and 'A' - 'Z') is shifted |shift_value|.
        //   The special characters (i.e. Not in the alphabet) is kept the same.
        public string GetDecryptedForWord(string word) {
            if (!status)
            {
                Console.WriteLine("System is off!");
                return "";
            }
            string result = "";
            for (size_t i = 0; i < word.length(); i++)
            {
                if (word[i] < 'A' || word[i] > 'z' || (word[i] > 'Z' && word[i] < 'a'))
                {
                    result += word[i];
                    continue;
                }

                char baseNum = ('A' <= word[i] && word[i] <= 'Z') ? 'A' : 'a';

                int offset = (word[i] - baseNum - shift_value_);

                offset += (offset < 0) ? NUM_ALPHABET : 0;

                result += char(baseNum + offset);
            }
            return result;
        }


        // Description: A method that checks whether the passed in integer is the
        // |shift_value| or not.
        //
        // Pre-condition: |value| is an integer.
        //
        // Post-condition:
        //   - Returns true if |value| equals to |shift_value|, and
        //   returns false otherwise.
        //   - Increment |count_guess|, |total_guess_value|, |high_guess|,
        //   |low_guess| according to the guess value.
        //   - Switch the state to OFF if |guess| is equals to |shift_value|.
        public bool GuessShiftValue(int value) {
            if (!status)
            {
                Console.WriteLine("System is off!");
                return "";
            }
            count_guesses++;
            total_guess_value += value;

            if (value == shift_value_)
            {
                return true;
            }
            if (value > shift_value_)
            {
                high_guesses++;
            }
            if (value < shift_value_)
            {
                low_guesses++;
            }
            return false;
        }

        // Description: Print the statistic of guesses to the screen.
        //
        // Pre-condition: NONE.
        // Post-condition: Print the number of guesses, high guesses, low guesses,
        // and average of guess value to the console.
        public void GetStatistic() {
            Console.WriteLine("Number of guesses: ", count_guesses);
            Console.WriteLine("Number of high guesses: ", high_guesses);
            Console.WriteLine("Number of low guesses: ", low_guesses);
            Console.WriteLine("Average guess value: ",(1.0) * total_guess_value / count_guesses);
        }


        // Description: Returns the number of guesses have been made.
        //
        // Pre-condition: NONE.
        //
        // Post-condition: An non-negative integer representing the total number of
        // guesses.
        public int GetCountGuesses() {
            return count_guesses;
        }
    }
}
