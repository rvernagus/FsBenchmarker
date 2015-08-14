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
        seq [t]

    let andTrial name (func : unit -> unit) (ts : Trial seq) =
        Seq.append ts <| trial name func

    let run (c : IBenchmarkConstraint) (ts : Trial seq) =
        let bm = new Benchmarker()
        bm.AddConstraint(c)
        let runTrial (t : Trial) = bm.Run(t)
        Seq.map runTrial ts
