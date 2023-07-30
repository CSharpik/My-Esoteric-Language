using System.Runtime.InteropServices;

[DllImport("user32.dll")]
static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
[DllImport("kernel32.dll", SetLastError = true)]
static extern IntPtr GetConsoleWindow();
const int SW_SHOWMAXIMIZED = 3;
IntPtr hWnd = GetConsoleWindow();
ShowWindow(hWnd, SW_SHOWMAXIMIZED);

short[] cells = new short[5000];
short pos = 0;
sbyte intcode = 0;

Console.Title = "ESOTERIC";
while (true)
{
	Console.ForegroundColor = ConsoleColor.Yellow;
	Console.Write("EXEC -> ");
	Console.ForegroundColor = ConsoleColor.Green;
	string str = Console.ReadLine() ?? "0";
	Interpret(str);
}


void Interpret(string text)
{
	for (int i = 0; i < text.Length; i++)
	{
		switch (text[i])
		{
			case '/':
				intcode++;
				break;
			case '\\':
				intcode--;
				break;
			case '.':
				Interrupt(intcode);
				break;
			case '*':
		                if (cells[pos] == 0)
		                {
		                    short flag = 1;
		                    for (short j = (short)(i + 1); j < text.Length; j++)
		                    {
		                        if (text[j] == '*') flag++;
		                        if (text[j] == '&') flag--;
		                        if (flag == 0 && j != text.Length - 1)
		                        { i = (short)(j + 1); break; }
		                    }
		                }
		                break;
            		case '&':
		                if (cells[pos] != 0)
		                {
		                    short flag = 1;
		                    for (short j = (short)(i - 1); j >= 0; j--)
		                    {
		                        if (text[j] == '&') flag++;
		                        if (text[j] == '*') flag--;
		                        if (flag == 0)
		                        { i = j; break; }
		                    }
		                }
		                break;
		}
	}
}

void Interrupt(sbyte code)
{
	switch (code)
	{
		case 0:
			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.WriteLine(cells[pos]);
			break;
		case 1:
			cells[pos]++;
			break;
		case -1:
			cells[pos]--;
			break;
		case 2:
			if (pos > 4999) break;
			pos++;
			break;
		case -2:
			if (pos < 1) break;
			pos--;
			break;
		case 3:
			Console.ForegroundColor = ConsoleColor.Red;
            		Console.Write("VAL => ");
			Console.ForegroundColor = ConsoleColor.Cyan;
			string inp = Console.ReadLine() ?? "0";
			cells[pos] = short.Parse(inp);
			break;
		case -3:
			Console.BackgroundColor = ConsoleColor.DarkMagenta;
			Console.ForegroundColor = ConsoleColor.White;
            		Console.WriteLine("\n-!\n\nTERMINATED\n\n-!\n");
			Console.ReadKey(true);
			Environment.Exit(0);
            		break;
        	default:
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("\n!- ERROR -!\n");
			break;
	}
}
