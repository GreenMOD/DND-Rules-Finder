using System;
using System.Collections.Generic;
using System.IO;
namespace Rules_Lawyer
{
    class Program
    {
        static void Main(string[] args)
        {


                List<string> foundSentences = new List<string>();




                Menu(foundSentences);


            }
            /// <summary>
            /// Prompts the user to enter a word they would like to search for and calls findDetail
            /// </summary>
            /// <param name="foundSentences">Holds all sentences that include a specified word</param>
            static public void findSubject(List<string> foundSentences)
            {
                StreamReader rulesLawyer = new StreamReader(File.Open("DND_RULES.txt", FileMode.Open));
                Console.WriteLine("Please input subject you would like to know about");
                string subject = Console.ReadLine();



                while (rulesLawyer.EndOfStream != true)
                {
                    string currentLine = rulesLawyer.ReadLine();

                    if (currentLine.Contains(subject))
                    {

                        foundSentences.Add(currentLine);

                    }





                }
                if (foundSentences.Count <= 0)
                {
                    Console.WriteLine("No Matches Please enter again");
                    rulesLawyer.Close();
                    findSubject(foundSentences);
                }
                else
                {
                    Console.WriteLine("Found: " + foundSentences.Count);
                    findDetail(foundSentences);
                }




            }
            /// <summary>
            /// Prompts user to enter "Y" or "N" deciding whether to do a further extended search and outputs matching sentences
            /// </summary>
            /// <param name="foundSentences">Holds all sentences that include a specified word</param>
            static public void findDetail(List<string> foundSentences)

            {
                Console.WriteLine("Would you like to add more detail (Y or N)");
                string response = Console.ReadLine();
                if (response == "Y")
                {
                    Console.WriteLine("Please enter further infomation that you are searching about");
                    string detail = Console.ReadLine();

                    for (int i = 0; i < foundSentences.Count - 1; i++)
                    {
                        if (foundSentences[i].Contains(detail))
                        {
                            Console.WriteLine(foundSentences[i].ToString());
                        }
                    }

                }
                else if (response == "N")
                {
                    OutputAll(foundSentences);
                }
                else
                {
                    Console.WriteLine("Your response must be Y or N");
                    findDetail(foundSentences);
                }
            }

            public static void Menu(List<string> foundSentences)
            {
                Console.WriteLine("Hello and Welcome to the DND portal");
                Console.WriteLine("Functions");
                Console.WriteLine("1. Find subject");
                Console.WriteLine("2. Find Spell");
                Console.WriteLine("3. Roll D20");
                string userAction = Console.ReadLine();
                switch (userAction)
                {
                    case "1":
                        findSubject(foundSentences);
                        break;
                    case "2":
                        Console.WriteLine("This is currently unavaliable");
                        break;
                    case "3":
                        RollD20();
                        break;
                    default:
                        Console.WriteLine("Error please enter again");
                        Console.Clear();
                        Menu(foundSentences);
                        break;
                }
            }
            public void findSpell()
            {
                StreamReader rulesLawyer = new StreamReader(File.Open("DND_RULES.txt", FileMode.Open));

                Console.WriteLine("Enter name of spell");
                string spell = Console.ReadLine();
                while (!rulesLawyer.ReadLine().Contains(spell))
                {
                    rulesLawyer.ReadLine();
                }


            }
            /// <summary>
            /// Outputs all values in a list.
            /// </summary>
            /// <param name="foundSentences">Holds all sentences that include a specified word</param>
            public static void OutputAll(List<string> foundSentences)
            {
                for (int i = 0; i < foundSentences.Count; i++)
                {
                    Console.WriteLine("Start OF PASSAGE " + i);
                    Console.WriteLine(foundSentences[i]);
                    Console.WriteLine("END OF PASSAGE " + i);
                }
            }
            /// <summary>
            /// Outputs a random number from 0 - 20
            /// </summary>
            public static void RollD20()
            {
                Random rand = new Random();

                Console.WriteLine(rand.Next(0, 20));
            }
        }
    }





      