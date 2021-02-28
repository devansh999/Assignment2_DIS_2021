using System;
using System.Linq;
using System.Collections.Generic;
namespace Assignment2_DIS_Spring2021
{
    class DevanshAssignment
    {
        public static void Main(string[] args)
        {
            //Question1:
            Console.WriteLine("Question 1");
            int[] ar1 = { 2, 5, 1, 3, 4, 7 };
            int n1 = 3;
            ShuffleArray(ar1, n1);

            //Question 2 
            Console.WriteLine("Question 2");
            int[] ar2 = { 0, 1, 0, 3, 12 };
            MoveZeroes(ar2);
            Console.WriteLine("");

            //Question3
            Console.WriteLine("Question 3");
            int[] ar3 = { 1, 2, 3, 1, 1, 3 };
            CoolPairs(ar3);
            Console.WriteLine();

            //Question 4
            Console.WriteLine("Question 4");
            int[] ar4 = { 2, 7, 11, 15 };
            int target = 9;
            TwoSum(ar4, target);
            Console.WriteLine();

            //Question 5
            Console.WriteLine("Question 5");
            string s5 = "korfsucy";
            int[] indices = { 6, 4, 3, 2, 1, 0, 5, 7 };
            RestoreString(s5, indices);
            Console.WriteLine();

            //Question 6
            Console.WriteLine("Question 6");
            string s61 = "bulls";
            string s62 = "sunny";
            if (Isomorphic(s61, s62))
            {
                Console.WriteLine("Yes the two strings are Isomorphic");
            }
            else
            {
                Console.WriteLine("No, the given strings are not Isomorphic");
            }
            Console.WriteLine();

            //Question 7
            Console.WriteLine("Question 7");
            int[,] scores = { { 1, 91 }, { 1, 92 }, { 2, 93 }, { 2, 97 }, { 1, 60 }, { 2, 77 }, { 1, 65 }, { 1, 87 }, { 1, 100 }, { 2, 100 }, { 2, 76 } };
            HighFive(scores);
            Console.WriteLine();

            //Question 8
            Console.WriteLine("Question 8");
            int n8 = 19;
            if (HappyNumber(n8))
            {
                Console.WriteLine("{0} is a happy number", n8);
            }
            else
            {
                Console.WriteLine("{0} is not a happy number", n8);
            }
            Console.WriteLine();

            //Question 9
            Console.WriteLine("Question 9");
            int[] ar9 = { 7, 1, 5, 3, 6, 4 };
            int profit = Stocks(ar9);
            if (profit == 0)
            {
                Console.WriteLine("No Profit is possible");
            }
            else
            {
                Console.WriteLine("Profit is {0}", profit);
            }
            Console.WriteLine();

            //Question 10
            Console.WriteLine("Question 10");
            int n10 = 3;
            Stairs(n10);
            Console.WriteLine();
        }

        //Question 1
        /// <summary>
        /// Shuffle the input array nums consisting of 2n elements in the form [x1,x2,...,xn,y1,y2,...,yn].
        /// Print the array in the form[x1, y1, x2, y2, ..., xn, yn].
        ///Example 1:
        ///Input: nums = [2,5,1,3,4,7], n = 3
        ///Output: [2,3,5,4,1,7]
        ///  Explanation: Since x1 = 2, x2 = 5, x3 = 1, y1 = 3, y2 = 4, y3 = 7 then the answer is [2,3,5,4,1,7].
        ///Example 2:
        ///Input: nums = [1,2,3,4,4,3,2,1], n = 4
        ///Output: [1,4,2,3,3,2,4,1]
        ///Example 3:
        ///Input: nums = [1,1,2,2], n = 2
        ///Output: [1,2,1,2]
        /// </summary>

        private static void ShuffleArray(int[] numbersToShuffle, int sets)
        {
            try
            {
                int sizeOfShufflingArray = numbersToShuffle.Length;
                // Resultant array
                int[] shufflingArray = new int[sizeOfShufflingArray];
                // Sample arrays
                int[] firstxvals = new int[sets];
                int[] firstyvals = new int[sets];
                for (int i = 0; i < sizeOfShufflingArray; i++)
                {
                    if (i < sets)
                    {
                        // adding x values to xsample array
                        firstxvals[i] = numbersToShuffle[i];
                    }
                    else
                    {
                        // adding y values to ysample array
                        firstyvals[i - sets] = numbersToShuffle[i];
                    }
                }
                // Shuffling samples to Resultant
                int a = 0, b = 0, c = 0;
                // filling altenatively
                while (a < sets && b < sets)
                {
                    shufflingArray[c++] = firstxvals[a++];
                    shufflingArray[c++] = firstyvals[b++];
                }
                string comma = "[";
                foreach (int val in shufflingArray)
                {
                    Console.Write(comma + val);
                    comma = ",";
                }
                Console.WriteLine("]");
                Console.WriteLine();
            }
            catch (Exception)
            {
                throw new Exception("Exception found in Question 1");
            }
        }

