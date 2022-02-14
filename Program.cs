/*
 * Name: Shubodai Reddy Chalamalla
 * Date: 02/09/2022
 * Description: Solutions for questions in Assignment 2
 * Self Reflection: It took me around 30 hours to finish the assignment. With this assignment I have explored the different datastructures in C# such as: dictionaries, arraylists
 * multi-dimensioinal arrays etc..
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections;

namespace ISM6225_Spring_2022_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 2, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums1, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question2:
            Console.WriteLine("Question 2");
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            string commonWord = MostCommonWord(paragraph, banned);
            Console.WriteLine("Most frequent word is {0}:", commonWord);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 2, 2, 3, 4 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is {0}", lucky_number);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "1807";
            string guess = "7810";
            string hint = GetHint(secret, guess);
            Console.WriteLine("Hint for the guess is :{0}", hint);
            Console.WriteLine();


            //Question 5:
            Console.WriteLine("Question 5");
            string s = "ababcbacadefegdehijhklij";
            List<int> part = PartitionLabels(s);
            Console.WriteLine("Partation lengths are:");
            for (int i = 0; i < part.Count; i++)
            {
                Console.Write(part[i] + "\t");
            }
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] widths = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "abcdefghijklmnopqrstuvwxyz";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string bulls_string10 = "()[]{}";
            bool isvalid = IsValid(bulls_string10);
            if (isvalid)
                Console.WriteLine("Valid String");
            else
                Console.WriteLine("String is not Valid");

            Console.WriteLine();
            Console.WriteLine();


            //Question 8:
            Console.WriteLine("Question 8");
            string[] bulls_string13 = { "gin", "zen", "gig", "msg" };
            int diffwords = UniqueMorseRepresentations(bulls_string13);
            Console.WriteLine("Number of with unique code are: {0}", diffwords);
            Console.WriteLine();
            Console.WriteLine();

            //Question 9:
            Console.WriteLine("Question 9");
            int[,] grid = { { 0, 1, 2, 3, 4 }, { 24, 23, 22, 21, 5 }, { 12, 13, 14, 15, 16 }, { 11, 17, 18, 19, 20 }, { 10, 9, 8, 7, 6 } };
            int time = SwimInWater(grid);
            Console.WriteLine("Minimum time required is: {0}", time);
            Console.WriteLine();

            //Question 10:
            Console.WriteLine("Question 10");
            string word1 = "horse";
            string word2 = "ros";
            int minLen = MinDistance(word1, word2);
            Console.WriteLine("Minimum number of operations required are {0}", minLen);
            Console.WriteLine();

        }

            /*
        
        Question 1:
        Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
        Note: The algorithm should have run time complexity of O (log n).
        Hint: Use binary search
        Example 1:
        Input: nums = [1,3,5,6], target = 5
        Output: 2
        Example 2:
        Input: nums = [1,3,5,6], target = 2
        Output: 1
        Example 3:
        Input: nums = [1,3,5,6], target = 7
        Output: 4
        */
            public static int SearchInsert(int[] nums, int target)
            {
                try
                {
                    int array = 0;
                    int tvalue = nums.Length - 1; 
                    int output = -1;
                    while (array <= tvalue)
                    {
                        //using binary search
                        int k = (array + tvalue) / 2;      //to fetch the value of the middle element
                        if (target == nums[k])
                        {
                            return k; // to check if the value matches the middle element
                        }
                        else if (nums[k] > target)
                        {
                            //if target value is samller than middle element, iterating to fetch the index to fit the target
                            tvalue = k - 1;
                            output = k;
                        }
                        else
                        {
                            array = k + 1;
                            output = k + 1;
                        }
                    }

                    return output;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            /*

       Question 2

       Given a string paragraph and a string array of the banned words banned, return the most frequent word that is not banned. It is guaranteed there is at least one word that is not banned, and that the answer is unique.
       The words in paragraph are case-insensitive and the answer should be returned in lowercase.
       Example 1:
       Input: paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.", banned = ["hit"]
       Output: "ball"
       Explanation: "hit" occurs 3 times, but it is a banned word. "ball" occurs twice (and no other word does), so it is the most frequent non-banned word in the paragraph. 
       Note that words in the paragraph are not case sensitive, that punctuation is ignored (even if adjacent to words, such as "ball,"), and that "hit" isn't the answer even though it occurs more because it is banned.
       Example 2:
       Input: paragraph = "a.", banned = []
       Output: "a"
       */
            public static string MostCommonWord(string paragraph, string[] banned)
            {
                try
                {
                    paragraph = paragraph.ToLower();  // converting all the words into lower case
                    paragraph = paragraph.Replace(',', ' ');  //replacing special characters with space
                    paragraph = paragraph.Replace('.', ' ');
                    paragraph = paragraph.Trim(); // removing the extra spaces
                    Console.WriteLine(paragraph);
                    string[] ipsplit = paragraph.Split(' '); // splitting the input 
                    int l = ipsplit.Length;
                    IDictionary<string, int> count = new Dictionary<string, int>(); // create dictionary to store the words which are keys and count as values  
                    for (int i = 0; i < l; i++)
                    {
                        if (count.ContainsKey(ipsplit[i]))
                        {
                            // increasing the count if the word repeats
                            count[ipsplit[i]]++;
                        }
                        else
                        {
                            // adding the new word
                            count.Add(ipsplit[i], 1);
                        }
                        for (int j = 0; j < banned.Length; j++)
                        {
                            if (ipsplit[i] == banned[j])
                            {
                                //to remove the banned word frpm the dictionary
                                count.Remove(ipsplit[i]);
                            }
                        }
                    }
                    int maxvalue = 0;
                    string output = "";
                    foreach (KeyValuePair<string, int> kvp in count)
                    {
                        if (maxvalue < kvp.Value) // to fetch the key with max count from dictionary
                        {
                            // getting the key using value
                            maxvalue = kvp.Value;
                            output = kvp.Key;
                        }
                    }
                    return output;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            /*
        Question 3:
        Given an array of integers arr, a lucky integer is an integer that has a frequency in the array equal to its value.
        Return the largest lucky integer in the array. If there is no lucky integer return -1.
 
        Example 1:
        Input: arr = [2,2,3,4]
        Output: 2
        Explanation: The only lucky number in the array is 2 because frequency[2] == 2.
        Example 2:
        Input: arr = [1,2,2,3,3,3]
        Output: 3
        Explanation: 1, 2 and 3 are all lucky numbers, return the largest of them.
        Example 3:
        Input: arr = [2,2,2,3,3]
        Output: -1
        Explanation: There are no lucky numbers in the array.
         */

            public static int FindLucky(int[] arr)
            {
                try
                {
                    int len1 = arr.Length; //to create a new interger to store value of array length
                    Array.Sort(arr);
                    ArrayList output = new ArrayList();
                    int[] array1 = arr.Distinct().ToArray(); //to fetch distinct values from input array    
                    int[] len2 = new int[array1.Length];
                    for (int i = 0; i < len2.Length; i++)
                    {
                        len2[i] = arr.Count(s => s == array1[i]); //to fetch count of numbers
                    }
                    for (int i = 0; i < len2.Length; i++)
                    {
                        if (array1[i] == len2[i]) //comparing the values
                        {
                            output.Add(array1[i]);
                        }
                    }
                    int final = -1;
                    if (output.Count != 0) // if array list is not equal to 0
                    {
                        final = (int)output[output.Count - 1]; // to return the final value from array list
                    }
                    return final;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            /*
        
        Question 4:
        You are playing the Bulls and Cows game with your friend.
        You write down a secret number and ask your friend to guess what the number is. When your friend makes a guess, you provide a hint with the following info:
        •	The number of "bulls", which are digits in the guess that are in the correct position.
        •	The number of "cows", which are digits in the guess that are in your secret number but are located in the wrong position. Specifically, the non-bull digits in the guess that could be rearranged such that they become bulls.
        Given the secret number secret and your friend's guess guess, return the hint for your friend's guess.
        The hint should be formatted as "xAyB", where x is the number of bulls and y is the number of cows. Note that both secret and guess may contain duplicate digits.
 
        Example 1:
        Input: secret = "1807", guess = "7810"
        Output: "1A3B"
        Explanation: Bulls relate to a '|' and cows are underlined:
        "1807"
          |
        "7810"
        */
            public static string GetHint(string secret, string guess)
            {
                try
                {
                    string sec = "";
                    string gue = "";
                    int bull = 0; //no of bulls
                    int cow = 0; //no of cows
                    for (int i = 0; i < secret.Length; i++)
                    {
                        if (secret[i] == guess[i]) // incrementing the count of bulls if the count of guess matches
                    {
                            bull = bull + 1;
                        }
                        else
                        {
                                                // adding the elements to the resultant string
                            sec = sec + secret[i]; 
                            gue = gue + guess[i];
                        }
                    }
                    foreach (char a in gue)   //looping over gue string to check how many matches are made
                {
                        int flag = 0;
                        for (int j = 0; j < sec.Length; j++)
                        {
                            if (a == sec[j] & flag == 0)
                            {
                                sec = sec.Remove(j, 1);
                                cow = cow + 1;  //incrementing the no. of cows count if the condition is satisfied
                            flag = 1;
                            }
                        }
                    }
                    string final = bull + "A" + cow + "B";
                    return final;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            /*
        Question 5:
        You are given a string s. We want to partition the string into as many parts as possible so that each letter appears in at most one part.
        Return a list of integers representing the size of these parts.
        Example 1:
        Input: s = "ababcbacadefegdehijhklij"
        Output: [9,7,8]
        Explanation:
        The partition is "ababcbaca", "defegde", "hijhklij".
        This is a partition so that each letter appears in at most one part.
        A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits s into less parts.
        */
            public static List<int> PartitionLabels(string s)
            {
                try
                {
                    int lg = s.Length;
                    int count = 0; //storing the value of overall loop count
                    List<int> final = new List<int>();
                    while (count < s.Length) //looping to complete input string
                    {
                        int l2 = s.LastIndexOf(s[count]); //to fetch the last occurance of the character
                        char x = s[count];
                        for (int i = 0; i <= l2; i++)
                        {
                            char y = s[i];
                            if (y != x)
                            {
                                if (s.LastIndexOf(y) > l2)
                                {
                                    l2 = s.LastIndexOf(y); //updating the break point of the inner loop
                                }
                            }
                            count = i + 1;//storing index of last value in "count" which will be used to fetch the next character after this loop ends
                        }
                        int diff = count - final.Sum();//getting the difference bw both values(string length)
                        final.Add(diff); 
                    }
                    return final;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            /*
        Question 6
        You are given a string s of lowercase English letters and an array widths denoting how many pixels wide each lowercase English letter is. Specifically, widths[0] is the width of 'a', widths[1] is the width of 'b', and so on.
        You are trying to write s across several lines, where each line is no longer than 100 pixels. Starting at the beginning of s, write as many letters on the first line such that the total width does not exceed 100 pixels. Then, from where you stopped in s, continue writing as many letters as you can on the second line. Continue this process until you have written all of s.
        Return an array result of length 2 where:
             •	result[0] is the total number of lines.
             •	result[1] is the width of the last line in pixels.
 
        Example 1:
        Input: widths = [10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], s = "abcdefghijklmnopqrstuvwxyz"
        Output: [3,60]
        Explanation: You can write s as follows:
                     abcdefghij  	 // 100 pixels wide
                     klmnopqrst  	 // 100 pixels wide
                     uvwxyz      	 // 60 pixels wide
                     There are a total of 3 lines, and the last line is 60 pixels wide.
         Example 2:
         Input: widths = [4,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], 
         s = "bbbcccdddaaa"
         Output: [2,4]
         Explanation: You can write s as follows:
                      bbbcccdddaa  	  // 98 pixels wide
                      a           	 // 4 pixels wide
                      There are a total of 2 lines, and the last line is 4 pixels wide.
         */

            public static List<int> NumberOfLines(int[] widths, string s)
            {
                try
                {
                    int sum = 0;
                    int n = 0;
                    int count = 1;
                    for (int i = 0; i < s.Length; i++) //adding keys to dictionary
                    {
                        n = widths[s[i] - 97];
                        sum = sum + n;
                        if (sum > 100)
                        {
                            // assigning the n value to sum
                            sum = n;
                            // incrementing the count by 1
                            count = count + 1;
                        }
                    }
                    List<int> output = new List<int>();
                    output.Add(count);
                    output.Add(sum);
                    return output;
                }
                catch (Exception)
                {
                    throw;   
                }
            }
            /*
        
        Question 7:
        Given a string bulls_string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        An input string is valid if:
            1.	Open brackets must be closed by the same type of brackets.
            2.	Open brackets must be closed in the correct order.
 
        Example 1:
        Input: bulls_string = "()"
        Output: true
        Example 2:
        Input: bulls_string  = "()[]{}"
        Output: true
        Example 3:
        Input: bulls_string  = "(]"
        Output: false
        */
            public static bool IsValid(string bulls_string10)
            {
                try
                {
                    int len = bulls_string10.Length;
                    ArrayList check = new ArrayList();
                    Dictionary<string, string> lookup = new Dictionary<string, string>(); //creating dictionary to store left & right b as keys & values
                    lookup.Add("}", "{");
                    lookup.Add("]", "[");
                    lookup.Add(")", "(");
                    int newcount = -1; //creating a new variable to store sz of arraylist
                    for (int i = 0; i < len; i++)
                    {
                        string s1 = bulls_string10[i].ToString();
                        if (lookup.ContainsValue(s1)) // to check if char is in the dictionary or not
                        {
                            check.Add(s1);
                            newcount = newcount + 1; //fetch current size of arraylist
                        }
                        else if (lookup.ContainsKey(s1) & newcount != -1)
                        {
                            if (lookup[s1] == check[newcount].ToString())
                            {
                                check.RemoveAt(newcount); //to remove the character at index from arraylist
                                newcount = newcount - 1;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else if (newcount == -1)
                        {
                            return false;
                        }
                    }
                    if (newcount != -1)
                    {
                        return false;
                    }
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            /*
        Question 8
       International Morse Code defines a standard encoding where each letter is mapped to a series of dots and dashes, as follows:
       •	'a' maps to ".-",
       •	'b' maps to "-...",
       •	'c' maps to "-.-.", and so on.
       For convenience, the full table for the 26 letters of the English alphabet is given below:
       [".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."]
       Given an array of strings words where each word can be written as a concatenation of the Morse code of each letter.
           •	For example, "cab" can be written as "-.-..--...", which is the concatenation of "-.-.", ".-", and "-...". We will call such a concatenation the transformation of a word.
       Return the number of different transformations among all words we have.

       Example 1:
       Input: words = ["gin","zen","gig","msg"]
       Output: 2
       Explanation: The transformation of each word is:
       "gin" -> "--...-."
       "zen" -> "--...-."
       "gig" -> "--...--."
       "msg" -> "--...--."
       There are 2 different transformations: "--...-." and "--...--.".
       */

            public static int UniqueMorseRepresentations(string[] words)
            {
                try
                {
                    string[] mcode = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
                    int len1 = words.Length; // to fetch the length of input
                    string[] final = new string[len1];
                    for (int i = 0; i < len1; i++) //looping all the words
                    {
                        string snew = words[i];
                        int len2 = snew.Length; //to fetch length of each word
                        string p = "";
                        for (int j = 0; j < len2; j++) //looping all the characters
                        {
                            int y = snew[j] - 97;
                            p = p + mcode[y];
                        }
                        final[i] = p; 
                    }
                    int total = final.Distinct().Count(); // to store count of total combinations   
                    return total;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            /*
        
        Question 9:
        You are given an n x n integer matrix grid where each value grid[i][j] represents the elevation at that point (i, j).
        The rain starts to fall. At time t, the depth of the water everywhere is t. You can swim from a square to another 4-directionally adjacent square if and only if the elevation of both squares individually are at most t. You can swim infinite distances in zero time. Of course, you must stay within the boundaries of the grid during your swim.
        Return the least time until you can reach the bottom right square (n - 1, n - 1) if you start at the top left square (0, 0).
        Example 1:
        Input: grid = [[0,1,2,3,4],[24,23,22,21,5],[12,13,14,15,16],[11,17,18,19,20],[10,9,8,7,6]]
        Output: 16
        Explanation: The final route is shown.
        We need to wait until time 16 so that (0, 0) and (4, 4) are connected.
        */

            public static int SwimInWater(int[,] grid)
            {
                try
                {
                    //write your code here.
                    return 0;
                }
                catch (Exception)
                {

                    throw;
                }
            }

            /*

            Question 10:
            Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.
            You have the following three operations permitted on a word:
            •	Insert a character
            •	Delete a character
            •	Replace a character
             Note: Try to come up with a solution that has polynomial runtime, then try to optimize it to quadratic runtime.
            Example 1:
            Input: word1 = "horse", word2 = "ros"
            Output: 3
            Explanation: 
            horse -> rorse (replace 'h' with 'r')
            rorse -> rose (remove 'r')
            rose -> ros (remove 'e')
            */

            public static int MinDistance(string word1, string word2)
            {
                try
                {
                    //write your code here.
                    return 0;

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }

        
  
