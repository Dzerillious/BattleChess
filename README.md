# BattleChess

2D Game like chess, but with special themes and special game mode. 

Game setup:

![image](https://user-images.githubusercontent.com/26441773/165458125-bc1404ec-196d-466c-b6c0-89e2d9d7d6c5.png)

The game itself:

![image](https://user-images.githubusercontent.com/26441773/165457707-c91a0a38-f92f-4b80-aa87-a65c27d15b6c.png)

Lord of the rings style:

![image](https://user-images.githubusercontent.com/26441773/165457871-6393ec3a-7371-4dcc-bdca-8532354fb5e8.png)

# Multiplayer

This game could be played over the internet by Telegrap.Api for sending the game data. For it create public channel for telegram. Create two bots and add them to the channel. Then add api keys to the game itself.

Game key format: {BotId}:{BotHash}@{RoomName}

On player should host, the second should join to copy the host board. Then the board is shared between player and all clicks are transfered to the other player.
