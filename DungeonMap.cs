/**       
*--------------------------------------------------------------------
* 	   File name: DungeonMap.cs
* 	Project name: _1260_002_Project5
*--------------------------------------------------------------------
* Author’s name and email: Sam Collins (collinss5@etsu.edu)				
*          Course-Section:  CSCI 1260-002
*           Creation Date:	 4/18/2023		
* -------------------------------------------------------------------
*/

using Project_5.Weapon_Classes;
using System.Text;

namespace Project_5
{
    public enum CellType
    {
        None, // Cell does not exist
        Normal,
        Entrance,
        Exit
    }

    public class DungeonCell
    {
        public CellType cellType;

        public Player player;
        public Monster monster;

        public BaseWeapon weapon;

        public DungeonCell()
        {
            cellType = CellType.None;
        }
    }

    public class DungeonMap
    {
        public DungeonCell[,] map;
        private StringBuilder mapDisplay;

        private const int MinRows = 3;
        private const int MaxRows = 5;
        private const int MinColumns = 4;
        private const int MaxColumns = 10;

        private const int MinMonsters = 6;
        private const int MaxMonsters = 16;

        private const int MinItems = 4;
        private const int MaxItems = 10;

        private int rows;
        private int columns;

        public Player player;
        public (int, int) playerPos;

        public DungeonMap()
        {
            map = new DungeonCell[MaxRows, MaxColumns];
            player = new Player();

            Random rand = new Random();
            rows = rand.Next(MinRows, MaxRows);
            columns = rand.Next(MinColumns, MaxColumns);

            for (int r = 0; r < MaxRows; r++)
            {
                for (int c = 0; c < MaxColumns; c++)
                {
                    map[r, c] = new DungeonCell();

                    if (r <= rows && c <= columns)
                    {
                        map[r, c].cellType = CellType.Normal;
                    }
                }
            }

            map[0, 0].cellType = CellType.Entrance;
            map[0, 0].player = player;
            playerPos = (0, 0);

            int exitRow = rand.Next(0, rows - 1);
            map[exitRow, columns - 1].cellType = CellType.Exit;

            // Populate with random monsters and items

            // Make list of valid indices
            List<(int, int)> validIndices = new List<(int, int)>();

            int roomCounter = 0;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    if (map[r, c].cellType != CellType.Entrance)
                    {
                        validIndices.Add((r, c));
                        roomCounter++;
                    }
                }
            }

            // Get available rooms, but leave at least one room for an item
            int availRooms = validIndices.Count - 1;

            int maxMonsters = 0;
            if (availRooms > MaxMonsters)
                maxMonsters = MaxMonsters;
            else
                maxMonsters = availRooms;

            int numMonsters = rand.Next(MinMonsters, maxMonsters);
            availRooms -= numMonsters;

            // Put back room for item
            availRooms++;

            int maxItems = 0;
            if (availRooms > MaxItems)
                maxItems = MaxItems;
            else
                maxItems = availRooms;

            int numItems = -1;

            if (maxItems >= MinItems)
            {
                numItems = rand.Next(MinItems, maxItems);
            }
            else
            {
                numItems = maxItems;
            }

            for (int i = 0; i < numMonsters; i++)
            {
                (int, int) indices = validIndices[rand.Next(0, validIndices.Count - 1)];
                map[indices.Item1, indices.Item2].monster = new Monster();
                validIndices.Remove(indices);
            }

            for (int i = 0; i < numItems; i++)
            {
                (int, int) indices = new (-1, -1);

                if (validIndices.Count > 0)
                {
                    indices = validIndices[rand.Next(0, validIndices.Count - 1)];
                }
                else
                {
                    indices = validIndices[0];
                }

                int randItem = rand.Next(0, 4);

                switch (randItem)
                {
                    case 0:
                        map[indices.Item1, indices.Item2].weapon = new Chair();
                        break;

                    case 1:
                        map[indices.Item1, indices.Item2].weapon = new Gun();
                        break;

                    case 2:
                        map[indices.Item1, indices.Item2].weapon = new PepperSpray();
                        break;

                    case 3:
                        map[indices.Item1, indices.Item2].weapon = new Stick();
                        break;

                    case 4:
                        map[indices.Item1, indices.Item2].weapon = new Sword();
                        break;
                }

                validIndices.Remove(indices);
            }

            mapDisplay = new StringBuilder();
        }

        public string GetMapDisplay()
        {
            mapDisplay.Clear();

            string horizontalWall = "############ ";
            string outerWalls =     "#          # ";

            for (int r = 0; r < rows; r++)
            {
                // ############
                for (int i = 0; i < columns; i++)
                {
                    mapDisplay.Append(horizontalWall);
                }
                mapDisplay.Append("\n");

                // #          #
                for (int i = 0; i < columns; i++)
                {
                    mapDisplay.Append(outerWalls);
                }
                mapDisplay.Append("\n");

                // #  P    M  #
                for (int i = 0; i < columns; i++)
                {
                    string playerChar = " ";
                    string otherChar = "  ";
                    if (map[r, i].player != null)
                    {
                        playerChar = "P";
                    }
                    if (map[r, i].monster != null)
                    {
                        otherChar = "M ";
                    }
                    if (map[r, i].weapon != null)
                    {
                        if (map[r, i].weapon is Chair)
                        {
                            otherChar = "Ch";
                        }
                        else if (map[r, i].weapon is Gun)
                        {
                            otherChar = "G ";
                        }
                        else if (map[r, i].weapon is PepperSpray)
                        {
                            otherChar = "Ps";
                        }
                        else if (map[r, i].weapon is Stick)
                        {
                            otherChar = "St";
                        }
                        else if (map[r, i].weapon is Sword)
                        {
                            otherChar = "Sw";
                        }
                    }

                    if (map[r, i].cellType == CellType.Exit)
                    {
                        mapDisplay.Append($"#  {playerChar}   {otherChar}  E ");
                    }
                    else
                    {
                        mapDisplay.Append($"#  {playerChar}   {otherChar}  # ");
                    }
                }
                mapDisplay.Append("\n");

                // #          #
                for (int i = 0; i < columns; i++)
                {
                    mapDisplay.Append(outerWalls);
                }
                mapDisplay.Append("\n");

                // ############
                for (int i = 0; i < columns; i++)
                {
                    mapDisplay.Append(horizontalWall);
                }
                mapDisplay.Append("\n");

                mapDisplay.Append("\n");
            }

            return mapDisplay.ToString();
        }

        public int GetNumRows()
        {
            return rows;
        }

        public int GetNumColumns()
        {
            return columns;
        }

        public (int, int)GetPlayerPos()
        {
            return playerPos;
        }

        public void MovePlayer(int row, int column)
        {
            if (row <= rows && column <= columns)
            {
                map[playerPos.Item1, playerPos.Item2].player = null;
                playerPos = (row, column);
                map[playerPos.Item1, playerPos.Item2].player = player;
            }
        }
    }
}
