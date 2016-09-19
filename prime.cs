using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
	class MainClass
	{
		public static List<List<int>> FinalAnswers = new List<List<int>>();

		public static List<int> PrimesUnder(int Num) {
			List<int> primes = new List<int>();
			for (var i = 2; i <= Num; i++) {
				bool right = true;
				foreach (int j in primes) {
					if (j * j > i) {
						break;
					}
					if (i % j == 0) {
						right = false;
						break;
					}
				}
				if(right){
					primes.Add (i);
				}
			}
			return primes;
		}
					

		public static List<List<int>> PrimePartitions (int N, List<int> primeList, int tempSoFar, List<int> tempListSoFar){
			for (int i = 0; i < primeList.Count; i++){

				if ( primeList[i] + tempSoFar == N ) {
					tempListSoFar.Add(primeList[i]);
					FinalAnswers.Add(tempListSoFar);
					continue;
				}

				if ( tempSoFar + primeList[i] > N ) {
					continue;
				}

				List<int> copyPrime = primeList
                    .Where(e => e > primeList[i])
                    .ToList();

				if (copyPrime.Count == 0) {
					return FinalAnswers;
				}

				int newTempSoFar = tempSoFar + primeList[i];
				List<int> newtempListSoFar = new List<int>(tempListSoFar);

                newtempListSoFar.Add(primeList[i]);

				PrimePartitions(N, copyPrime, newTempSoFar, newtempListSoFar);
			}
				
            return FinalAnswers;
		}

		public static string Printer(List<List<int>> answers) {
			string FinalString = "";
			for (int i = 0; i < answers.Count; i++) {
				List<int> temp = answers [i];

				FinalString += string.Join (",", temp.ToArray ());
			}

			return FinalString;
		}


		public static void Main (string[] args) {
            try
            {
                int upperBound = int.Parse(args[0]);

                var primeList = PrimesUnder(upperBound);
                var primePartitions = PrimePartitions(upperBound, primeList, 0, new List<int>());

                foreach (var sumList in primePartitions)
                {
                    var addString = sumList
                        .Aggregate("", (accum, curr) => $"{accum} + {curr}")
                        .Substring(2);

                    Console.WriteLine($"Primes that sum to {upperBound}: {addString}");
                }
            }
            catch
            {
                Console.WriteLine("Please include a number as a command line argument");
            }
		}
	}
}

