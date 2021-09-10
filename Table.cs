using ConsoleTables;

namespace game
{
    class Table
    {
        static public void print(string[] items)
        {
            var table = new ConsoleTable(("PC \\ User," + string.Join(",", items)).Split(","));
            for (int i = 0; i < items.Length; i++)
            {
                string row = items[i];
                for (int j = 0; j < items.Length; j++)
                {
                    if (j == items.Length - 1 && i == 0)
                    {
                        row = row + ",Lose";
                    }
                    else if (j == 0 && i == items.Length - 1)
                    {
                        row = row + ",Win";
                    }
                    else if (j == i)
                    {
                        row = row + ",Draw";
                    }
                    else if (j > i)
                    {
                        row = row + ",Win";
                    }
                    else
                    {
                        row = row + ",Lose";
                    }
                }

                table.AddRow(row.Split(","));
            }

            table.Write(Format.Alternative);
        }
    }
}