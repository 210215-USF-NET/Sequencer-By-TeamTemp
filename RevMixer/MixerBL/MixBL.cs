using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MixerDL;
using MixerModels;

namespace MixerBL
{
    public class MixBL : IMixerBL
    {
        private IMixerRepoDB _repo;
        public MixBL(IMixerRepoDB repo)
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
        public async Task<UserProject> AddUserProjectAsync(UserProject newUserProject)
        {
            //Todo: Add BL
            return await _repo.AddUserProjectAsync(newUserProject);
        }
        public async Task<PlayList> AddPlayListAsync(PlayList newPlayList)
        {
            //Todo: Add BL
            return await _repo.AddPlayListAsync(newPlayList);
        }
        public async Task<MusicPlaylist> AddMusicPlaylistAsync(MusicPlaylist newMusicPlaylist)
        {
            //Todo: Add BL
            return await _repo.AddMusicPlaylistAsync(newMusicPlaylist);
        }
        public async Task<Comments> AddCommentAsync(Comments newComment)
        {
            //Todo: Add BL
            return await _repo.AddCommentAsync(newComment);
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
        public async Task<UserProject> DeleteUserProjectAsync(UserProject userProject2BDeleted)
        {
            return await _repo.DeleteUserProjectAsync(userProject2BDeleted);
        }
        public async Task<PlayList> DeletePlayListAsync(PlayList playlist2BDeleted)
        {
            return await _repo.DeletePlayListAsync(playlist2BDeleted);
        }
        public async Task<MusicPlaylist> DeleteMusicPlaylistAsync(MusicPlaylist musicPlaylist2BDeleted)
        {
            return await _repo.DeleteMusicPlaylistAsync(musicPlaylist2BDeleted);
        }
        public async Task<Comments> DeleteCommentAsync(Comments comment2BDeleted)
        {
            return await _repo.DeleteCommentAsync(comment2BDeleted);
        }
        public async Task<UploadMusic> GetUploadedMusicByIDAsync(int id)
        {
            //Todo: check if the name given is not null or empty string 
            return await _repo.GetUploadedMusicByIDAsync(id);
        }
        public async Task<List<UploadMusic>> GetUploadedMusicByUserIDAsync(int userid)
        {
            //Todo: check if the name given is not null or empty string 
            return await _repo.GetUploadedMusicByUserIDAsync(userid);
        }

        public async Task<User> GetUserByIDAsync(int id)
        {
            //Todo: check if the name given is not null or empty string 
            return await _repo.GetUserByIDAsync(id);
        }
        public async Task<SavedProject> GetSavedProjectByIDAsync(int savedProjectID)
        {
            //Todo: check if the name given is not null or empty string 
            return await _repo.GetSavedProjectByIDAsync(savedProjectID);
        }
        public async Task<Sample> GetSampleByIDAsync(int sampleID)
        {
            //Todo: check if the name given is not null or empty string 
            return await _repo.GetSampleByIDAsync(sampleID);
        }
        public async Task<Track> GetTrackByIDAsync(int trackID)
        {
            //Todo: check if the name given is not null or empty string 
            return await _repo.GetTrackByIDAsync(trackID);
        }
        public async Task<Pattern> GetPatternByIDAsync(int patternID)
        {
            //Todo: check if the name given is not null or empty string 
            return await _repo.GetPatternByIDAsync(patternID);
        }
        public async Task<UserProject> GetUserProjectByIDAsync(int id)
        {
            //Todo: check if the name given is not null or empty string 
            return await _repo.GetUserProjectByIDAsync(id);
        }
        public async Task<PlayList> GetPlayListByIDAsync(int id)
        {
            //Todo: check if the name given is not null or empty string 
            return await _repo.GetPlayListByIDAsync(id);
        }
        public async Task<MusicPlaylist> GetMusicPlaylistByIDAsync(int id)
        {
            //Todo: check if the name given is not null or empty string 
            return await _repo.GetMusicPlaylistByIDAsync(id);
        }
        public async Task<Comments> GetCommentByIDAsync(int id)
        {
            //Todo: check if the name given is not null or empty string 
            return await _repo.GetCommentByIDAsync(id);
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
        public async Task<List<UserProject>> GetUserProjectsAsync()
        {
            //TODO add BL
            return await _repo.GetUserProjectsAsync();
        }
        public async Task<List<PlayList>> GetPlayListsAsync()
        {
            //TODO add BL
            return await _repo.GetPlayListsAsync();
        }
        public async Task<List<MusicPlaylist>> GetMusicPlaylistsAsync()
        {
            //TODO add BL
            return await _repo.GetMusicPlaylistsAsync();
        }
        public async Task<List<Comments>> GetCommentsAsync()
        {
            //TODO add BL
            return await _repo.GetCommentsAsync();
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

        public async Task<UploadMusic> UpdateUploadedMusicAsync(UploadMusic uploadedMusic2BUpdated)
        {
            return await _repo.UpdateUploadedMusicAsync(uploadedMusic2BUpdated);
        }
        public async Task<UserProject> UpdateUserProjectAsync(UserProject userProject2BUpdated)
        {
            return await _repo.UpdateUserProjectAsync(userProject2BUpdated);
        }
        public async Task<PlayList> UpdatePlayListAsync(PlayList playlist2BUpdated)
        {
            return await _repo.UpdatePlayListAsync(playlist2BUpdated);
        }
        public async Task<MusicPlaylist> UpdateMusicPlaylistAsync(MusicPlaylist musicPlaylist2BUpdated)
        {
            return await _repo.UpdateMusicPlaylistAsync(musicPlaylist2BUpdated);
        }
        public async Task<Comments> UpdateCommentAsync(Comments comment2BUpdated)
        {
            return await _repo.UpdateCommentAsync(comment2BUpdated);
        }

        public async Task<User> GetUserByEmail(string userEmail)
        {
            User user2Return = await _repo.GetUserByEmail(userEmail);

            if (user2Return == null)
            {
                user2Return = new User();
                user2Return.Email = userEmail;
                return await _repo.AddUserAsync(user2Return);
            }
            else
            {
                return user2Return;
            }
        }


        public async Task<List<Comments>> GetCommentsByMusicIDAsync(int id)
        {
            return await _repo.GetCommentsByMusicIDAsync(id);
        }
    }
}