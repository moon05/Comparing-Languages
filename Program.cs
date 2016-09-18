using System;
using System.Collections;
using System.Linq;

namespace CSC254_hw01_CS
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Please enter a number: ");
			Prime_Partition (Int32.Parse(Console.ReadLine()));
			foreach(ArrayList l in global_list){
				foreach(int element in l){
					if (l.IndexOf (element) != l.Capacity - 1 && l.Capacity != 1) {
						Console.Write (element + "+");
					} else {
						Console.Write (element);
					}
				}
				Console.WriteLine ("");
			}
		}

		//Check if the number is a prime number
		public static bool isPrime(int num)
		{
			if(num==1){
				return false;
			}
			if(num==2){
				return true;
			}
			int bound = (int)Math.Floor (Math.Sqrt (num));
			for(int i=2; i<=bound; i++){
				if(num % i == 0){
					return false;
				}
			}
			return true;
		}

		//Generate a list of prime numbers up to num
		public static ArrayList Prime_Generator (int num)
		{
			ArrayList list = new ArrayList ();
			for(int i=1; i<=num; i++){
				if(isPrime(i)){
					list.Add (i);
				}
			}
			return list;
		}

		private static ArrayList global_list = new ArrayList();

		//Returns a list of lists, each represents a valid prime partition
		public static void Prime_Partition (int num)
		{
			int [] primes = Prime_Generator (num).OfType<int>().ToArray();
			int length = primes.Length;
			if(isPrime(num)){
				ArrayList l = new ArrayList (new int[]{num});
				global_list.Add (l);
			}

			for(int i=2; i<=length; i++){
				int [] data = new int[i];
				Combinations (primes, data, 0, length - 1, 0, i, num);
			}
		}

		private static void Combinations(int[] ary, int[] data, int start, int end, int index, int r, int num)
		{
			if(index == r){
				int sum = 0;
				for(int q=0; q<r; q++){
					sum += data [q];
				}

				if(sum==num){
					global_list.Add (new ArrayList (data));
				}
				return;
			}

			for (int i=start; i<=end && end-i+1 >= r-index; i++){
				data[index] = ary[i];
				Combinations(ary, data, i+1, end, index+1, r, num);
			}
		}

	}
}
