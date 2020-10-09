
$processes = Get-Process "*docker desktop*"
if ($processes.Count -eq 0)
{
    Start-Process "C:\Program Files\Docker\Docker\Docker Desktop.exe"
}

docker-compose build
docker-compose up

Start-Process "http://localhost"
Start-Process "http://localhost:5601"

