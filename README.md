# API documentation
## Endpoints
#### Login
Login handles various login and logout methods.
* Logout() - logs out with the saved token
* Login(string, string) - logs in with the given username and password to the saved server
* UsernamePassword(string, string) - generates the needed JSON object to login with a username and password

#### Net
Net handles all the direct interactions with the matrix API by providing GET and POST methods.
* GenerateRequest(string, Method, bool) - Generates a client and request given a url, method (GET or POST) and a bool indicating whether to authenticate with a header
* Post(string, JObject, bool) - Posts a given JObject to a given url, and authenticates if needed
* Get(string, bool) - Gets data from a given url, and authenticates if needed
* GetStream(HttpClient, string, bool) - Gets a stream from a given url, and authenticates if needed. This is used to reduce RAM usage for syncing, as streams reduce the max RAM usage

#### Rooms
Rooms handles various interactions with rooms.
* ListJoinedRooms() - Lists all the rooms the user is in
* GetRoomEvent(string, string) - Gets information about a given event in a given room
* GetRoomMessages(string, string, string) - Gets messages from a given room, from a given time with a given direction

#### Sync
Sync handles syncing data with matrix, which keeps everything up to date.
* Sync(HttpClient, bool, string, int?) - Performs a sync with the given HttpClient. Will report as online if bool is true, uses the given string as a starting index for the sync, and uses the given int as a time out

## Parser
#### Messages
Messages handles finding the messages within a sync object.
* GetMessagesFromSync(JObject, string) - Given a JObject produced by a sync, returns a list of messages in the given room id
* GetMessagesFromSync(HttpClient, string) - Given a HttpClient and a roomId, perform a sync and return a list of messages

#### RoomAliases
RoomAliases handles finding the names to use for a room.
* FindAlias(JObject, string) - Given a JObject produced by a sync, returns the room alias for a given room id
* FindAlias(HttpClient, string) - Given a HttpClient and a roomId, find the name for that room

## Olm
#### Keys
Keys handles parsing and creating keys for an olm account.
* GetIdentityKeys(IntPtr) - Find the identity keys for an account at the given memory location
* GetOneTimeKeys(IntPtr) - Find the one time keys for an account at the given memory location
* GenerateOneTimeKeys(IntPtr, uint, Random, uint) - Using the given account, generate the given number of one time keys using the given Random class and length of random data

#### Account
Account handles creating and managing olm accounts.
* NewAccount(Random, uint) - Creates an account with the given Random class and length of random data, and returns the location of the account in memory

# Example usage
#### Creating an api instance and performing a manual sync
```csharp
//Create api and httpclient instances
Matrix api = new Matrix(@"https://matrix.org", "example username", "example password");
HttpClient client = new HttpClient();

//Fetch sync data
var sync = api.Sync(client);

api.Logout();
```

#### Writing all new messages to console
```csharp
//Create api and httpclient instances
Matrix api = new Matrix(@"https://matrix.org", "example username", "example password");
HttpClient client = new HttpClient();

//Fetch sync data
var sync = api.Sync(client);

//Wrap in a try/finally so the client will log out even on crash
try 
{
    while (true) 
    {
        //This marks the last data found in the sync, and will be the starting point for the next sync
        string nextBatch = (string)sync["next_batch"];

        //Write each message from the sync to console
        foreach (Event timelineEvent in api.GetMessagesFromSync(sync, roomId))
            Console.WriteLine(timelineEvent);

        //Perform a new sync starting from the last data found, with a timeout of 15 seconds
        //This will keep the request open for 15 seconds, but if a new messages is sent before then it will return early
        sync = api.Sync(client, false, nextBatch, 15000);
    }
}
finally 
{
    api.Logout();
}
```

#### Create an olm account and print the base64 key
```csharp
//Create a new random and olm account
Random random = new Random();
IntPtr olmAccount = Olm.NewAccount(random, 8);

//Get the keys
Console.WriteLine(Olm.GetIdentityKeys(olmAccount));

//It is important to manually free the memory, as the memory is manually allocated for the account
Marshal.FreeHGlobal(olmAccount);
```