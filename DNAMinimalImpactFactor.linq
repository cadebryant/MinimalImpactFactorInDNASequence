<Query Kind="Program" />

void Main()
{
	string S = "CAGCCTA";
	int[] P = new[] { 2, 5, 0 };
	int[] Q = new[] { 4, 5, 6 };
	DNAMinimalImpactFactor(S, P, Q).Dump();
}

public int[] DNAMinimalImpactFactor(string S, int[] P, int[] Q)
{
	int aCount = 0, cCount = 0, gCount = 0;
	var countArr = new int[3, S.Length + 1];
	var result = new int[P.Length];
	for (var i = 0; i < S.Length; i++)
	{
		if (S[i] == 'A')
			aCount++;
		else if (S[i] == 'C')
			cCount++;
		else if (S[i] == 'G')
			gCount++;
		
		countArr[0, i + 1] = aCount;
		countArr[1, i + 1] = cCount;
		countArr[2, i + 1] = gCount;
		
	}
	
	for (var i = 0; i < P.Length; i++)
	{
		var startIdx = P[i];
		var endIdx = Q[i] + 1;
		int tmpResult = 4;
		for (var j = 0; j < 3; j++)
		{
			if (countArr[j, startIdx] != countArr[j, endIdx])
			{
				tmpResult = j + 1;
				break;
			}
		}
		result[i] = tmpResult;
	}
	
	return result;
}