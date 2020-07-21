using System;
using System.Linq;

namespace Validator
{
    public class BattleshipField
    {
        private const int FieldSize = 10;
        // There must be single battleship (size of 4 cells), 2 cruisers (size 3), 3 destroyers (size 2) and 4 submarines (size 1)
        private static readonly int[] shipsExpected = new[] { 4, 3, 2, 1 };
        private static int[] ships = new[] { 0, 0, 0, 0 };
        private static bool[,] cellStatus = new bool[FieldSize, FieldSize];

        public static bool ValidateBattlefield(int[,] field)
        {
            try
            {
                ships = new[] { 0, 0, 0, 0 };
                cellStatus = new bool[FieldSize, FieldSize];
                CountShips(field);
                if (!Enumerable.SequenceEqual(ships, shipsExpected))
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private static void CountShips(int[,] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    int shipLength = 0;

                    if (cellStatus[i, j] == false)
                    {
                        if (field[i, j] == 1)
                        {
                            shipLength = 1;

                            // horisontal ships
                            for (int k = j + 1; k < FieldSize; k++)
                            {
                                cellStatus[i, k] = true;
                                if (field[i, k] == 1)
                                {
                                    if (!IsHorisontalShipValid(field, k, i))
                                    {
                                        throw new Exception();
                                    }

                                    shipLength += 1;
                                }
                                else
                                {
                                    break;
                                }
                            }

                            if (shipLength == 1)
                            {
                                // vertical ships
                                for (int k = i + 1; k < FieldSize; k++)
                                {
                                    cellStatus[k, j] = true;
                                    
                                    if (field[k, j] == 1)
                                    {
                                        if (!IsVelticalShipValid(field, j, k))
                                        {
                                            throw new Exception();
                                        }

                                        shipLength += 1;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                } 
                            }

                            ships[shipLength - 1] += 1;
                        }

                        cellStatus[i, j] = true;
                    }
                }
            }
        }

        private static bool IsVelticalShipValid(int[,] field, int x, int y)
        {
            if (x == 0 && IsNearestVerticalCellsIsZero(field, x + 1, y) ||
                x == FieldSize - 1 && IsNearestVerticalCellsIsZero(field, x - 1, y))
            {
                return true;
            }

            if (IsNearestVerticalCellsIsZero(field, x - 1, y) && IsNearestVerticalCellsIsZero(field, x + 1, y))
            {
                return true;
            }

            return false;
        }

        private static bool IsHorisontalShipValid(int[,] field, int x, int y)
        {
            if (y == 0 && IsNearestHorisontalCellsIsZero(field, x, y + 1) ||
                y == FieldSize - 1 && IsNearestHorisontalCellsIsZero(field, x, y - 1))
            {
                return true;
            }

            if (IsNearestHorisontalCellsIsZero(field, x, y - 1) && IsNearestHorisontalCellsIsZero(field, x, y + 1))
            {
                return true;
            }

            return false;
        }

        private static bool IsNearestVerticalCellsIsZero(int[,] field, int x, int y)
        {
            int yMax = y < FieldSize - 1 ? y + 1 : FieldSize - 1;
            int yMin = y > 0 ? y - 1 : 0;
            for (int i = yMin; i <= yMax; i++)
            {
                if (field[i, x] == 1)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsNearestHorisontalCellsIsZero(int[,] field, int x, int y)
        {
            int xMax = x < FieldSize - 1 ? x + 1 : FieldSize - 1;
            int xMin = x > 0 ? x - 1 : 0;
            for (int i = xMin; i <= xMax; i++)
            {
                if (field[y, i] == 1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
