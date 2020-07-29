using System;
using System.Collections.Generic;

namespace ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Cell> cells = new List<Cell>();
            int player = 0;
            
            for (var i = 0; i < 9; i++)
            {
                Cell cell = new Cell(i);
                cells.Add(cell);
            }


            while (true)
            {
                Console.Clear();
                DrawBoard(cells);
                Console.WriteLine();
                Console.WriteLine($"Vez do jogador {(player % 2) + 1 } ");
                Console.WriteLine("Digite uma valor de celula valido: ");
                int selection = (Convert.ToInt32(Console.ReadLine()) - 1);
                if (selection < 0 || selection >= 10)
                    continue;
                if (!cells[selection].IsSet)
                {
                    cells[selection].SetCell(player);
                    int win = WinCheck(cells);
                    if (win != 0)
                    {
                        if (win == 2)
                        {
                            Console.WriteLine("ACABOU! em um empate D;");
                            break;
                        }
                        Console.WriteLine($"Parabens!!! o jogador{(player % 2) + 1 } venceu");
                        break;
                    }
                    player++;

                }
                else
                {
                    Console.WriteLine("Celula ja escolhida, tente outra");
                    Console.ReadKey();
                }

            }
            Console.ReadKey();

        }
        static void DrawBoard(List<Cell> cells)
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {cells[0].Show()}  |  {cells[1].Show()}  |  {cells[2].Show()}");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {cells[3].Show()}  |  {cells[4].Show()}  |  {cells[5].Show()}");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {cells[6].Show()}  |  {cells[7].Show()}  |  {cells[8].Show()}");
            Console.WriteLine("     |     |      ");
        }

        static int WinCheck(List<Cell> cells)
        {

            for (int i = 0; i <= 6; i = i + 3)
                if (cells[i + 0].Lamp.CheckState() == cells[i + 1].Lamp.CheckState() &&
                    cells[i + 1].Lamp.CheckState() == cells[i + 2].Lamp.CheckState() &&
                    cells[i + 0].IsSet &&
                    cells[i + 1].IsSet &&
                    cells[i + 2].IsSet
                    )

                    return 1;

            for (int i = 0; i <= 2; i = i + 1)
                if (cells[i + 0].Lamp.CheckState() == cells[i + 3].Lamp.CheckState() &&
                    cells[i + 3].Lamp.CheckState() == cells[i + 6].Lamp.CheckState() &&
                    cells[i + 0].IsSet &&
                    cells[i + 3].IsSet &&
                    cells[i + 6].IsSet
                )
                    return 1;

            if (cells[0].Lamp.CheckState() == cells[4].Lamp.CheckState() &&
                cells[4].Lamp.CheckState() == cells[8].Lamp.CheckState() &&
                cells[0].IsSet &&
                cells[4].IsSet &&
                cells[8].IsSet
            )
                return 1;

            if (cells[2].Lamp.CheckState() == cells[4].Lamp.CheckState() && 
                cells[4].Lamp.CheckState() == cells[6].Lamp.CheckState() &&
                cells[2].IsSet &&
                cells[4].IsSet &&
                cells[6].IsSet
            )

                return 1;

            for (int i = 0; i < cells.Count; i = i + 1)
            {
                int setCount = 0;
                if (cells[i].IsSet)
                    setCount++;
                if (setCount == 9)
                    return 2;
            }


            return 0;
        }
    }
}

