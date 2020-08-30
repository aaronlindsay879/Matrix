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