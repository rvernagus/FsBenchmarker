#r @"..\packages\NBenchmarker.0.1.0.0\lib\NBenchmarker.dll"
#load "Benchmark.fs"
open FsBenchmarker.Benchmark

trial "Example"
|> forEach (fun () -> printf "HI!")
|> run (seconds 5)
|> printfn "%A"
