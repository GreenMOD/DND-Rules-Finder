using System;
using System.Collections.Generic;
using System.IO;
namespace Rules_Lawyer
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader rulesLawyer = new StreamReader(File.Open("DND_RULES.txt", FileMode.Open));
            List<string> Sentences = new List<string>();
            while (rulesLawyer.EndOfStream != true)
            {
                string currentLine = rulesLawyer.ReadLine();



                Sentences.Add(currentLine);

            }
            rulesLawyer.Close();





            
            List<string> foundSentences = new List<string>();

          


                Menu(Sentences);


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

            public static void Menu(List<string> Sentences)
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
                        UpdateSearch(Sentences);
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
                        Menu(Sentences);
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
        public static void UpdateSearch(List<string>Sentences)
        {
            List<string> foundSentences = new List<string>();
            List<int> foundAt = new List<int>();
            StreamReader rulesLawyer = new StreamReader(File.Open("DND_RULES.txt", FileMode.Open));
            Console.WriteLine("Please input subject you would like to know about");
            int count = 0;
            string subject = Console.ReadLine();

            for (int i = 0; i < Sentences.Count; i++)
            {
                if (Sentences[i].Contains(subject))
                {
                    foundSentences.Add(Sentences[i]);
                    foundAt.Add(i);
                    count++;
                }
            }
                
            Console.WriteLine("Found "+ foundSentences.Count);
            Console.WriteLine("Please enter the number at which you would like to start reading at:");
           
            for (int i = 0; i < foundSentences.Count; i++)
            {
                Console.WriteLine(i+ ": "+ foundSentences[i]);
            }
            int numIndex = int.Parse(Console.ReadLine());
            while (numIndex < 0 || numIndex > foundSentences.Count)
            {
                Console.WriteLine("Error please enter number to start reading at again.");
                numIndex = int.Parse(Console.ReadLine());
            }
            Console.WriteLine(foundSentences[numIndex].ToString());
              numIndex= foundAt[numIndex];
            ReadMore(Sentences,numIndex);
           }
        public static void ReadMore(List<string> Sentences, int start)
        {
            Console.WriteLine("Would you like to read more?");
            string response = Console.ReadLine();
            if (response == "Y")
            {
                Console.WriteLine("Please enter number of sentences you want to read for.");
                int numSentences = int.Parse(Console.ReadLine());

                for (int i = 0; i < numSentences; i++)
                {
                    Console.WriteLine(Sentences[i+start].ToString());
                }
            }
            else if (response == "N")
            {
                Menu(Sentences);
            }
            else
            {
                Console.WriteLine("Your response must be Y or N");
                ReadMore(Sentences, start);
            }








        }
        }
    }





      