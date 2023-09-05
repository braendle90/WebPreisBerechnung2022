# CreateZip.ps1

$sourcePath = "C:\Users\domin\source\repos\braendle90\WebPreisBerechnung2023\WebPreisBerechnungAuB\bin\Release\net7.0\publish"
$zipPath = "C:\Users\domin\source\repos\braendle90\WebPreisBerechnung2023\WebPreisBerechnungAuB\bin\Release\Preisberechnung.zip"

Compress-Archive -Path $sourcePath\* -DestinationPath $zipPath
