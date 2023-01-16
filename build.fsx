#r "nuget: Fun.Build"

open Fun.Build


pipeline "dev" {
    description "For developing"
    stage "check env" {
        run "dotnet build"
        run "pnpm install"
    }
    stage "run tools" {
        paralle
        run "dotnet watch run"
        run "pnpm tailwindcss -i wwwroot/tailwind-source.css -o wwwroot/tailwind-generated.css --watch"
    }
    runIfOnlySpecified
}


tryPrintPipelineCommandHelp()
