using System;
using System.Collections.Generic;

namespace SpinLock
{
    class SpinLockAlgorithm
    {
        public int StepSize { get; }
        private int _currentPosition;         // 0-based position in the list

        private IList<int> _items = new List<int>();

        public SpinLockAlgorithm(int stepSize)
        {
            StepSize = stepSize;
            _items.Add(0);
            _currentPosition = 0;
        }

        public int GetSolutionPart1(int numberOfTimes)
        {
            for (int i = 1; i <= numberOfTimes; i++)
            {
                var newIndex = IndexToInsert(i);
                _items.Insert(newIndex + 1, i);
                _currentPosition = newIndex + 1;
                DisplayItems(i);
            }
            return _items[_currentPosition + 1];
        }

        private void DisplayItems(int lastItem)
        {
            Console.Write($"{lastItem}=>");
            foreach (var item in _items)
            {
                Console.Write($"{item},");
            }
            Console.WriteLine();
        }

        private int IndexToInsert(int itemToInsert)
        {
            return (_currentPosition + StepSize) % _items.Count;  
        }
    }
}
