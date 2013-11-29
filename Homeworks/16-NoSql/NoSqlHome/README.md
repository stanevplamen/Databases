1. Write a simple "Dictionary" application in C# or JavaScript to perform the following in MongoDB:
Add a dictionary entry (word + translation)
List all words and their translations
Find the translation of given word
The UI of the application is up to you (it could be Web-based, GUI or console-based).
You may use MongoDB-as-a-Service@ MongoLab.
You may install the "Official MongoDB C# Driver" from NuGet or download it from its publisher: 

2. Implement the previous task (a simple "Dictionary" application) using Redis.
You may hold the "word + meaning pairs" in a hash (see http://redis.io/commands#hash)
See the HSET, HKEYS and HGET commands
You may use a local Redis instance or register for a free "Redis To Go" account at https://redistogo.com.
You may download the client libraries for your favorite programming language from http://redis.io/clients or use the "ServiceStack.Redis" C# client from the NuGet package manager.

3.* Implement а program, which synchronizes mouse movement and clicking between multiple computers. Users can "give control" to other users. Users sign in with username and password. Users "in control" can revoke their control. A user can be signed in on several machines at once. Store user data in MongoLab. Store the mouse sync data in the "Redis To Go" cloud.
Note: In the real world data would pass through a server, as direct access from the client to the database is a security concern. This task is meant more as an experiment than a real-world scenario.