        //Question 2:
        /// <summary>
        /// Write a method to move all 0's to the end of the given array. You should maintain the relative order of the non-zero elements. 
        /// You must do this in-place without making a copy of the array.
        /// Example:
        ///Input: [0,1,0,3,12]
        /// Output: [1,3,12,0,0]
        /// </summary>

        private static void MoveZeroes(int[] zeroToBeMoved)
        {
            try
            {
                int sizeOfZerosArray = zeroToBeMoved.Length;
                int idx = 0;
                for (int i = 0; i < sizeOfZerosArray; i++)
                {
                    // keeping the non zero elements in order in first indices
                    if (zeroToBeMoved[i] != 0)
                    {
                        zeroToBeMoved[idx] = zeroToBeMoved[i];
                        idx++;
                    }
                }
                while (idx < sizeOfZerosArray)
                {
                    // the remaining part of the array are zeros
                    zeroToBeMoved[idx] = 0;
                    idx++;
                }
                // printing the output
                string comma = "[";
                foreach (int i in zeroToBeMoved)
                {
                    Console.Write(comma + i);
                    comma = ",";
                }
                Console.WriteLine("]");
            }
            catch (Exception)
            {
                throw new Exception("Exception found in Question 2");
            }
        }

        //Question 3
        /// <summary>
        /// For an array of integers - nums
        ///A pair(i, j) is called cool if nums[i] == nums[j] and i<j
        ///Print the number of cool pairs
        ///Example 1
        ///Input: nums = [1,2,3,1,1,3]
        ///Output: 4
        ///Explanation: There are 4 cool pairs (0,3), (0,4), (3,4), (2,5) 
        ///Example 3:
        ///Input: nums = [1, 2, 3]
        ///Output: 0
        ///Constraints: time complexity should be O(n).
        /// </summary>

        private static void CoolPairs(int[] giveArray)
        {
            try
            {
                int coolPairs = 0;
                int size = giveArray.Length;
                // dictionary to store the frequency
                Dictionary<int, int> frequencyDict = new Dictionary<int, int>();
                for (int i = 0; i < size; i++)
                {
                    // storing the repeatitions of the elements
                    if (frequencyDict.ContainsKey((int)giveArray[i]))
                    {
                        frequencyDict[giveArray[i]] += 1;
                    }
                    else
                    {
                        frequencyDict.Add(giveArray[i], 1);
                    }
                }
                foreach (KeyValuePair<int, int> x in frequencyDict)
                {
                    // cool pair if frequency is more than 1
                    if (x.Value > 1)
                    {
                        coolPairs += ((x.Value) * (x.Value - 1)) / 2;
                    }
                }
                // printing the Output
                Console.WriteLine(coolPairs);
            }
            catch (Exception)
            {
                throw new Exception("Exception found in Question 3");
            }
        }

        //Question 4:
        /// <summary>
        /// Given integer target and an array of integers, print indices of the two numbers such that they add up to the target.
        ///You may assume that each input would have exactly one solution, and you may not use the same element twice.
        /// You can print the answer in any order
        ///Example 1:
        ///Input: nums = [2,7,11,15], target = 9
        /// Output: [0,1]
        ///Output: Because nums[0] + nums[1] == 9, we print [0, 1].
        ///Example 2:
        ///Input: nums = [3,2,4], target = 6
        ///Output: [1,2]
        ///Example 3:
        ///Input: nums = [3,3], target = 6
        ///Output: [0,1]
        ///Constraints: Time complexity should be O(n)
        /// </summary>
        private static void TwoSum(int[] arrayToPair, int sum)
        {
            try
            {
                int[] pairToBeSum = new int[2];
                // Hashset for storing the array
                HashSet<int> set = new HashSet<int>();
                for (int i = 0; i < arrayToPair.Length; i++)
                {
                    // difference between the sum and any number should be the value of other pair
                    if (set.Contains(sum - arrayToPair[i]))
                    {
                        // if pairs found, then we add the index and value
                        pairToBeSum[0] = sum - arrayToPair[i];
                        pairToBeSum[1] = i;
                    }
                    set.Add(arrayToPair[i]);
                }
                for (int i = 0; i < arrayToPair.Length; i++)
                {
                    if (pairToBeSum[0] == arrayToPair[i])
                    {
                        // finding index of the value assuming unique
                        pairToBeSum[0] = i;
                    }
                }
                // printing Output
                string comma = "[";
                foreach (int val in pairToBeSum)
                {
                    Console.Write(comma + val);
                    comma = ",";
                }
                Console.WriteLine("]");
            }
            catch (Exception)
            {
                throw new Exception("Exception found in Question 4");
            }
        }

