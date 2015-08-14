#r @"..\packages\NBenchmarker.0.1.0.0\lib\NBenchmarker.dll"
#load "Benchmark.fs"
open FsBenchmarker.Benchmark
open System.Threading

trial "Print Dot" (fun () -> printf "."; Thread.Sleep(100))
|> andTrial "Print Dash" (fun () -> printf "-"; Thread.Sleep(100))
|> run (seconds 5)
|> Seq.iter (fun result -> printfn "%s: %dms" result.TrialName result.ElapsedTime.Milliseconds)
