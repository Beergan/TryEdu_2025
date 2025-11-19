@ECHO OFF
SETLOCAL

IF "%~1"=="" (
    FOR /F %%i IN ('powershell -NoProfile -Command "Get-Date -Format yyyyMMddHHmmss"') DO SET "name=%%i"
) ELSE (
    SET "name=%~1"
)

dotnet ef migrations add "%name%" --context DbPostgresContext --project ./SLK.TryEdu.Db -s ./SLK.TryEdu.WebHost --output-dir Migrations
dotnet ef database update --context DbPostgresContext --project ./SLK.TryEdu.Db -s ./SLK.TryEdu.WebHost

PAUSE
