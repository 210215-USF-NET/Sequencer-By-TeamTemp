using MixerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixerDL
{
    class MixerRepoDB : IMixerRepoDB
    {
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
    }
}
