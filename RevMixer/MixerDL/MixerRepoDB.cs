using MixerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MixerDL
{
    class MixerRepoDB : IMixerRepoDB
    {
        private readonly MixerDBContext _context;

        public MixerRepoDB(MixerDBContext context)
        {
            _context = context;
        }

        public Task<Pattern> AddPatternAsync(Pattern newPattern)
        {
            throw new NotImplementedException();
        }

        public Task<Sample> AddSampleAsync(Sample newSample)
        {
            throw new NotImplementedException();
        }

        public Task<SavedProject> AddSavedProjectAsync(SavedProject newSavedProject)
        {
            throw new NotImplementedException();
        }

        public Task<Track> AddTrackAsync(Track newTrack)
        {
            throw new NotImplementedException();
        }

        public Task<UploadMusic> AddUploadedMusicAsync(UploadMusic newUploadedMusic)
        {
            throw new NotImplementedException();
        }

        public Task<User> AddUserAsync(User newUser)
        {
            throw new NotImplementedException();
        }
        public Task<UserProject> AddUserProjectAsync(UserProject newUserProject)
        {
            throw new NotImplementedException();
        }
        public Task<PlayList> AddPlayListAsync(PlayList newPlayList)
        {
            throw new NotImplementedException();
        }
        public Task<MusicPlaylist> AddMusicPlaylistAsync(MusicPlaylist newMusicPlaylist)
        {
            throw new NotImplementedException();
        }
        public Task<Comments> AddCommentAsync(Comments newComment)
        {
            throw new NotImplementedException();
        }

        public Task<Pattern> DeletePatternAsync(Pattern pattern2BDeleted)
        {
            throw new NotImplementedException();
        }

        public Task<Sample> DeleteSampleAsync(Sample sample2BDeleted)
        {
            throw new NotImplementedException();
        }

        public Task<SavedProject> DeleteSavedProjectAsync(SavedProject savedProject2BDeleted)
        {
            throw new NotImplementedException();
        }

        public Task<Track> DeleteTrackAsync(Track track2BDeleted)
        {
            throw new NotImplementedException();
        }

        public Task<UploadMusic> DeleteUploadedMusicAsync(UploadMusic uploadedMusic2BDeleted)
        {
            throw new NotImplementedException();
        }

        public Task<User> DeleteUserAsync(User user2BDeleted)
        {
            throw new NotImplementedException();
        }
        public Task<UserProject> DeleteUserProjectAsync(UserProject userProject2BDeleted)
        {
            throw new NotImplementedException();
        }
        public Task<PlayList> DeletePlayListAsync(PlayList playList2BDeleted)
        {
            throw new NotImplementedException();
        }
        public Task<MusicPlaylist> DeleteMusicPlaylistAsync(MusicPlaylist musicPlaylist2BDeleted)
        {
            throw new NotImplementedException();
        }
        public Task<Comments> DeleteCommentAsync(Comments comment2BDeleted)
        {
            throw new NotImplementedException();
        }

        public Task<Pattern> GetPatternByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<Pattern>> GetPatternsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Sample> GetSampleByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<Sample>> GetSamplesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SavedProject> GetSavedProjectByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<SavedProject>> GetSavedProjectsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Track> GetTrackByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<Track>> GetTracksAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<UploadMusic>> GetUploadedMusicAsync()
        {
            return await _context.UploadMusic
                .Include(um => um.User)
                .Include(um => um.Comments)
                .ToListAsync();
        }

        public async Task<UploadMusic> GetUploadedMusicByIDAsync(int id)
        {
            return await _context.UploadMusic
                .Include(um => um.User)
                .Include(um => um.Comments)
                .Where(um => um.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByIDAsync(int id)
        {
            return await _context.User
                .Include(u => u.PlayLists)
                .Include(u => u.UserProjects)
                .Include(u => u.Sample)
                .Include(u => u.Comments)
                .Include(u => u.UploadMusics)
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();

        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.User
                .Include(u => u.PlayLists)
                .Include(u => u.UserProjects)
                .Include(u => u.Sample)
                .Include(u => u.Comments)
                .Include(u => u.UploadMusics)
                .ToListAsync();
        }
        public async Task<UserProject> GetUserProjectByIDAsync(int id)
        {
            return await _context.UserProject
                .Include(up => up.User)
                .Include(up => up.SavedProject)
                .ThenInclude(sp => sp.Tracks)
                .ThenInclude(t => t.Sample)
                .Include(up => up.SavedProject)
                .ThenInclude(sp => sp.Tracks)
                .ThenInclude(t => t.Pattern)
                .Where(up => up.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<UserProject>> GetUserProjectsAsync()
        {
            return await _context.UserProject
                .Include(up => up.User)
                .Include(up => up.SavedProject)
                .ThenInclude(sp => sp.Tracks)
                .ThenInclude(t => t.Sample)
                .Include(up => up.SavedProject)
                .ThenInclude(sp => sp.Tracks)
                .ThenInclude(t => t.Pattern)
                .ToListAsync();
        }
        public async Task<PlayList> GetPlayListByIDAsync(int id)
        {
            return await _context.PlayList
                .Include(p => p.MusicPlaylist)
                .ThenInclude(mp => mp.UploadMusic)
                .Include(p => p.User)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<PlayList>> GetPlayListsAsync()
        {
            return await _context.PlayList
                .Include(p => p.MusicPlaylist)
                .ThenInclude(mp => mp.UploadMusic)
                .Include(p => p.User)
                .ToListAsync();
        }
        public async Task<MusicPlaylist> GetMusicPlaylistByIDAsync(int id)
        {
            return await _context.MusicPlaylist
                .Include(mp => mp.UploadMusic)
                .Include(mp => mp.PlayList)
                .Where(mp => mp.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<MusicPlaylist>> GetMusicPlaylistsAsync()
        {
            return await _context.MusicPlaylist
                .Include(mp => mp.UploadMusic)
                .Include(mp => mp.PlayList)
                .ToListAsync();
        }
        public async Task<Comments> GetCommentByIDAsync(int id)
        {
            return await _context.Comments
                .Include(c => c.User)
                .Include(c => c.UploadedMusic)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Comments>> GetCommentsAsync()
        {
            return await _context.Comments
                .Include(c => c.User)
                .Include(c => c.UploadedMusic)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Pattern> UpdatePatternAsync(Pattern pattern2BUpdated)
        {
            Pattern oldPattern = await _context.Pattern.Where(s => s.Id == pattern2BUpdated.Id).FirstOrDefaultAsync();

            _context.Entry(oldPattern).CurrentValues.SetValues(pattern2BUpdated);

            await _context.SaveChangesAsync();

            _context.ChangeTracker.Clear();
            return oldPattern;
        }

        public async Task<Sample> UpdateSampleAsync(Sample sample2BUpdated)
        {
            Sample oldSample = await _context.Sample.Where(s => s.Id == sample2BUpdated.Id).FirstOrDefaultAsync();

            _context.Entry(oldSample).CurrentValues.SetValues(sample2BUpdated);

            await _context.SaveChangesAsync();

            _context.ChangeTracker.Clear();
            return oldSample;
        }

        public async Task<SavedProject> UpdateSavedProjectAsync(SavedProject savedProject2BUpdated)
        {
            SavedProject oldSavedProject = await _context.SavedProject.Where(sp => sp.Id == savedProject2BUpdated.Id).FirstOrDefaultAsync();

            _context.Entry(oldSavedProject).CurrentValues.SetValues(savedProject2BUpdated);

            await _context.SaveChangesAsync();

            _context.ChangeTracker.Clear();
            return oldSavedProject;
        }

        public async Task<Track> UpdateTrackAsync(Track track2BUpdated)
        {
            Track oldTrack = await _context.Track.Where(t => t.Id == track2BUpdated.Id).FirstOrDefaultAsync();

            _context.Entry(oldTrack).CurrentValues.SetValues(track2BUpdated);

            await _context.SaveChangesAsync();

            _context.ChangeTracker.Clear();
            return track2BUpdated;
        }

        public async Task<UploadMusic> UpdateUploadedMusicAsync(UploadMusic uploadedMusic2BUpdated)
        {
            UploadMusic oldUploadedMusic = await _context.UploadMusic.Where(um => um.Id == uploadedMusic2BUpdated.Id).FirstOrDefaultAsync();

            _context.Entry(oldUploadedMusic).CurrentValues.SetValues(uploadedMusic2BUpdated);

            await _context.SaveChangesAsync();

            _context.ChangeTracker.Clear();
            return uploadedMusic2BUpdated;
        }

        public async Task<User> UpdateUserAsync(User user2BUpdated)
        {
            User oldPlaylist = await _context.User.Where(u => u.Id == user2BUpdated.Id).FirstOrDefaultAsync();

            _context.Entry(oldPlaylist).CurrentValues.SetValues(user2BUpdated);

            await _context.SaveChangesAsync();

            _context.ChangeTracker.Clear();
            return user2BUpdated;
        }
        public async Task<UserProject> UpdateUserProjectAsync(UserProject userProject2BUpdated)
        {
            UserProject oldProject = await _context.UserProject.Where(up => up.Id == userProject2BUpdated.Id).FirstOrDefaultAsync();

            _context.Entry(oldProject).CurrentValues.SetValues(userProject2BUpdated);

            await _context.SaveChangesAsync();

            _context.ChangeTracker.Clear();
            return userProject2BUpdated;
        }
        public async Task<PlayList> UpdatePlayListAsync(PlayList playList2BUpdated)
        {
            MusicPlaylist oldPlaylist = await _context.MusicPlaylist.Where(p => p.Id == playList2BUpdated.Id).FirstOrDefaultAsync();

            _context.Entry(oldPlaylist).CurrentValues.SetValues(playList2BUpdated);

            await _context.SaveChangesAsync();

            _context.ChangeTracker.Clear();
            return playList2BUpdated;
        }
        public async Task<MusicPlaylist> UpdateMusicPlaylistAsync(MusicPlaylist musicPlaylist2BUpdated)
        {
            MusicPlaylist oldMusicPlaylist = await _context.MusicPlaylist.Where(mp => mp.Id == musicPlaylist2BUpdated.Id).FirstOrDefaultAsync();

            _context.Entry(oldMusicPlaylist).CurrentValues.SetValues(musicPlaylist2BUpdated);

            await _context.SaveChangesAsync();

            _context.ChangeTracker.Clear();
            return musicPlaylist2BUpdated;
        }
        public async Task<Comments> UpdateCommentAsync(Comments comment2BUpdated)
        {
            Comments oldComment = await _context.Comments.Where(c => c.Id == comment2BUpdated.Id).FirstOrDefaultAsync();

            _context.Entry(oldComment).CurrentValues.SetValues(comment2BUpdated);

            await _context.SaveChangesAsync();

            _context.ChangeTracker.Clear();
            return comment2BUpdated;
        }
    }
}
