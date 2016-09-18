import sys
import math

FinalAnswers = list()

def is_prime(num):
	if (num <= 1):
		print "not prime"
		return 0
	elif (num % 2 == 0 and num > 2):
		print "not prime"
		return 0
	for i in range(3, num/2, 2):
		if (num % i == 0):
			print i
			print "not prime"
			return 0;
	print "prime"
	return 1;


def primesUnderInt(num):
	primes, sieve = [], [True] * (num+1)
	for p in range(2, num+1):
		if sieve[p]:
			primes.append(p)
			for x in range(2 * p, num+1, p):
				sieve[x] = False
	return primes


def prime_factors(num):
	factors = list()
	while (num % 2 == 0):
		factors.append(2)
		num = num/2
	a = int(math.ceil(math.sqrt(num)))
	for i in xrange(3, a, 2):
		while (num % i == 0):
			factors.append(i)
			num = num/i
	if (num > 2):
		factors.append(num)

	return factors

def sum_of_prime_factors(factors_list):
	print "In here"
	a = set(factors_list)
	factors_dups_rem = list(a)
	print "Getting out of sopf function"
	return sum(factors_dups_rem)

def primePartitions(num, primeList, tempSoFar, tempListSoFar):
	#[2, 3, 5, 7, 11, 13, 17, 19]
	for i in primeList:
		if (i + tempSoFar == num):
			tempListSoFar.append(i)
			FinalAnswers.append(tempListSoFar)
			continue
		
		if (tempSoFar + i > num):
			continue
		
		copyPrime = primeList[:]
		if (len(copyPrime)==0):
			return FinalAnswers
		
		copyPrime = [e for e in copyPrime if e > i]

		newTempSoFar = tempSoFar + i
		newtempListSoFar = tempListSoFar[:]
		newtempListSoFar.append(i)

		primePartitions(num, copyPrime, newTempSoFar, newtempListSoFar)
		
	return FinalAnswers

def main():
	x = int(sys.argv[1])
	a = primesUnderInt(x)
	print "Printing the Prime Partitions"
	print primePartitions(x, a, 0, [])


if __name__ == "__main__":
	main()