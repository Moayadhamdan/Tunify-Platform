﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Data;
using TunifyPlatform.Models;
using TunifyPlatform.Repositories.Interfaces;

namespace TunifyPlatform.Repositories.Services
{
    public class PlaylistRepository : IPlaylistRepository
    {
        private readonly TunifyDbContext _context;

        public PlaylistRepository(TunifyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Playlist>> GetAllPlaylistsAsync()
        {
            return await _context.Playlist.ToListAsync();
        }

        public async Task<Playlist> GetPlaylistByIdAsync(int id)
        {
            return await _context.Playlist.FindAsync(id);
        }

        public async Task AddPlaylistAsync(Playlist playlist)
        {
            await _context.Playlist.AddAsync(playlist);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePlaylistAsync(Playlist playlist)
        {
            _context.Playlist.Update(playlist);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePlaylistAsync(int id)
        {
            var playlist = await _context.Playlist.FindAsync(id);
            _context.Playlist.Remove(playlist);
            await _context.SaveChangesAsync();
        }
    }
}
