using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2016
{
    internal class DayEleven
    {
        public static void Solution()
        {
            var testInput = InputOutputHelper.GetInput(true, "11");
            PartOne(true, testInput);

            var input = InputOutputHelper.GetInput(false, "11");
            PartOne(false, input);
        }

        public static void PartOne(bool isTest, string[] input)
        {
            var initialState = ParseInput(input);
            var result = BFS(initialState);
            InputOutputHelper.WriteOutput(isTest, result);
        }

        private static State ParseInput(string[] input)
        {
            var floors = new List<List<string>>();
            for (int i = 0; i < 4; i++)
            {
                floors.Add(new List<string>());
            }

            for (int i = 0; i < input.Length; i++)
            {
                var parts = input[i].Split(new[] { "contains" }, StringSplitOptions.None)[1]
                                    .Replace("a ", "")
                                    .Replace("and ", "")
                                    .Replace(",", "")
                                    .Replace(".", "")
                                    .Trim()
                                    .Split(' ');

                for (int j = 0; j < parts.Length; j += 2)
                {
                    floors[i].Add(parts[j] + parts[j + 1][0]);
                }
            }

            return new State(0, floors);
        }

        private static int BFS(State initialState)
        {
            var queue = new Queue<(State state, int steps)>();
            var visited = new HashSet<State>();

            queue.Enqueue((initialState, 0));
            visited.Add(initialState);

            while (queue.Count > 0)
            {
                var (currentState, steps) = queue.Dequeue();

                if (currentState.IsGoalState())
                {
                    return steps;
                }

                foreach (var nextState in currentState.GetValidMoves())
                {
                    if (!visited.Contains(nextState))
                    {
                        queue.Enqueue((nextState, steps + 1));
                        visited.Add(nextState);
                    }
                }
            }

            return -1; // Should never reach here if there's a valid solution
        }
    }
}

internal class State
{
    public int Elevator { get; }
    public List<List<string>> Floors { get; }

    public State(int elevator, List<List<string>> floors)
    {
        Elevator = elevator;
        Floors = floors.Select(f => new List<string>(f)).ToList();
    }

    public bool IsGoalState()
    {
        return Floors.Take(3).All(f => f.Count == 0);
    }

    public IEnumerable<State> GetValidMoves()
    {
        var currentFloor = Floors[Elevator];
        var items = currentFloor.ToList();

        for (int i = 0; i < items.Count; i++)
        {
            for (int j = i; j < items.Count; j++)
            {
                var moveItems = new List<string> { items[i] };
                if (i != j) moveItems.Add(items[j]);

                foreach (var nextFloor in GetNextFloors())
                {
                    var newFloors = Floors.Select(f => new List<string>(f)).ToList();
                    newFloors[Elevator].RemoveAll(moveItems.Contains);
                    newFloors[nextFloor].AddRange(moveItems);

                    if (IsValidState(newFloors))
                    {
                        yield return new State(nextFloor, newFloors);
                    }
                }
            }
        }
    }

    private IEnumerable<int> GetNextFloors()
    {
        if (Elevator > 0) yield return Elevator - 1;
        if (Elevator < 3) yield return Elevator + 1;
    }

    private bool IsValidState(List<List<string>> floors)
    {
        foreach (var floor in floors)
        {
            var chips = floor.Where(item => item[1] == 'M').ToList();
            var generators = floor.Where(item => item[1] == 'G').ToList();

            if (generators.Count > 0 && chips.Any(chip => !generators.Contains(chip[0] + "G")))
            {
                return false;
            }
        }

        return true;
    }

    public override bool Equals(object obj)
    {
        if (obj is State other)
        {
            return Elevator == other.Elevator && Floors.SequenceEqual(other.Floors, new ListComparer());
        }

        return false;
    }

    public override int GetHashCode()
    {
        int hash = Elevator;
        foreach (var floor in Floors)
        {
            foreach (var item in floor)
            {
                hash = hash * 31 + item.GetHashCode();
            }
        }
        return hash;
    }

    private class ListComparer : IEqualityComparer<List<string>>
    {
        public bool Equals(List<string> x, List<string> y)
        {
            return x.SequenceEqual(y);
        }

        public int GetHashCode(List<string> obj)
        {
            int hash = 17;
            foreach (var item in obj)
            {
                hash = hash * 31 + item.GetHashCode();
            }
            return hash;
        }
    }
}