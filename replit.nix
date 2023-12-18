{ pkgs }: {
	deps = [
   pkgs.dotnetPackages.NUnitConsole
   pkgs.wget
		pkgs.jq.bin
    pkgs.dotnet-sdk
    pkgs.omnisharp-roslyn
	];
}