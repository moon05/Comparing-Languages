let isPrime n = 
	let n = abs n in
	let rec is_not_divisor d = 
		d * d > n || (n mod d <> 0 && is_not_divisor (d+1)) in
	n <> 1 && is_not_divisor 2 
;;

let rec primeGen n = 
	if n == 1 then [] else 
		let tail = primeGen ( n - 1 ) in 
		if isPrime n then n::tail else tail
;;

let rec sum l=
	match l with
	[] -> 0
	|hd::tl -> hd + (sum tl)
;;

let rec combinations l k =
  if k <= 0 || k > List.length l then []
  else if k = 1 then List.map (fun x -> [x]) l 
  else 
    let hd, tl = List.hd l, List.tl l in
    combinations tl k |> List.rev_append (List.map (fun x -> hd::x) (combinations tl (k-1)))
;;

let rec printList l = 
	let hd, tl = List.hd l, List.tl l in
	if tl == [] then Printf.printf "%d\n" hd else (Printf.printf "%d + " hd ; printList tl)
;;
	
let rec choose l n = 
	if l == [] then (Printf.printf "%s" "") else begin
		let hd, tl = List.hd l, List.tl l in
		if tl == [] then (Printf.printf "%s" "") else begin
			if (sum hd) == n then begin
				printList hd ; 
				choose tl n 
			end
			else begin
				choose tl n ;
			end
		end
	end
;;

let primePartition n =
	let list = primeGen n in
	for i = 1 to n do
		let a = combinations list i in
		choose a n 
	done
;;
