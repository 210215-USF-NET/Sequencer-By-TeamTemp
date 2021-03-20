using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MixerModels;

namespace MixerBL
{
    public interface IMixerBL
    {
        Task<UploadedMusic> AddUploadedMusicAsync(UploadedMusic newUploadedMusic);
        Task<UploadedMusic> DeleteUploadedMusicAsync(UploadedMusic uploadedMusic2BDeleted);
        Task<UploadedMusic> GetUploadedMusicByNameAsync(string name);
        Task<List<UploadedMusic>> GetUploadedMusicAsync();
        Task<UploadedMusic> UpdateUploadedMusicAsync(UploadedMusic uploadedMusic2BUpdated);
        Task<User> AddUserAsync(User newUser);
        Task<User> DeleteUserAsync(UploadedMusic user2BDeleted);
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
        Task<List<Track>> GetTrackAsync();
        Task<Track> UpdateTrackAsync(Track track2BUpdated);
         Task<Pattern> AddPatternAsync(Pattern newPattern);
        Task<Pattern> DeletePatternAsync(Pattern pattern2BDeleted);
        Task<Pattern> GetPatternByNameAsync(string name);
        Task<List<Pattern>> GetPatternAsync();
        Task<Pattern> UpdatePatternAsync(Pattern pattern2BUpdated);
    }
}
