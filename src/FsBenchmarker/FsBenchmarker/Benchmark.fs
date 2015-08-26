namespace FsBenchmarker
open NBenchmarker

module Benchmark =
    open System
    let private actionFrom (func : unit -> unit) =
        new Action(func)

    let seconds n = new SecondsConstraint(n)

    let trial name (func : unit -> unit) =
        let t = new Trial(name)
        t.ForEachIteration <- actionFrom func
        t

//    let andTrial name (func : unit -> unit) (ts : Trial seq) =
//        Seq.append ts <| trial name func

    let run (c : IBenchmarkConstraint) (t : Trial) =
        let bm = new Benchmarker()
        bm.AddConstraint(c)
        bm.Run(t)
