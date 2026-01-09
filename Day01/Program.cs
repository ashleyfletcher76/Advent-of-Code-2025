using System.Diagnostics;
string inputPath = "input.txt";

string[] input = File.ReadAllLines(inputPath);

int start = 50;
int password = ReadFile(input, start);

Console.WriteLine(password);


static int ReadFile(string[] input, int start)
{
	int count = 0;

	foreach(string line in input)
	{
		if (!string.IsNullOrWhiteSpace(line))
		{
			char rotation = line[0];
			int num = int.Parse(line.Substring(1));

			count += CountZeroHits(start, rotation, num);
			if (rotation == 'R')
				start += num;
			else
				start -= num;
			
			start = ((start % 100) + 100) % 100;
		}
	}
	return count;
}

static int CountZeroHits(int start, char rotation, int num)
{
	if (num <= 0) return 0;

	int firstHit;

	if (rotation == 'R')
		firstHit = (100 - start) % 100;
	else
		firstHit = start % 100;

	if (firstHit == 0)
		firstHit = 100;

	if (num < firstHit)
		return 0;

	return 1 + (num - firstHit) / 100;
}

// static int ReadAllNonEmptyLines(string[] input, int start)
// {
// 	int count = 0;

// 	foreach(string line in input)
// 	{
// 		if (!string.IsNullOrWhiteSpace(line))
// 		{
// 			char rotation = line[0];
// 			int num = int.Parse(line.Substring(1));
// 			if (rotation == 'R')
// 				start += num;
// 			else
// 				start -= num;
// 			start = ((start % 100) + 100) % 100;
// 			if (start == 0)
// 			{
// 				count++;
// 			}
// 		}
// 	}
// 	return count;
// }
