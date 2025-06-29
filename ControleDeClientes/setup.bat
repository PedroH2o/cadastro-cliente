@echo off
setlocal

echo Verificando instalacao do .NET SDK...

dotnet --version >nul 2>&1
IF %ERRORLEVEL% NEQ 0 (
    echo ERRO: .NET SDK nao encontrado.
    echo Baixe e instale manualmente: https://dotnet.microsoft.com/en-us/download/dotnet/6.0
    pause
    exit /b 1
)

echo Verificando ferramenta dotnet-ef...
dotnet tool list -g | findstr dotnet-ef >nul
IF %ERRORLEVEL% NEQ 0 (
    echo Instalando dotnet-ef globalmente...
    dotnet tool install --global dotnet-ef
)

echo Restaurando dependencias...
dotnet restore

echo Aplicando migrations (criando banco SQLite)...
dotnet ef database update

echo Iniciando a aplicacao...
dotnet run

endlocal
pause
