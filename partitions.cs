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

				List<int> copyPrime = primeList.ToList();

				if (copyPrime.Count == 0) {
					return FinalAnswers;
				}

//				copyPrime.Single (item => item > i);
				Console.WriteLine (string.Join(",",copyPrime.ToArray()));
				List<int> newcopy = new List<int> ();
				for (int k = 0; k < copyPrime.Count; k++) {
					if (copyPrime [k] > i) {
						newcopy.Add (copyPrime [k]);
					}
				}
				copyPrime = newcopy;

				int newTempSoFar = tempSoFar + primeList[i];
				List<int> newtempListSoFar = tempListSoFar.ToList();
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
			List<int> x = PrimesUnder (20);
			List<int> temp = new List<int> ();
			List<List<int>> y = PrimePartitions (20, x, 0, temp);
			Console.Write (y.Count);
//			for (int i = 0; i < y.Count; i++) {
//				string a = string.Join(",",y[i].ToArray());
//				Console.WriteLine (a);
//			}
			Console.WriteLine ("Hello World!");
		}
	}
}

