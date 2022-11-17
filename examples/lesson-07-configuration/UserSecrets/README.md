# UserSecrets
Secrets are stored `%APPDATA%\Microsoft\UserSecrets\<user_secrets_id>\secrets.json` on Windows systems and `~/.microsoft/usersecrets/<user_secrets_id>/secrets.json` on Unix-based systems.

Run the following commands
1. Initalize the User Secrets store with `dotnet user-secrets init --project <PATH_TO_CSPROJ_FILE>`
2. Add your secret with `dotnet user-secrets set --project <PATH_TO_CSPROJ_FILE> "ConnectionStrings:NetLog" "Server=127.0.0.1,1433;Database=master;User=sa;Password=suchSecureVeryWordSoPassW0w!;"`
3. Check that everything is correct with `dotnet user-secrets list --project <PATH_TO_CSPROJ_FILE>`

The User Secret ID is set in `examples/lesson-07-configuration/UserSecrets/UserSecrets/UserSecrets.csproj`.

See more @ https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets