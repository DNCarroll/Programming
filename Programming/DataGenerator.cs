using System;

namespace Programming {
    public static class DataGenerator
    {
        public static int[,] GetData(int rows, int columns, int minValue, int maxValue) {
            int[,] grid = new int[rows, columns];
            for(int x = 0; x< rows; x++) {
                for(int y=0; y < columns; y++) {
                    grid[x, y] = RandomValue(minValue, maxValue);
                }
            }
            return grid;
        }

        public static int RandomValue(int min, int max) {
            Random random = new Random();
            return random.Next(min, max);
        }

        public static int[] RandomValues(int min, int max, int count) {
            Random random = new Random();
            int[] ret = new int[count];
            for (int i = 0; i < count; i++) {
                ret[i] = random.Next(min, max);
            }
            return ret;
        }

        public static int[,] TestGrid1() {
            int[,] grid = new int[6, 6];
            grid[0, 0] = 0;
            grid[0, 1] = 115;
            grid[0, 2] = 5;
            grid[0, 3] = 15;
            grid[0, 4] = 0;
            grid[0, 5] = 5;

            grid[1, 0] = 80;
            grid[1, 1] = 210;
            grid[1, 2] = 0;
            grid[1, 3] = 5;
            grid[1, 4] = 5;
            grid[1, 5] = 0;

            grid[2, 0] = 45;
            grid[2, 1] = 60;
            grid[2, 2] = 145;
            grid[2, 3] = 175;
            grid[2, 4] = 95;
            grid[2, 5] = 25;

            grid[3, 0] = 95;
            grid[3, 1] = 5;
            grid[3, 2] = 250;
            grid[3, 3] = 250;
            grid[3, 4] = 115;
            grid[3, 5] = 5;

            grid[4, 0] = 170;
            grid[4, 1] = 230;
            grid[4, 2] = 245;
            grid[4, 3] = 185;
            grid[4, 4] = 165;
            grid[4, 5] = 145;

            grid[5, 0] = 145;
            grid[5, 1] = 220;
            grid[5, 2] = 140;
            grid[5, 3] = 160;
            grid[5, 4] = 250;
            grid[5, 5] = 250;
            return grid;
        }

        public static int [,] TestGrid2() {
            int[,] grid = new int[6, 6];
            grid[0, 0] = 0;
            grid[0, 1] = 115;
            grid[0, 2] = 5;
            grid[0, 3] = 15;
            grid[0, 4] = 0;
            grid[0, 5] = 5;

            grid[1, 0] = 80;
            grid[1, 1] = 210;
            grid[1, 2] = 0;
            grid[1, 3] = 5;
            grid[1, 4] = 205;
            grid[1, 5] = 0;

            grid[2, 0] = 45;
            grid[2, 1] = 60;
            grid[2, 2] = 145;
            grid[2, 3] = 175;
            grid[2, 4] = 95;
            grid[2, 5] = 25;

            grid[3, 0] = 95;
            grid[3, 1] = 5;
            grid[3, 2] = 250;
            grid[3, 3] = 250;
            grid[3, 4] = 115;
            grid[3, 5] = 5;

            grid[4, 0] = 170;
            grid[4, 1] = 230;
            grid[4, 2] = 245;
            grid[4, 3] = 185;
            grid[4, 4] = 165;
            grid[4, 5] = 145;

            grid[5, 0] = 145;
            grid[5, 1] = 220;
            grid[5, 2] = 140;
            grid[5, 3] = 160;
            grid[5, 4] = 250;
            grid[5, 5] = 250;
            return grid;
        }

    }
}
