class Program
	def prime_gen(num)
		ary = Array.new
		1.upto(num) { |n| ary<<n if is_prime(n)}
		return ary
	end

	def is_prime(num)
		return false if num == 1
		return true if num == 2
		bound = Math.sqrt(num).floor
		2.upto(bound) { |n|  return false if num % n == 0}
		return true
	end

	def combinations(ary, data, start, last, index, r, num)
		if index == r
			sum = 0
			data.each {|e| sum += e}
			if sum == num 
				puts data.join("+")
			end
			return
		end
		i = start
		while (i<=last && last-i+1 >= r-index) do
			data[index] = ary[i]
			combinations(ary, data, i+1, last, index+1, r, num)
			i+=1
		end
	end

	def partition(num)
		primes = prime_gen(num)
		if is_prime(num)
			p num
		end
		length = primes.length
		2.upto(length) do |n|  
			data = Array.new
			combinations(primes,data,0,length - 1,0,n,num)
		end
	end
end

pro = Program.new
puts "Please enter a number: "
q = gets.chomp.to_i
pro.partition(q)

