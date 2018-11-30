using System;
using System.Collections.Generic;

namespace TaskDistributor
{
    public static class TaskDistributor
    {
        public static Dictionary<string, List<int>> Distribute(IList<string> people, int tasksCount)
        {
            if (people == null)
            {
                throw new ArgumentNullException(nameof(people), "People list shouldn't be null");
            }
            if (tasksCount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(tasksCount), "Tasks count should be non-negative");
            }

            Dictionary<string, List<int>> result = new Dictionary<string, List<int>>(people.Count);

            if (people.Count != 0)
            {
                int minTasksCount = tasksCount / people.Count;
                int evenlyDistributedTasks = minTasksCount * people.Count;

                foreach (string person in people)
                {
                    result[person] = new List<int>(minTasksCount);
                }

                if (tasksCount != 0)
                {
                    List<string> copiedPeople = new List<string>(people);
                    Random random = new Random();
                    string chosenPerson;

                    for (int i = 1; i <= evenlyDistributedTasks; ++i)
                    {
                        chosenPerson = copiedPeople[random.Next(copiedPeople.Count)];
                        result[chosenPerson].Add(i);

                        if (result[chosenPerson].Count == minTasksCount)
                        {
                            copiedPeople.Remove(chosenPerson);
                        }
                    }

                    if (evenlyDistributedTasks != tasksCount)
                    {
                        copiedPeople = new List<string>(people);

                        for (int i = evenlyDistributedTasks + 1; i <= tasksCount; ++i)
                        {
                            chosenPerson = copiedPeople[random.Next(copiedPeople.Count)];
                            result[chosenPerson].Add(i);
                            copiedPeople.Remove(chosenPerson);
                        }
                    }
                }
            }

            return result;
        }
    }
}
