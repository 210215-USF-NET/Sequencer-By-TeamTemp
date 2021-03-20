using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MixerDL;
using MixerModels;

namespace MixerBL
{
    public class MixerBL : IMixerBL
    {
        private IMixerRepoDB _repo;
        public MixerBL(IMixerRepoDB repo)
        {
            _repo = repo;
        }
        public async Task<UploadMusic> AddUploadedMusicAsync(UploadMusic newUploadedMusic)
        {
            //Todo: Add BL
            return await _repo.AddUploadedMusicAsync(newUploadedMusic);
        }
        public async Task<User> AddUserAsync(User newUser)
        {
            //Todo: Add BL
            return await _repo.AddUserAsync(newUser);
        }
        public async Task<SavedProject> AddSavedProjectAsync(SavedProject newSavedProject)
        {
            //Todo: Add BL
            return await _repo.AddSavedProjectAsync(newSavedProject);
        }
        public async Task<Sample> AddSampleAsync(Sample newSample)
        {
            //Todo: Add BL
            return await _repo.AddSampleAsync(newSample);
        }
        public async Task<Track> AddTrackAsync(Track newTrack)
        {
            //Todo: Add BL
            return await _repo.AddTrackAsync(newTrack);
        }
        public async Task<Pattern> AddPatternAsync(Pattern newPattern)
        {
            //Todo: Add BL
            return await _repo.AddPatternAsync(newPattern);
        }
        public async Task<UploadMusic> DeleteUploadedMusicAsync(UploadMusic uploadedMusic2BDeleted)
        {
            return await _repo.DeleteUploadedMusicAsync(uploadedMusic2BDeleted);
        }
        public async Task<User> DeleteUserAsync(User user2BDeleted)
        {
            return await _repo.DeleteUserAsync(user2BDeleted);
        }
        public async Task<SavedProject> DeleteSavedProjectAsync(SavedProject savedProject2BDeleted)
        {
            return await _repo.DeleteSavedProjectAsync(savedProject2BDeleted);
        }
        public async Task<Sample> DeleteSampleAsync(Sample sample2BDeleted)
        {
            return await _repo.DeleteSampleAsync(sample2BDeleted);
        }
        public async Task<Track> DeleteTrackAsync(Track track2BDeleted)
        {
            return await _repo.DeleteTrackAsync(track2BDeleted);
        }
        public async Task<Pattern> DeletePatternAsync(Pattern pattern2BDeleted)
        {
            return await _repo.DeletePatternAsync(pattern2BDeleted);
        }

        public async Task<UploadMusic> GetUploadedMusicByNameAsync(string name)
        {
            //Todo: check if the name given is not null or empty string 
            return await _repo.GetUploadedMusicByNameAsync(name);
        }
        public async Task<User> GetUserByNameAsync(string name)
        {
            //Todo: check if the name given is not null or empty string 
            return await _repo.GetUserByNameAsync(name);
        }
        public async Task<SavedProject> GetSavedProjectByNameAsync(string name)
        {
            //Todo: check if the name given is not null or empty string 
            return await _repo.GetSavedProjectByNameAsync(name);
        }
        public async Task<Sample> GetSampleByNameAsync(string name)
        {
            //Todo: check if the name given is not null or empty string 
            return await _repo.GetSampleByNameAsync(name);
        }
        public async Task<Track> GetTrackByNameAsync(string name)
        {
            //Todo: check if the name given is not null or empty string 
            return await _repo.GetTrackByNameAsync(name);
        }
        public async Task<Pattern> GetPatternByNameAsync(string name)
        {
            //Todo: check if the name given is not null or empty string 
            return await _repo.GetPatternByNameAsync(name);
        }

        public async Task<List<UploadMusic>> GetUploadedMusicAsync()
        {
            //TODO add BL
            return await _repo.GetUploadedMusicAsync();
        }
        public async Task<List<User>> GetUsersAsync()
        {
            //TODO add BL
            return await _repo.GetUsersAsync();
        }
        public async Task<List<SavedProject>> GetSavedProjectsAsync()
        {
            //TODO add BL
            return await _repo.GetSavedProjectsAsync();
        }
        public async Task<List<Sample>> GetSamplesAsync()
        {
            //TODO add BL
            return await _repo.GetSamplesAsync();
        }
        public async Task<List<Track>> GetTracksAsync()
        {
            //TODO add BL
            return await _repo.GetTracksAsync();
        }
        public async Task<List<Pattern>> GetPatternsAsync()
        {
            //TODO add BL
            return await _repo.GetPatternsAsync();
        }

        public async Task<Sample> UpdateSampleAsync(Sample sample2BUpdated)
        {
            return await _repo.UpdateSampleAsync(sample2BUpdated);
        }
        public async Task<User> UpdateUserAsync(User user2BUpdated)
        {
            return await _repo.UpdateUserAsync(user2BUpdated);
        }
        public async Task<SavedProject> UpdateSavedProjectAsync(SavedProject savedProject2BUpdated)
        {
            return await _repo.UpdateSavedProjectAsync(savedProject2BUpdated);
        }

        public async Task<Track> UpdateTrackAsync(Track track2BUpdated)
        {
            return await _repo.UpdateTrackAsync(track2BUpdated);
        }
        public async Task<Pattern> UpdatePatternAsync(Pattern pattern2BUpdated)
        {
            return await _repo.UpdatePatternAsync(pattern2BUpdated);
        }

        public Task<UploadMusic> UpdateUploadedMusicAsync(UploadMusic uploadedMusic2BUpdated)
        {
            throw new NotImplementedException();
        }
    }
}