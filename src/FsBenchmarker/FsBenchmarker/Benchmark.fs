namespace FsBenchmarker
open NBenchmarker

module Benchmark =
    open System
    let private actionFrom (func : unit -> unit) =
        new Action(func)

    let seconds n = new SecondsConstraint(n)

    let trial name = new Trial(name)

    let forEach (func : unit -> unit) (t : Trial) =
        t.ForEachIteration <- actionFrom func
        t

    let run (c : IBenchmarkConstraint) (t : Trial) =
        let bm = new Benchmarker()
        bm.AddConstraint(c)
        bm.Run(t)