        //Question 5:
        /// <summary>
        /// Given a string s and an integer array indices of the same length.
        ///The string s will be shuffled such that the character at the ith position moves to indices[i] in the shuffled string.
        ///Print the shuffled string.
        ///Example 1
        ///Input: s = "korfsucy", indices = [6,4,3,2,1,0,5,7]
        ///Output: "usfrocky"
        ///Explanation: As shown in the assignment document, “K” should be at index 6, “O” should be at index 4 and so on. “korfsucy” becomes “usfrocky”
        ///Example 2:
        ///Input: s = "USF", indices = [0,1,2]
        ///Output: "USF"
        ///Explanation: After shuffling, each character remains in its position.
        ///Example 3:
        ///Input: s = "ockry", indices = [1, 2, 3, 0, 4]
        ///Output: "rocky"
        /// </summary>
        private static void RestoreString(string stringToReorder, int[] orderIndices)
        {
            try
            {
                // change the string to character set
                char[] charsToReorder = stringToReorder.ToCharArray();
                // map the indices and corresponding characters
                var hashMap = orderIndices.Zip(charsToReorder, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v);
                // sorting the hashmap with respect to indices
                var sortedHashMap = new SortedDictionary<int, char>(hashMap);
                // constructing and printing final string
                string restoredString = "";
                foreach (KeyValuePair<int, char> x in sortedHashMap)
                {
                    restoredString += x.Value;
                }
                Console.WriteLine(restoredString);
            }
            catch (Exception)
            {
                throw new Exception("Exception found in Question 5");
            }
        }

        //Question 6
        /// <summary>
        /// Determine whether two give strings s1 and s2, are isomorphic.
        ///Two strings are isomorphic if the characters in s1 can be replaced to get s2.
        ///All occurrences of a character must be replaced with another character while preserving the order of characters.
        ///No two characters may map to the same character but a character may map to itself.
        ///Example 1:
        ///Input:s1 = “bulls” s2 = “sunny” 
        ///Output : True
        ///Explanation: ‘b’ can be replaced with ‘s’ and similarly ‘u’ with ‘u’, ‘l’ with ‘n’ and ‘s’ with ‘y’.
        ///Example 2:
        ///Input: s1 = “usf” s2 = “add”
        ///Output : False
        ///Explanation: ‘u’ can be replaced with ‘a’, but ‘s’ and ‘f’ should be replaced with ‘d’ to produce s2, which is not possible. So False.
        ///Example 3:
        ///Input : s1 = “ab” s2 = “aa”
        ///Output: False
        /// </summary>
        private static bool Isomorphic(string testString1, string testString2)
        {
            try
            {
                // convert strings to character sets
                char[] characterSet1 = testString1.ToCharArray();
                char[] characterSet2 = testString2.ToCharArray();
                // Dictionary to map the characters from both character sets
                Dictionary<char, char> hashMap = new Dictionary<char, char>();
                bool isIsomorphicString = true;
                for (int i = 0; i < characterSet1.Length; i++)
                {
                    if (hashMap.ContainsKey(characterSet1[i]))
                    {
                        if (hashMap[characterSet1[i]] == characterSet2[i])
                        {
                            continue;
                        }
                        else
                        {
                            isIsomorphicString = false;
                            break;
                        }
                    }
                    if (hashMap.ContainsValue(characterSet2[i]))
                    {
                        var myKey = hashMap.FirstOrDefault(x => x.Value == characterSet2[i]).Key;
                        if (characterSet1[i] == myKey)
                        {
                            continue;
                        }
                        else
                        {
                            isIsomorphicString = false;
                            break;
                        }
                    }
                    else
                    {
                        hashMap.Add(characterSet1[i], characterSet2[i]);
                    }
                }
                // if unable to remap the characters, then the strings are not Isomorphic
                if (isIsomorphicString)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw new Exception("Exception found in Question 6");
            }
        }

