using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Data;
using TunifyPlatform.Models;
using TunifyPlatform.Models.DTO;
using TunifyPlatform.Repositories.Interfaces;

namespace TunifyPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ISongRepository _songRepository;

        public SongsController(ISongRepository songRepository)
        {
            _songRepository = songRepository;
        }

        // GET: api/Songs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetAllSongs()
        {
            return Ok(await _songRepository.GetAllSongsAsync());
        }

        // GET: api/Songs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> GetSongById(int id)
        {
            var song = await _songRepository.GetSongByIdAsync(id);
            if (song == null)
            {
                return NotFound();
            }
            return song;
        }

        // PUT: api/Songs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Policy = "full_access")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSong(int id, Song song)
        {
            if (id != song.SongId)
            {
                return BadRequest();
            }

            await _songRepository.UpdateSongAsync(song);
            return NoContent();
        }

        // POST: api/Songs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Song>> AddSong(SongDto songdto)
        {
            await _songRepository.AddSongAsync(songdto);
            return CreatedAtAction(nameof(GetSongById), new { id = songdto.SongId }, songdto);
        }

        // DELETE: api/Songs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong(int id)
        {
            var song = await _songRepository.GetSongByIdAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            await _songRepository.DeleteSongAsync(id);
            return NoContent();
        }
    }
}
