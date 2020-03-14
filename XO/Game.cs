using System;
using System.Collections.Generic;
using System.Text;

namespace XO
{
    class Game
    {
        private int _count = 0;
        private char[] _log = new char[9];
        private Dictionary<int, int> _coordinates = new Dictionary<int, int>()
            {
                { 1, 21 },
                { 2, 61 },
                { 3, 101 },
                { 4, 23 },
                { 5, 63 },
                { 6, 103 },
                { 7, 25 },
                { 8, 65 },
                { 9, 105 },
            };
        public void GameFieldView()
        {
            string vLine = new string('-', 13);
            string hLine = $"|   |   |   |";
            Console.WriteLine($"{vLine}\n{hLine}\n{vLine}\n{hLine}\n{vLine}\n{hLine}\n{vLine}");
            Console.WriteLine("Choose a cell (1-9):");

        }
        public void GetStep(int number)
        {
            _findCoordinates(number, out int X, out int Y);
            Console.SetCursorPosition(X, Y);

            Console.WriteLine(_count % 2 == 0 ? "X" : "O");
            _setHistory(number - 1);

            _count++;

        }
        public void Gameplay()
        {
            GameFieldView();

            while (true)
            {
                GetStep(int.Parse(Console.ReadLine()));
                if (_count > 4)
                {
                    if (GameLogic(out char value))
                    {
                        Console.WriteLine($"Win {value}");
                        break;
                    }
                }
                if (_count == 8)
                {
                    Console.WriteLine("No win");
                    break;
                }

                //set cursor to default
                Console.SetCursorPosition(0, 8 + _count);

            }
        }
        public bool GameLogic(out char value)
        {
            if (_log[4] != 0 && _log[4] == _log[0] && _log[4] == _log[8]
                             || _log[4] == _log[2] && _log[4] == _log[6]
                             || _log[4] == _log[3] && _log[4] == _log[5]
                             || _log[4] == _log[1] && _log[4] == _log[7])
            {
                value = _log[4];
                return true;
            }
            else if (_log[0] != 0 && _log[0] == _log[1] && _log[0] == _log[2]
                                  || _log[0] == _log[3] && _log[0] == _log[6])
            {
                value = _log[0];
                return true;
            }
            else if (_log[8] != 0 && _log[8] == _log[6] && _log[8] == _log[7]
                                  || _log[8] == _log[2] && _log[8] == _log[5])
            {
                value = _log[8];
                return true;
            }
            value = ' ';
            return false;
        }

        private void _setHistory(int number)
        {
            _log[number] = _count % 2 == 0 ? 'X' : 'O';
        }
        private void _findCoordinates(int a, out int X, out int Y)
        {
            _coordinates.TryGetValue(a, out int XY);
            X = XY / 10;
            Y = XY % 10;
        }
    }
}
