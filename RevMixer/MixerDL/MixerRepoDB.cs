using MixerModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixerDL
{
    public class MixerRepoDB : IMixerRepoDB
    {
        private readonly MixerDBContext _context;
        public MixerRepoDB(MixerDBContext context)
        {
            _context = context;
        }
        public async Task<Pattern> AddPatternAsync(Pattern newPattern)
        {
            await _context.Pattern.AddAsync(newPattern);
            await _context.SaveChangesAsync();
            return newPattern;
        }

        public async Task<Sample> AddSampleAsync(Sample newSample)
        {
            await _context.Sample.AddAsync(newSample);
            await _context.SaveChangesAsync();
            return newSample;
        }

        public async Task<SavedProject> AddSavedProjectAsync(SavedProject newSavedProject)
        {
            await _context.SavedProject.AddAsync(newSavedProject);
            await _context.SaveChangesAsync();
            return newSavedProject;
        }

        public async Task<Track> AddTrackAsync(Track newTrack)
        {
            await _context.Track.AddAsync(newTrack);
            await _context.SaveChangesAsync();
            return newTrack;
        }

        public async Task<UploadMusic> AddUploadedMusicAsync(UploadMusic newUploadedMusic)
        {
            await _context.UploadMusic.AddAsync(newUploadedMusic);
            await _context.SaveChangesAsync();
            return newUploadedMusic;
        }

        public async Task<User> AddUserAsync(User newUser)
        {
            await _context.User.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }
        public async Task<UserProject> AddUserProjectAsync(UserProject newUserProject)
        {
            await _context.UserProject.AddAsync(newUserProject);
            await _context.SaveChangesAsync();
            return newUserProject;
        }
        public async Task<PlayList> AddPlayListAsync(PlayList newPlayList)
        {
            await _context.PlayList.AddAsync(newPlayList);
            await _context.SaveChangesAsync();
            return newPlayList;
        }
        public async Task<MusicPlaylist> AddMusicPlaylistAsync(MusicPlaylist newMusicPlaylist)
        {
            await _context.MusicPlaylist.AddAsync(newMusicPlaylist);
            await _context.SaveChangesAsync();
            return newMusicPlaylist;
        }
        public async Task<Comments> AddCommentAsync(Comments newComment)
        {
            await _context.Comments.AddAsync(newComment);
            await _context.SaveChangesAsync();
            return newComment;
        }

        public async Task<Pattern> DeletePatternAsync(Pattern pattern2BDeleted)
        {
            _context.Pattern.Remove(pattern2BDeleted);
            await _context.SaveChangesAsync();
            return pattern2BDeleted;
        }

        public async Task<Sample> DeleteSampleAsync(Sample sample2BDeleted)
        {
            _context.Sample.Remove(sample2BDeleted);
            await _context.SaveChangesAsync();
            return sample2BDeleted;
        }

        public async Task<SavedProject> DeleteSavedProjectAsync(SavedProject savedProject2BDeleted)
        {
            _context.SavedProject.Remove(savedProject2BDeleted);
            await _context.SaveChangesAsync();
            return savedProject2BDeleted;
        }

        public async Task<Track> DeleteTrackAsync(Track track2BDeleted)
        {
            _context.Track.Remove(track2BDeleted);
            await _context.SaveChangesAsync();
            return track2BDeleted;
        }

        public async Task<UploadMusic> DeleteUploadedMusicAsync(UploadMusic uploadedMusic2BDeleted)
        {
            _context.UploadMusic.Remove(uploadedMusic2BDeleted);
            await _context.SaveChangesAsync();
            return uploadedMusic2BDeleted;
        }

        public async Task<User> DeleteUserAsync(User user2BDeleted)
        {
            _context.User.Remove(user2BDeleted);
            await _context.SaveChangesAsync();
            return user2BDeleted;
        }
        public async Task<UserProject> DeleteUserProjectAsync(UserProject userProject2BDeleted)
        {
            _context.UserProject.Remove(userProject2BDeleted);
            await _context.SaveChangesAsync();
            return userProject2BDeleted;
        }
        public async Task<PlayList> DeletePlayListAsync(PlayList playList2BDeleted)
        {
            _context.PlayList.Remove(playList2BDeleted);
            await _context.SaveChangesAsync();
            return playList2BDeleted;
        }
        public async Task<MusicPlaylist> DeleteMusicPlaylistAsync(MusicPlaylist musicPlaylist2BDeleted)
        {
            _context.MusicPlaylist.Remove(musicPlaylist2BDeleted);
            await _context.SaveChangesAsync();
            return musicPlaylist2BDeleted;
        }
        public async Task<Comments> DeleteCommentAsync(Comments comment2BDeleted)
        {
            _context.Comments.Remove(comment2BDeleted);
            await _context.SaveChangesAsync();
            return comment2BDeleted;
        }

        public async Task<Pattern> GetPatternByIDAsync(int patternID)
        {
            return await _context.Pattern
                .AsNoTracking()
                .FirstOrDefaultAsync(pattern => pattern.Id == patternID);
        }

        public async Task<List<Pattern>> GetPatternsAsync()
        {
            return await _context.Pattern
                .AsNoTracking()
                .Select(pattern => pattern)
                .ToListAsync();
        }

        public async Task<Sample> GetSampleByIDAsync(int sampleID)
        {
            return await _context.Sample
                .Include(sample => sample.User)
                .AsNoTracking()
                .Include(sample => sample.Track)
                .AsNoTracking()
                .FirstOrDefaultAsync(sample => sample.Id == sampleID);
        }

        public async Task<List<Sample>> GetSamplesAsync()
        {
            return await _context.Sample
                .Include(sample => sample.User)
                .AsNoTracking()
                .Include(sample => sample.Track)
                .AsNoTracking()
                .Select(sample => sample)
                .ToListAsync();
        }

        public async Task<SavedProject> GetSavedProjectByIDAsync(int savedProjectID)
        {
            return await _context.SavedProject
                .Include(savedProject => savedProject.UserProjects)
                .AsNoTracking()
                .FirstOrDefaultAsync(savedProject => savedProject.Id == savedProjectID);
        }

        public async Task<List<SavedProject>> GetSavedProjectsAsync()
        {
            return await _context.SavedProject
                .Include(savedProject => savedProject.UserProjects)
                .AsNoTracking()
                .Select(sampleProject => sampleProject)
                .ToListAsync();
        }

        public async Task<Track> GetTrackByIDAsync(int trackID)
        {
            return await _context.Track
                .Include(track => track.Pattern)
                .AsNoTracking()
                .Include(track => track.Sample)
                .AsNoTracking()
                .Include(track => track.SavedProject)
                .AsNoTracking()
                .FirstOrDefaultAsync(track => track.Id == trackID);
        }

        public async Task<List<Track>> GetTracksAsync()
        {
            return await _context.Track
                .Include(track => track.Pattern)
                .AsNoTracking()
                .Include(track => track.Sample)
                .AsNoTracking()
                .Include(track => track.SavedProject)
                .AsNoTracking()
                .Select(track => track)
                .ToListAsync();
        }

        public Task<List<UploadMusic>> GetUploadedMusicAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UploadMusic> GetUploadedMusicByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetUsersAsync()
        {
            throw new NotImplementedException();
        }
        public Task<UserProject> GetUserProjectByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserProject>> GetUserProjectsAsync()
        {
            throw new NotImplementedException();
        }
        public Task<PlayList> GetPlayListByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<PlayList>> GetPlayListsAsync()
        {
            throw new NotImplementedException();
        }
        public Task<MusicPlaylist> GetMusicPlaylistByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<MusicPlaylist>> GetMusicPlaylistsAsync()
        {
            throw new NotImplementedException();
        }
        public Task<Comments> GetCommentByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<Comments>> GetCommentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Pattern> UpdatePatternAsync(Pattern pattern2BUpdated)
        {
            throw new NotImplementedException();
        }

        public Task<Sample> UpdateSampleAsync(Sample sample2BUpdated)
        {
            throw new NotImplementedException();
        }

        public Task<SavedProject> UpdateSavedProjectAsync(SavedProject savedProject2BUpdated)
        {
            throw new NotImplementedException();
        }

        public Task<Track> UpdateTrackAsync(Track track2BUpdated)
        {
            throw new NotImplementedException();
        }

        public Task<UploadMusic> UpdateUploadedMusicAsync(UploadMusic uploadedMusic2BUpdated)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUserAsync(User user2BUpdated)
        {
            throw new NotImplementedException();
        }
        public Task<UserProject> UpdateUserProjectAsync(UserProject userProject2BUpdated)
        {
            throw new NotImplementedException();
        }
        public Task<PlayList> UpdatePlayListAsync(PlayList playList2BUpdated)
        {
            throw new NotImplementedException();
        }
        public Task<MusicPlaylist> UpdateMusicPlaylistAsync(MusicPlaylist musicPlaylist2BUpdated)
        {
            throw new NotImplementedException();
        }
        public Task<Comments> UpdateCommentAsync(Comments comment2BUpdated)
        {
            throw new NotImplementedException();
        }
    }
}
