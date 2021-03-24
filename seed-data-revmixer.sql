insert into "User" ("Email", "UserName", "IsAdmin")
VALUES('westondavidson@outlook.com', 'westondavidson', 'true'),
('jacklong@gmail.com', 'jlong', 'false');



insert into "SavedProject" ("ProjectName", "BPM")
VALUES('epic project', '140'),
('insane_3242020_V3', '160')



--user with id of 1 is project owner for project 1, user with ID of 2 is a collaborator on project 1
--user with id of 2 is owner on project 2, user with ID of 1 is collaborator of project 2
insert into "UserProject" ("UserId", "ProjectId", "Owner")
values('1', '1', 'true'),
('2', '1', 'false'),
('1', '2', 'false'),
('2', '2', 'true');


--example: user 1 has a snare sample named snare_4 which is stored in our bucket with the name snare_4 (the values of sample name and storage name can be different)
insert into "Sample" ("UserId", "SampleName", "SampleLink")
VALUES('1', 'snare_4', 'snare_4'),
('2', 'kick_8', 'kick_8');


--by storing these as strings of 1 and 0, we can easily retrieve and parse the value to set on/off state of track pattern "buttons"
insert into "Pattern" ("PatternData")
VALUES('10110111'),
('00010001')



-- example: our track will be associated with project with ID 1, and the sample will be sample associated with ID of 1, 
-- and the pattern associated with the track will be that with ID 2
-- we also have a track with pattern with ID 3 and sample with ID 2 associated with track ID 1!
insert into "Track" ("ProjectId", "SampleId", "PatternId")
VALUES('1', '1', '2'),
('1', '2', '3'),
('2', '1', '2')



--example: user with ID 1 has created a playlist called sick EDM
insert into "PlayList" ("UserId", "Name")
values('1', 'Sick EDM'),
('2', 'Country');





insert into "UploadMusic" ("UserId", "MusicFilePath", "Name", "UploadDate", "Likes", "Plays")
values('1', 'cool_song', 'Jumping Jacks', current_timestamp, '3409', '90845'),
('2', 'crazy_mix', 'BBCRadio1Xtra Mix - Jack', current_timestamp, '8709', '3937829')



insert into "Comments" ("Comment", "CommentData", "UserId", "UploadMusicId")
VALUES('wow this song is so sick what the heck!', current_timestamp, '2', '1'),
('what.. this song transition... amazing!', current_timestamp, '1', '2')

insert into "MusicPlaylist" ("PlayListId", "MusicId")
VALUES('1', '1'),
('1', '2'),
('2', '1')



--INSERTED ALL ABOVE STUFF ALREADY--

