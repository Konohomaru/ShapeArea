FROM mcr.microsoft.com/dotnet/sdk:5.0 AS sdk
WORKDIR /app

COPY ShapeArea/*.csproj ./ShapeArea/
COPY ShapeAreaTests/*.csproj ./ShapeAreaTests/
RUN dotnet restore ./ShapeArea/ --nologo
RUN dotnet restore ./ShapeAreaTests/ --nologo

COPY ShapeArea/ ./ShapeArea/
COPY ShapeAreaTests/ ./ShapeAreaTests/
RUN dotnet build ./ShapeArea/ --nologo --no-restore
RUN dotnet build ./ShapeAreaTests/ --nologo

FROM sdk AS test
WORKDIR /app/ShapeAreaTests

CMD dotnet test --nologo --no-build -v quiet