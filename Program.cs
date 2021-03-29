﻿using System;

namespace WorldTour
{
    class Program
    {
        static void Main(string[] args)
        {
            string lineStops = Console.ReadLine();
                

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Travel")
                {
                    break;
                }

                string[] parts = line.Split(':', StringSplitOptions.RemoveEmptyEntries);

                string comand = parts[0];

                if (comand == "Add Stop")
                {
                    //Add Stop:{ index}:{ string}

                    int givenIdx = int.Parse(parts[1]);
                    string strToInsert = parts[2];

                    if (givenIdx >= 0 && givenIdx <= lineStops.Length-1)
                    {
                        lineStops = lineStops.Insert(givenIdx, strToInsert);
                        Console.WriteLine(lineStops);
                    }
                }
                else if (comand == "Remove Stop")
                {
                    // Remove Stop:{start_index}:{end_index} 
                    int startIdx = int.Parse(parts[1]);
                    int endIdx = int.Parse(parts[2]);

                    if (startIdx >= 0 && startIdx <= lineStops.Length 
                        && endIdx >= 0 && endIdx <= lineStops.Length)
                    {
                        lineStops = lineStops.Remove(startIdx, (endIdx - startIdx + 1));
                        Console.WriteLine(lineStops);
                    }
                }
                else if (comand == "Switch")
                {
                    // Switch:{old_string}:{new_string} 
                    string oldStr = parts[1];
                    string newStr = parts[2];

                    while (true)
                    {
                        if (!lineStops.Contains(oldStr))
                        {
                            break;
                        }

                        lineStops = lineStops.Replace(oldStr, newStr);
                    }

                    Console.WriteLine(lineStops);
                }                
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {lineStops}");
        }
    }
}