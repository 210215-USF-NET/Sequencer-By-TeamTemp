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

        public async Task<List<UploadMusic>> GetUploadedMusicByUserIDAsync(int userid)
        {
            return await _context.UploadMusic
                .Include(um => um.User)
                .Include(um => um.Comments)
                .Where(um => um.UserId == userid)
                .ToListAsync();
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
            PlayList oldPlaylist = await _context.PlayList.Where(p => p.Id == playList2BUpdated.Id).FirstOrDefaultAsync();

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
        public async Task<User> GetUserByEmail(string userEmail)
        {
            return await _context.User
               .Include(u => u.PlayLists)
               .AsNoTracking()
               .Include(u => u.UserProjects)
               .AsNoTracking()
               .Include(u => u.Sample)
               .AsNoTracking()
               .Include(u => u.Comments)
               .AsNoTracking()
               .Include(u => u.UploadMusics)
               .AsNoTracking()
               .Where(u => u.Email == userEmail)
               .FirstOrDefaultAsync();

        }


        public async Task<List<Comments>> GetCommentsByMusicIDAsync(int id)
        {
            return await _context.Comments
                .AsNoTracking()
                .Where(c => c.UserId == id)
                .ToListAsync();
        }
    }
}
