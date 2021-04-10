using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FootBall
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read the football.dat file
            StreamReader scoreReader = new StreamReader(@"../../app_data/football.dat");
            string strScores = scoreReader.ReadToEnd().Replace("\r\n", "\n");
            //split the string of rows into array of rows by new line character
            string[] arrScores = strScores.Split(new char[] { '\n' });
            //Read the each line of an array
            int smallestDiff = int.MaxValue;
            string smallestDiffTeam = "";
            for (int row=1; row < arrScores.Length-1; row++)
            {
                string[] arrLine = arrScores[row].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                //condition to check both for and against exists
                if (arrLine.Length > 8)
                {
                    //check there is a valid number in the Against and For columns
                    bool forIsNumber = int.TryParse(arrLine[6], out int forScore);
                    bool againstIsNumber = int.TryParse(arrLine[8], out int againstScore);  
                    //if for and against scores are valid numbers
                    if (forIsNumber && againstIsNumber)
                    {
                        int goalDiff = Math.Abs(forScore - againstScore);                        
                        if (smallestDiff > goalDiff)
                        {
                            smallestDiff = goalDiff;
                            smallestDiffTeam = arrLine[1];
                        }
                    }
                }
            }
            Console.WriteLine("The team scored with smallest for and against difference is " + smallestDiffTeam);
            Console.ReadKey();
        }
    }
}
