using System;
using System.Collections.Generic;
using System.Linq;
using static System.GC;

namespace AITDNSevenPointFiveAnswers
{

    /// <summary>
    /// This small program has several problems and excellent opportunities to refactor, can you spot them all and re-code it??
    /// </summary>
    /// <author>
    /// Samuel Bancroft (c) 2017
    /// </author>
    /// <code>
    /// Using Delegates to perform two operations on a pair of strings - imagine these methods are in seperate areas of the program.
    /// A lot of the needed varibles are declared at the start of the file, are they all needed? Could more be used to clarify the code.
    /// Are there repetitions in the code which can be refactored out into seperate methods to apply the DRY principle previously discussed?
    /// An answer will be forthcoming in the next couple of weeks - no cheating! Good luck.
    /// 
    /// OH and there a no further comments to help you out, you are on your own :-(
    /// well..... maybe one clue the code on lines 4 and 48 are related.
    /// 
    /// ANSWERS BELOW....
    /// 
    /// </code>

    internal class Program
    {
        private static string _firstNormal, _secondNormal, _firstReversed, _secondReversed;
        private static IEnumerable<char> _firstReverse, _secondReverse;
        private const string TrueString = "True", FalseString = "False";

        private static void Main(string[] args)
        {
            Console.Write("Please enter string number one: ");
            _firstNormal = Console.ReadLine();

            Console.Write("\nPlease enter string number two: ");
            _secondNormal = Console.ReadLine();

            Console.WriteLine();

            var useTestDelegate = new TestDelegate(DelegateFunctionOne);
            Console.WriteLine(useTestDelegate(_firstNormal, _secondNormal));
            useTestDelegate += DelegateFunctionTwo;
            Console.WriteLine(useTestDelegate(_firstNormal, _secondNormal));


            Collect();

            Console.Write("Press any key to exit...");
            Console.ReadKey();
        }

        private delegate string TestDelegate(string inputOne, string inputTwo);

        public static string DelegateFunctionOne(string inputOne, string inputTwo)
        {
            _firstReverse = _firstNormal.Reverse();
            _secondReverse = _secondNormal.Reverse();
            var reverseConversion = "";
            foreach (var c in _firstReverse)
            {
                reverseConversion += c.ToString().ToUpper() + " ";
                _firstReversed += c.ToString();
                foreach (var d in _secondReverse)
                {
                    _secondReversed += d.ToString();
                    reverseConversion += d.ToString();
                }
                reverseConversion += " ";
            }

            return reverseConversion;
        }

        public static string DelegateFunctionTwo(string reversedOne, string reversedTwo)
        {
            var firstStringLength = _firstNormal.Length;
            var secondStringLength = _secondNormal.Length;
            var sortedFirstReversed = _firstReversed.Substring(0, firstStringLength);
            var sortedSecondReversed = _secondReversed.Substring(0, secondStringLength);

            var returnString = "";

            if (sortedFirstReversed == _firstNormal)
            {
                returnString += "The first string is a palindrome: " + TrueString + "\n";
            }
            else
            {
                returnString += "The first string is a palindrome: " + FalseString + "\n";
            }
            if (sortedSecondReversed == _secondNormal)
            {
                returnString += "The second string is a palindrome: " + TrueString + "\n";
            }
            else
            {
                returnString += "The second string is a palindrome: " + FalseString + "\n";
            }

            return returnString;
        }
    }
}

