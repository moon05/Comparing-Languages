with Ada.Text_IO, Ada.Integer_Text_IO;
use Ada.Text_IO, Ada.Integer_Text_IO;

procedure PrimePartition is 
type myArray is array(Integer range <>) of Integer;
type combinations is array(Integer range <>, Integer range<>) of Integer;
function isPrime(I : Integer) return Boolean is
    W : Integer := 2;
    begin
        if I = 1 then
        return False;
        end if;
        for W in 2 .. I-1 loop
	        if I mod W = 0 then
	            return False;
	        end if;
        end loop;
        return True;
end isPrime;
function Prime_Generator (N : Integer) return myArray is
    C : Integer := 0;
    J : Integer := 1;
    A : myArray (0 .. N);
    begin
        for J in 1 .. N loop
            if isPrime(J) then
                A(C) := J;
                C := C + 1;
            end if; 
        end loop; 
        return A;
end Prime_Generator;
function Array_Range (R : myArray) return Integer is
    V : Integer := 0;
    begin
    while R(V) /= 0 loop
        V := V + 1;
    end loop; 
    return V;
end Array_Range;

function Fix(R : myArray) return myArray is 
    Y : Integer := 0;
    A : myArray(0 .. Array_Range(R));
    begin
        for Y in A'Range loop
            A(Y) := R(Y);
        end loop;
    return A;
end Fix;

procedure Comb (Ary : myArray; Data : myArray; Start : Integer; Last : Integer; Index : Integer; R : Integer; Num : Integer) is
    Sum : Integer;
    Counter : Integer := 0;
    I : Integer;
    O : Integer := 0;
    New_Data : myArray := Data;
    begin 
    if Index = R then 
        Sum := 0;
        for Counter in 0 .. R loop
            Sum := Sum + Data(Counter);
        end loop;
        if Sum = Num then 
            for O in Data'Range loop
                Put(Data(O));
                Put(" + ");
            end loop;
            New_Line;
        end if; 
        return;
    end if;
    I := Start;
    while (I <= Last and Last-I+1 >= R-Index) loop
        New_Data(Index) := Ary(I);
        Comb(Ary, New_Data, I+1, Last, Index+1, R, Num);
        I := I + 1; 
    end loop;
end Comb;

--Helper for calculating the length of combinations
function Factorial (N : Integer) return Integer is 
    I : Integer := 1;
    R : Integer := 1;
    begin
    while I <= N loop
        R := R * I;
        I := I + 1;
    end loop;
    return R;
end Factorial;

procedure Partition (Num : Integer) is
    -- D : combinations(0 .. (Factorial(R'Range-1)/Factorial(K)));
    Primes : myArray := Fix(Prime_Generator(Num));
    Length : Integer := 0;
    E : Integer := 0;
    begin
    for E in Primes'Range loop
        Length := Length + 1;
    end loop;
    if isPrime(Num) then
        Put(Num);
        New_Line;
    end if;
    for E in 2 .. Length loop
        declare Dta : myArray(0 .. E);
        begin
            Comb(Primes, Dta, 0, Length - 1, 0, E, Num);
        end;
    end loop;
end Partition;

X : Integer; -- input nu-- Z : Integer := 0;mber
Y : Integer := 0;
M : Integer := 0;
begin
    Put("Enter a number to test: ");
    Get(X);
    Partition(X);
end PrimePartition;
