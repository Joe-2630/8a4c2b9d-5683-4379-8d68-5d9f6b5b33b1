# Build and verify the library and its tests. The solver is a library, so this
# image is a verification environment rather than a runnable application image.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS verify
WORKDIR /app

# Copy project files first to cache dependency restoration.
COPY *.sln ./
COPY src/SubsequenceSolver/*.csproj ./src/SubsequenceSolver/
COPY tests/SubsequenceSolver.Tests/*.csproj ./tests/SubsequenceSolver.Tests/
RUN dotnet restore

# Copy source and run the same checks documented for local development.
COPY . ./
RUN dotnet format SubsequenceSolver.sln --verify-no-changes --no-restore
RUN dotnet test SubsequenceSolver.sln --configuration Release --no-restore --collect:"XPlat Code Coverage" --results-directory /app/coverage