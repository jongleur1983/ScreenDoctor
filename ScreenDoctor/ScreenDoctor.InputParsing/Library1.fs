namespace ScreenDoctor.InputParsing

open Argu

type OutputFormat =
    | Png = 1
    | Svg = 2
    | Html = 3

type CliArguments =
    | OutputFormat of OutputFormat
    | Filename of string
    with interface IArgParserTemplate with
            member s.Usage =
                match s with
                | OutputFormat _ -> "specify a name"
                | Filename _ -> "specify a value"

type Parameters =
    {
        Filename : string
        OutputFormat : OutputFormat
    }

type ICliArgumentParser =
    abstract member Parse : string [] -> Parameters
    abstract member Help : string

type CliArgumentParser() as this =
    let parser = ArgumentParser.Create<CliArguments>()

    interface ICliArgumentParser with
        member __.Parse(args : string[]) =
            let results = parser.Parse args

            {
                Filename =
                    match results.TryGetResult <@ Filename @> with
                    | Some name -> name
                    | None -> null
                OutputFormat =
                    match results.TryGetResult <@ OutputFormat @> with
                    | None -> OutputFormat.Png
                    | Some value -> value
            }
        
        member __.Help = parser.PrintUsage()