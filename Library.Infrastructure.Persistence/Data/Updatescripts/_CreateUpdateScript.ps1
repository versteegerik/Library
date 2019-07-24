$rootDirectory = (Get-Item -Path ".\").FullName # folder where script is running from
$todayAsString = (Get-Date).ToString("yyyyMMdd")
$file = "$rootDirectory\Updatescript_v$($todayAsString)_01_Empty.sql"

[System.IO.File]::WriteAllText($file, "", [System.Text.Encoding]::BigEndianUnicode)
