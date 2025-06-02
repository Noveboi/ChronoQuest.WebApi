docker compose up -d --build || exit 1
dotnet tool install dotnet-ef --create-manifest-if-needed
dotnet ef database update --project ./ChronoQuest.Core --startup-project ./ChronoQuest.WebApi