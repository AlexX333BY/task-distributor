using System;
using System.Collections.Generic;

namespace TaskDistributor
{
    public static class TaskDistributor
    {
        public static Dictionary<string, List<int>> Distribute(IList<string> people, int tasksCount)
        {
            Dictionary<string, List<int>> result = new Dictionary<string, List<int>>(people.Count);

            if (people.Count != 0)
            {
                int minTasksCount = tasksCount / people.Count;
                int evenlyDistributedTasks = minTasksCount * people.Count;

                foreach (string person in people)
                {
                    result[person] = new List<int>();
                }

                List<string> copiedPeople = new List<string>(people);
                Random random = new Random();
                string chosenPerson;

                for (int i = 0; i < evenlyDistributedTasks; ++i)
                {
                    chosenPerson = copiedPeople[random.Next(copiedPeople.Count)];
                    result[chosenPerson].Add(i + 1);

                    if (result[chosenPerson].Count == minTasksCount)
                    {
                        copiedPeople.Remove(chosenPerson);
                    }
                }

                if (evenlyDistributedTasks != tasksCount)
                {
                    copiedPeople = new List<string>(people);

                    for (int i = evenlyDistributedTasks; i < tasksCount; ++i)
                    {
                        chosenPerson = copiedPeople[random.Next(copiedPeople.Count)];
                        result[chosenPerson].Add(i + 1);
                        copiedPeople.Remove(chosenPerson);
                    }
                }
            }

            return result;
        }
    }
}
