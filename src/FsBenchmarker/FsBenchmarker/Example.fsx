#r @"..\packages\NBenchmarker.0.1.0.0\lib\NBenchmarker.dll"
#load "Benchmark.fs"
open FsBenchmarker.Benchmark
open System.Threading
open NBenchmarker

trial "Print Dot" (fun () -> Thread.Sleep(100))
|> run (seconds 5)
|> printfn "%A"
