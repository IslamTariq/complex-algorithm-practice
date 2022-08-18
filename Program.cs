namespace SnowTestLearning;

public class program
{
    public static void Main()
    {
        // Array of Tupples. i.e it can also be like (int a, char b) []
        (int a, int y)[] pointss = new (int a, int y)[] { (0, 0), (1, 1), (3, 3), (4, 4) };

        //AsciiArtTargets(pointss);

        //var resultDeepestLetter = DeepestLetter("((a))((((b))))(c)(d)(e)(((f))(((g))))");
        //Console.WriteLine(resultDeepestLetter);

        Console.WriteLine(EvenlySpacedHashes(3));
        Console.WriteLine(EvenlySpacedHashes(4));
        Console.WriteLine(EvenlySpacedHashes(5));
        Console.WriteLine(EvenlySpacedHashes(6));
    }
    public static string AsciiArtTargets((int x, int y)[] points)
    {
        const int CANVAS_WIDTH = 10;
        const int CANVAS_HEIGHT = 5;
        // two dimentional Array. other way of of describing i.e char [][].
        // easy way to declare two dimentional array char[,]. 

        char[,] canvas = new char[CANVAS_HEIGHT, CANVAS_WIDTH]
            {
                {' ',' ', ' ',' ',' ', ' ', ' ', ' ', ' ', ' ' },
                {' ',' ', ' ',' ',' ', ' ', ' ', ' ', ' ', ' ' },
                {' ',' ', ' ',' ',' ', ' ', ' ', ' ', ' ', ' ' },
                {' ',' ', ' ',' ',' ', ' ', ' ', ' ', ' ', ' ' },
                {' ',' ', ' ',' ',' ', ' ', ' ', ' ', ' ', ' ' }
            };

        //handling points
        for (int i = 0; i < points.Length; i++)
        {
            var point = points[i];

            //Draw vertical Line
            for (int j = 0; j < CANVAS_WIDTH; j++)
            {
                if (canvas[point.y, j] == ' ')
                    canvas[point.y, j] = '-';
                else if (canvas[point.y, j] == '|')
                {
                    canvas[point.y, j] = '+';
                }
            }

            //Draw horizontal  Line
            for (int j = 0; j < CANVAS_HEIGHT; j++)
            {
                if (canvas[j, point.x] == ' ')
                    canvas[j, point.x] = '|';
                else if (canvas[j, point.x] == '-')
                {
                    canvas[j, point.x] = '+';
                }
            }

            //Put 'O' at point
            canvas[point.y, point.x] = 'O';
        }

        // board -> string
        string ascii_art = "";
        for (int i = 0; i < CANVAS_HEIGHT; i++)
        {
            for (int j = 0; j < CANVAS_WIDTH; j++)
            {
                ascii_art = ascii_art + canvas[i, j];
            }
            ascii_art = ascii_art + '\n';
        };

        return ascii_art;

    }

    public static char DeepestLetter(string str)
    {

        /*****************************************
		EXPLAINATION:
		=============
			
			In a loop check each letter of str. 
			If its opening bracket then increase the current depth
			If its closing bracket then decrease the current depth
			If its lowercase alphabet then store alphabet into variables only if its depth is greater then deepest letter we have already found
			If any other letter appeared then return '?'
			
			Also check if current_depth is zero. If its not then it means we are missing brackets and return '?'.
		
		
		******************************************/

        int current_depth = 0;
        int max_depth = 0;
        char deep_char = '?';
        foreach (var ch in str)
        {
            if (ch == '(')
                current_depth++;
            else if (ch == ')')
                current_depth--;
            else if (ch >= 'a' && ch <= 'z')
            {
                if (current_depth > max_depth)
                {
                    max_depth = current_depth;
                    deep_char = ch;
                }
            }
            else
                return '?';
        }

        if (current_depth == 0) return deep_char;
        else return '?';
    }

    // For a given input 'size', return a string of that length, which begins and ends with a hash, and which contains
    // the maximum possible number of hashes.  All hashes must be separated by a gap of at least one space. And all gaps in the string
    // must be of equal size.  For inputs which produce invalid strings, return null.
    //  1 -> null
    //  2 -> null
    //  3 -> "# #"
    //  4 -> "#  #"
    //  5 -> "# # #"
    //  6 -> "#    #"
    //  7 -> "# # # #"
    //  8 -> "#      #"
    //  9 -> "# # # # #"
    // 10 -> "#  #  #  #"
    // 11 -> "# # # # # #"

    public static string EvenlySpacedHashes(int size)
    {
        if (size < 3)
        {
            return null;
        }

        int i = 2;
        while (i <= size)
        {
            if (size % i == 1)
            {
                break;
            }
            i++;
        }

        int space = i - 1;
        int repeat = size / i;
        string result = "";

        for (int j = 0; j < repeat; j++)
        {
            result += "#".PadRight(space + 1);
        }
        return result + "#";

    }

    public static string EvenlySpacedHashes(int size)
    {
        if (size < 3) return null;

        // Calculate space
        int i = 2;
        for (; i <= size; i++)
            if (size % i == 1) break;

        int spaces = i - 1;

        //Draw string
        string result = "";
        for (int j = 0; j < size /i; j++)
            result += "#".PadRight(spaces + 1);

        return result + "#";
    }


}