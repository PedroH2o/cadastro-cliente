@echo off
setlocal

echo Verificando se .NET está instalado...
where dotnet >nul 2>&1
if %ERRORLEVEL% NEQ 0 (
    echo ERRO: .NET SDK nao instalado. Instale em https://dotnet.microsoft.com/en-us/download
    pause
    exit /b 1
)

echo Instalando EF CLI, se necessário...
dotnet tool list -g | findstr dotnet-ef >nul
IF %ERRORLEVEL% NEQ 0 (
    dotnet tool install --global dotnet-ef
)

echo Restaurando pacotes...
dotnet restore

echo Aplicando migrations para criar o banco...
dotnet ef database update

echo Iniciando aplicacao...
dotnet run

pause
