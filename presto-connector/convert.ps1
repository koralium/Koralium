Get-ChildItem "." -recurse -Filter *.java | 
Foreach-Object {

	Write-Output $_.FullName
	
	((Get-Content  $_.FullName) -join "`n") + "`n" | Set-Content -NoNewline  $_.FullName
}