        //Question 7
        /// <summary>
        /// Given a list of the scores of different students, items, where items[i] = [IDi, scorei]
        ///represents one score from a student with IDi, calculate each student's top five average.
        /// Print the answer as an array of pairs result, where result[j] = [IDj, topFiveAveragej] represents the student with IDj and their top five average.Sort result by IDj in increasing order.
        /// A student's top five average is calculated by taking the sum of their top five scores and dividing it by 5 using integer division.
        /// Example 1:
        /// Input: items = [[1, 91], [1,92], [2,93], [2,97], [1,60], [2,77], [1,65], [1,87], [1,100], [2,100], [2,76]]
        /// Output: [[1,87],[2,88]]
        /// Explanation: 
        /// The student with ID = 1 got scores 91, 92, 60, 65, 87, and 100. Their top five average is (100 + 92 + 91 + 87 + 65) / 5 = 87.
        /// The student with ID = 2 got scores 93, 97, 77, 100, and 76. Their top five average is (100 + 97 + 93 + 77 + 76) / 5 = 88.6, but with integer division their average converts to 88.
        /// Example 2:
        /// Input: items = [[1,100],[7,100],[1,100],[7,100],[1,100],[7,100],[1,100],[7,100],[1,100],[7,100]]
        /// Output: [[1,100],[7,100]]
        /// Constraints:
        /// 1 <= items.length <= 1000
        /// items[i].length == 2
        /// 1 <= IDi <= 1000
        /// 0 <= scorei <= 100
        /// For each IDi, there will be at least five scores.
        /// </summary>
        private static void HighFive(int[,] studentScores)
        {
            try
            {
                // building jagged array to process the information
                int rs = studentScores.GetLowerBound(0);
                int re = studentScores.GetUpperBound(0);
                int nr = re - rs + 1;
                int cs = studentScores.GetLowerBound(1);
                int ce = studentScores.GetUpperBound(1);
                int nc = ce - cs + 1;
                int[][] twoDimArray = new int[nr][];
                for (int i = 0; i < nr; i++)
                {
                    twoDimArray[i] = new int[nc];
                    for (int j = 0; j < nc; j++)
                    {
                        twoDimArray[i][j] = studentScores[i + rs, j + cs];
                    }
                }
                // building Dictionary to map students with their scores
                Dictionary<int, int[]> hashMap = new Dictionary<int, int[]>();
                foreach (int[] x in twoDimArray)
                {
                    if (hashMap.ContainsKey(x[0]))
                    {
                        int i = 0;
                        int[] myArr = new int[hashMap[x[0]].Length + 1];
                        foreach (int val in hashMap[x[0]])
                        {
                            myArr[i] = val;
                            i++;
                        }
                        myArr[i] = x[1];
                        hashMap[x[0]] = myArr;
                    }
                    else
                    {
                        hashMap[x[0]] = new int[] { x[1] };
                    }
                }
                // averaging the top five scores
                Dictionary<int, int> averageHashMap = new Dictionary<int, int>();
                foreach (KeyValuePair<int, int[]> x in hashMap)
                {
                    int sum = 0;
                    int[] myArr = x.Value;
                    for (int i = 0; i < 5; i++)
                    {
                        int maximum = myArr.Max();
                        sum += maximum;
                        int numberIndexToBeDeleted = Array.IndexOf(myArr, maximum);
                        List<int> myArr2 = new List<int>(myArr);
                        myArr2.RemoveAt(numberIndexToBeDeleted);
                        myArr = myArr2.ToArray();
                    }
                    averageHashMap[x.Key] = sum / 5;
                }
                // printing Output
                foreach (KeyValuePair<int, int> x in averageHashMap)
                {
                    Console.WriteLine("["+x.Key + "," + x.Value+"]");
                }
            }
            catch (Exception)
            {
                throw new Exception("Exception found in Question 7");
            }
        }

