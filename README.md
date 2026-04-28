# SCP:SL Supply Drop Plugin

A custom supply drop system for SCP: Secret Laboratory using the EXILED framework.

## Features
* **Automatic Timer:** A countdown starts as soon as the round begins.
* **Radio Notifications:** Players holding a radio receive periodic hints about the remaining time.
* **Global Announcements:** When the supply drop arrives, a broadcast message is sent to everyone.
* **Fully Configurable:** You can easily customize the loot table, drop chances, and amounts via the `config.yml` file.

## How it works
1. When the round starts, a timer (default 400 seconds) begins.
2. Players with a radio will see a hint displaying the countdown.
3. Once the timer reaches zero, items are spawned at the designated surface coordinates with a slight random offset to prevent clipping.
4. A 10-second broadcast informs all players that the supplies have arrived.

## Installation
1. Download the latest `SupplyDrop.dll` from the Releases tab.
2. Place it into your server's `EXILED/Plugins` folder.
3. Restart the server or reload plugins.
4. Customize the items in the generated config file.

## Requirements
* [EXILED Framework](https://github.com/ExMod-Team/EXILED)
