using System;
using System.Collections.Generic;
using System.IO;

namespace Solution
{

    public class NotesStore
    {
        private Dictionary<string, List<string>> noteMap = new Dictionary<string, List<string>>();
        public NotesStore() { }

        public void AddNote(String state, String name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Name cannot be empty");
            }
            validateState(state);
            if (noteMap.ContainsKey(state))
            {
                noteMap[state].Add(name);
                return;
            }
            noteMap.Add(state, new List<string>() { name });
        }

        public List<String> GetNotes(String state)
        {
            validateState(state);
            if (noteMap.ContainsKey(state))
            {
                return noteMap[state];
            }

            return new List<string>();
        }

        private void validateState(string state)
        {
            if (string.IsNullOrEmpty(state) || (state != "active" && state != "completed" && state != "others"))
            {
                throw new Exception($"Invalid state {state}");
            }
        }
    }

    public class Solution
    {
        public static void Main()
        {
            var notesStoreObj = new NotesStore();
            var n = int.Parse(Console.ReadLine());
            for (var i = 0; i < n; i++)
            {
                var operationInfo = Console.ReadLine().Split(' ');
                try
                {
                    if (operationInfo[0] == "AddNote")
                        notesStoreObj.AddNote(operationInfo[1], operationInfo.Length == 2 ? "" : operationInfo[2]);
                    else if (operationInfo[0] == "GetNotes")
                    {
                        var result = notesStoreObj.GetNotes(operationInfo[1]);
                        if (result.Count == 0)
                            Console.WriteLine("No Notes");
                        else
                            Console.WriteLine(string.Join(",", result));
                    }
                    else
                    {
                        Console.WriteLine("Invalid Parameter");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
        }
    }
}