        //Question 8
        /// <summary>
        /// Write an algorithm to determine if a number n is happy.
        ///A happy number is a number defined by the following process:
        ///•	Starting with any positive integer, replace the number by the sum of the squares of its digits.
        ///•	Repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1.
        ///•	Those numbers for which this process ends in 1 are happy.
        ///Return true if n is a happy number, and false if not.
        ///Example 1:
        ///Input: n = 19
        ///Output: true
        ///Explanation:
        ///12 + 92 = 82
        ///82 + 22 = 68
        ///62 + 82 = 100
        ///12 + 02 + 02 = 1
        ///Example 2:
        ///Input: n = 2
        ///Output: false
        ///Constraints:
        ///1 <= n <= 231 - 1
        /// </summary>

        private static bool HappyNumber(int number)
        {
            try
            {
                // converting the string to character srt
                char[] numberInChars = number.ToString().ToCharArray();
                int[] integerFormatOfNumberCharacters = Array.ConvertAll(numberInChars, c => (int)Char.GetNumericValue(c));
                // processing the logic to make the number into single digit
                while (integerFormatOfNumberCharacters.Length > 1)
                {
                    int sum = 0;
                    for (int i = 0; i < integerFormatOfNumberCharacters.Length; i++)
                    {
                        sum += (int)Math.Pow(integerFormatOfNumberCharacters[i], 2);
                    }
                    numberInChars = sum.ToString().ToArray();
                    integerFormatOfNumberCharacters = Array.ConvertAll(numberInChars, c => (int)Char.GetNumericValue(c));
                }
                // Checking if the number is lucky
                if (integerFormatOfNumberCharacters[0] == 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw new Exception("Exception found in Question 8");
            }
        }

        //Question 9
        /// <summary>
        /// Professor Manish is planning to invest in stocks. He has the data of the price of a stock for the next n days.  
        /// Tell him the maximum profit he can earn from the given stock prices.Choose a single day to buy a stock and choose another day in the future to sell the stock for a profit
        /// If you cannot achieve any profit return 0.
        /// Example 1:
        /// Input: prices = [7,1,5,3,6,4]
        /// Output: 5
        /// Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        /// Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.
        /// Example 2:
        /// Input: prices = [7,6,4,3,1]
        /// Output: 0
        ///Explanation: In this case, no transactions are done and the max profit = 0.
        ///Try to solve it in O(n) time complexity.
        /// </summary>

        private static int Stocks(int[] stockPrices)
        {
            try
            {
                int maximum = 0;
                int someValue = -1;
                int n = stockPrices.Length;
                for (int i = 0; i < n; i++)
                {
                    // following if conditions try to bring us minimum stock to buy
                    // if the initiator value is less than zero
                    if (someValue < 0)
                    {
                        someValue = stockPrices[i];
                    }
                    // if the initiator value is greter than zero
                    if (someValue > stockPrices[i])
                    {
                        someValue = stockPrices[i];
                    }
                    // else will help us finding the maximum stock to sell
                    else
                    {
                        if (stockPrices[i] - someValue > maximum)
                        {
                            maximum = stockPrices[i] - someValue;
                        }
                    }
                }
                return maximum;
            }
            catch (Exception)
            {
                throw new Exception("Exception found in Question 9");
            }
        }

        //Question 10
        /// <summary>
        /// Professor Clinton is climbing the stairs in the Muma College of Business. He generally takes one or two steps at a time.
        /// One day he came across an idea and wanted to find the total number of unique ways that he can climb the stairs. Help Professor Clinton.
        /// Print the number of unique ways. 
        /// Example 1:
        ///Input: n = 2
        ///Output: 2
        ///Explanation: There are two ways to climb to the top.
        ///1. 1 step + 1 step
        ///2. 2 steps
        ///Example 2:
        ///Input: n = 3
        ///Output: 3
        ///Explanation: There are three ways to climb to the top.
        ///1. 1 step + 1 step + 1 step
        ///2. 1 step + 2 steps
        ///3. 2 steps + 1 step
        ///Hint : Use the concept of Fibonacci series.
        /// </summary>

        private static void Stairs(int steps)
        {
            try
            {
                int number = steps + 1;
                int[] result = new int[number + 1];
                result[0] = 0;
                result[1] = 1;
                // applying Fibonacci logic to find the number of ways to walk the steps
                for (int i = 2; i <= number; i++)
                {
                    result[i] = result[i - 2] + result[i - 1];
                }
                Console.WriteLine(result[number]);
            }
            catch (Exception)
            {
                throw new Exception("Exception found in Question 10");
            }
        }
    }
}
