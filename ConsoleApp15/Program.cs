using System;

public class Program
{
    public static void DFS(char[][] grid, int r, int c) // метод, маркирующий связанные клетки
    {
        int rLen = grid.Length; // определяет длину карты
        int cLen = grid[0].Length; // определяет ширину карты
        if (r < 0 || c < 0 || r >= rLen || c >= cLen || grid[r][c] == '0')
        {
            return;
        }

        grid[r][c] = '0'; // в случае если найдет 1, пометит 0
        DFS(grid, r - 1, c); // движение вверх
        DFS(grid, r + 1, c); // движение вниз
        DFS(grid, r, c - 1); // движение влево
        DFS(grid, r, c + 1); // движение вправо
    }

    public static int NumIslands(char[][] grid) // метод, считающий количество островов
    {
        int r = grid.Length; // количество строк карты
        if (r == 0) return 0;

        int c = grid[0].Length; // количество столбцов карты

        int count = 0;

        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                if (grid[i][j] == '1')
                {
                    count++;
                    DFS(grid, i, j);
                }
            }
        }
        return count;
    }

    public static void Main()
    {
        Console.WriteLine("Карта: \n-------");
        var map = new char[][]
        {
            new char[] { '0','0','0','0','0','0','1' },
            new char[] { '1','0','0','0','1','1','0' },
            new char[] { '0','0','1','1','1','0','0' },
            new char[] { '0','1','1','0','1','0','0' },
            new char[] { '0','1','0','0','1','1','0' },
            new char[] { '0','1','0','0','1','1','0' },
            new char[] { '1','1','1','1','1','0','0' },
        };

        for (int i = 0; i < map.Length; i++)
        {
            Console.WriteLine(string.Join("", Array.ConvertAll(map[i], c => (c == '0') ? '·' : 'O')));
        }
        Console.WriteLine("-------");
        Console.WriteLine(string.Format("Количество островов = {0}", NumIslands(map)));
    }
}