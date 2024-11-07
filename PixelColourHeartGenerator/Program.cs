using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelColourHeartGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Define the number of rows and columns to define the grid size
            int rows = 20; // Height of the heart
            int cols = 40; // Width of the heart

            // Create the 2D array to hold the colors for each pixel
            ConsoleColor[,] colourArray = new ConsoleColor[rows, cols];

            // List of colors to choose from (pink, white, and red)
            ConsoleColor[] availableColours = new ConsoleColor[]
            {
                ConsoleColor.Magenta, // Pink
                ConsoleColor.White,   // White
                ConsoleColor.Red      // Red
            };

            // Random number generator for generating random colors
            Random rand = new Random();

            // Loop through the rows and columns to determine the heart shape pattern
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    // Heart shape logic: This determines if a point lies within the heart
                    double x = (j - cols / 2.0) / (cols / 6.0); // Scaling for correct aspect ratio
                    double y = (i - rows / 4.0) / (rows / 4.0); // Scaling for correct aspect ratio

                    // Heart equation: (x^2 + y^2 - 1)^3 - x^2 * y^3 <= 0
                    double equation = Math.Pow(x * x + y * y - 1, 3) - x * x * Math.Pow(y, 3);

                    // If the equation evaluates to <= 0, it means we're inside the heart shape
                    if (equation <= 0)
                    {
                        // Assign a random color to the pixel that is part of the heart
                        colourArray[i, j] = availableColours[rand.Next(availableColours.Length)];
                    }
                    else
                    {
                        // Else leave it as blank (black or the default background)
                        colourArray[i, j] = ConsoleColor.Black;
                    }
                }
            }

            // Flip the heart shape on the x-axis
            for (int i = 0; i < rows / 2; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    // Swap the current row with its corresponding row from the bottom
                    ConsoleColor temp = colourArray[i, j];
                    colourArray[i, j] = colourArray[rows - 1 - i, j];
                    colourArray[rows - 1 - i, j] = temp;
                }
            }

            // Set the console background to black to ensure visibility
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            // Display the heart shape as a grid of colored "pixels"
            Console.WriteLine("\nDisplaying the love heart shape:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    // Set the color for the current "pixel"
                    Console.ForegroundColor = colourArray[i, j];

                    // Print a colored "pixel" (using the '■' character)
                    Console.Write("■ ");

                    // Reset the color to default after printing each pixel
                    Console.ResetColor();
                }
                // Move to the next line after printing each row of pixels
                Console.WriteLine();
            }

            // Reset the console color
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}
