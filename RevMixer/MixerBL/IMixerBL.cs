using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MixerModels;
using MixerDL;

namespace MixerBL
{
    public interface IMixerBL
    {
        Task<UploadMusic> AddUploadedMusicAsync(UploadMusic newUploadedMusic);
        Task<UploadMusic> DeleteUploadedMusicAsync(UploadMusic uploadedMusic2BDeleted);
        Task<UploadMusic> GetUploadedMusicByNameAsync(string name);
        Task<List<UploadMusic>> GetUploadedMusicAsync();
        Task<UploadMusic> UpdateUploadedMusicAsync(UploadMusic uploadedMusic2BUpdated);
        Task<User> AddUserAsync(User newUser);
        Task<User> DeleteUserAsync(User user2BDeleted);
        Task<User> GetUserByNameAsync(string name);
        Task<List<User>> GetUsersAsync();
        Task<User> UpdateUserAsync(User user2BUpdated);
        Task<SavedProject> AddSavedProjectAsync(SavedProject newSavedProject);
        Task<SavedProject> DeleteSavedProjectAsync(SavedProject savedProject2BDeleted);
        Task<SavedProject> GetSavedProjectByNameAsync(string name);
        Task<List<SavedProject>> GetSavedProjectsAsync();
        Task<SavedProject> UpdateSavedProjectAsync(SavedProject savedProject2BUpdated);
        Task<Sample> AddSampleAsync(Sample newSample);
        Task<Sample> DeleteSampleAsync(Sample sample2BDeleted);
        Task<Sample> GetSampleByNameAsync(string name);
        Task<List<Sample>> GetSamplesAsync();
        Task<Sample> UpdateSampleAsync(Sample sample2BUpdated);
        Task<Track> AddTrackAsync(Track newTrack);
        Task<Track> DeleteTrackAsync(Track track2BDeleted);
        Task<Track> GetTrackByNameAsync(string name);
        Task<List<Track>> GetTracksAsync();
        Task<Track> UpdateTrackAsync(Track track2BUpdated);
        Task<Pattern> AddPatternAsync(Pattern newPattern);
        Task<Pattern> DeletePatternAsync(Pattern pattern2BDeleted);
        Task<Pattern> GetPatternByNameAsync(string name);
        Task<List<Pattern>> GetPatternsAsync();
        Task<Pattern> UpdatePatternAsync(Pattern pattern2BUpdated);

        Task<UserProject> AddUserProjectAsync(UserProject newUserProject);
        Task<UserProject> DeleteUserProjectAsync(UserProject userProject2BDeleted);
        Task<UserProject> GetUserProjectByNameAsync(string name);
        Task<List<UserProject>> GetUserProjectsAsync();
        Task<UserProject> UpdateUserProjectAsync(UserProject userProject2BUpdated);

        Task<PlayList> AddPlayListAsync(PlayList newPlaylist);
        Task<PlayList> DeletePlayListAsync(PlayList playlist2BDeleted);
        Task<PlayList> GetPlayListByNameAsync(string name);
        Task<List<PlayList>> GetPlayListsAsync();
        Task<PlayList> UpdatePlayListAsync(PlayList playlist2BUpdated);

        Task<MusicPlaylist> AddMusicPlaylistAsync(MusicPlaylist newMusicPlaylist);
        Task<MusicPlaylist> DeleteMusicPlaylistAsync(MusicPlaylist musicPlaylist2BDeleted);
        Task<MusicPlaylist> GetMusicPlaylistByNameAsync(string name);
        Task<List<MusicPlaylist>> GetMusicPlaylistsAsync();
        Task<MusicPlaylist> UpdateMusicPlaylistAsync(MusicPlaylist musicPlaylist2BUpdated);
        Task<Comments> AddCommentAsync(Comments newComment);
        Task<Comments> DeleteCommentAsync(Comments comment2BDeleted);
        Task<Comments> GetCommentByNameAsync(string name);
        Task<List<Comments>> GetCommentsAsync();
        Task<Comments> UpdateCommentAsync(Comments comment2BUpdated);
    }
}
