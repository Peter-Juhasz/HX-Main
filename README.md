# Hyper Extensions
Hyper Extensions is a .NET library which contains LINQ-style operators for manipulating multidimensional arrays.

```
Install-Package HX-Main
```

## Portability
 - Portable Class Library which provides support for .NET Framework 4, Silverlight 5, Windows 8, Windows Phone 8.1, Windows Phone Silverlight 8
 - Common Language Specification compliant code

## Code Quality
 - Passes Microsoft Managed Recommended Rules without any warnings
 - Passes Code Contracts static checking without any warnings at high level
 - All public members and parameters are documented

## Examples

Matrix addition of two arrays ```double[,] A, B```:
```C#
double[,] sum = A.Combine(B, (x, y) => x + y);
```

Matrix scalar multiplication of ```double c``` and ```double[,] M```:
```C#
double[,] product = M.Map(e => c * e);
```

Summing all numbers in a matrix ```int[,] data```:
```C#
int sum = data.AsEnumerable().Sum();
```

Matrix multiplication of ```double[,] A, B```:
```C#
double[,] product = A.CrossJoin(B, (x, y) => x * y, r => r.Sum());
```

Scaling down an array of pixels ```int[,] pixels``` to 50%:
```C#
int[,] scaledTo50 = pixels.Split(2, 2).Map(e => (int)e.AsEnumerable().Average());
```

Checking a sudoku solution represented as ```int[,] puzzle```:
```C#
bool isSolution =
	(puzzle.AsRows()) // rows
		.Union
	(puzzle.AsColumns()) // columns
		.Union
	(puzzle.Split(3, 3).AsEnumerable().Select(e => e.To1DArray())) // regions

	// check
	.All(g => Enumerable.Range(1, 9).All(e => g.Contains(e)));
```
