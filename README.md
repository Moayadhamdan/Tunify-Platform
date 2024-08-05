# Tunify Platform

## Introduction

Tunify Platform is an Empty .NET Core Web Application to enhance your music experience. It allows users to create and manage playlists, explore various songs, albums, and artists, and subscribe to different subscription plans. With Tunify Platform, you can organize your favorite songs into playlists, discover new music, and keep track of your musical journey.
## Tunify ERD Diagram

![Tunify ERD Diagram](TunifyPlatform/Asstes/Tunify.png)

## Overview of Relationships

The Tunify Platform database schema is structured to maintain a well-organized and efficient relationship between various entities. Below is an overview of the relationships between the entities in the Tunify Platform:

1. **Users**
   - Each user is uniquely identified by `UserId`.
   - Users have a one-to-many relationship with playlists, meaning a user can create multiple playlists.
   - Each user has a subscription identified by `SubscriptionId`.

2. **Subscriptions**
   - Subscriptions are uniquely identified by `SubscriptionId`.
   - Each subscription has a type and a price.
   - Users are linked to subscriptions via `SubscriptionId`.

3. **Playlists**
   - Playlists are uniquely identified by `PlaylistId`.
   - Each playlist is associated with a specific user via `UserId`.
   - Playlists have a one-to-many relationship with `PlaylistSongs`, meaning a playlist can contain multiple songs.

4. **Songs**
   - Songs are uniquely identified by `SongId`.
   - Each song is associated with an artist and an album via `ArtistId` and `AlbumId` respectively.
   - Songs have a many-to-many relationship with playlists, managed through the `PlaylistSongs` table.

5. **Albums**
   - Albums are uniquely identified by `AlbumId`.
   - Each album is associated with an artist via `ArtistId`.

6. **Artists**
   - Artists are uniquely identified by `ArtistId`.
   - Artists can have multiple albums.

7. **PlaylistSongs**
   - The `PlaylistSongs` table serves as a junction table for the many-to-many relationship between playlists and songs.
   - Each entry in `PlaylistSongs` is uniquely identified by `PlaylistSongsId` and contains foreign keys to `PlaylistId` and `SongId`.

In summary, the database design ensures a flexible and scalable structure, allowing users to manage their musical content efficiently while maintaining the integrity and relationships of the data.
