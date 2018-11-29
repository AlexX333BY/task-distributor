﻿using System;
using System.Collections.Generic;

namespace TaskDistributor
{
    public static class TaskDistributor
    {
        public static Dictionary<string, List<uint>> Distribute(IList<string> people, uint tasksCount)
        {
            Dictionary<string, List<uint>> result = new Dictionary<string, List<uint>>(people.Count);

            if (people.Count != 0)
            {
                uint minTasksCount = (uint)(tasksCount / people.Count), maxTasksCount = minTasksCount;
                if (tasksCount % people.Count != 0)
                {
                    ++maxTasksCount;
                }

                foreach (string person in people)
                {
                    result[person] = new List<uint>();
                }

                List<string> copiedPeople = new List<string>(people);
                Random random = new Random();
                string chosenPerson;

                for (uint i = 0; i < tasksCount; ++i)
                {
                    chosenPerson = copiedPeople[random.Next(copiedPeople.Count)];
                    result[chosenPerson].Add(i + 1);

                    if (result[chosenPerson].Count == maxTasksCount)
                    {
                        copiedPeople.Remove(chosenPerson);
                    }
                }
            }

            return result;
        }
    }
}
