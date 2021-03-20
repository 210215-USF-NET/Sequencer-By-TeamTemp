﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MixerDL;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MixerDL.Migrations
{
    [DbContext(typeof(MixerDBContext))]
    partial class MixerDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("MixerModels.Comments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<DateTime>("CommentData")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UploadMusicId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UploadMusicId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("MixerModels.MusicPlaylist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("MusicId")
                        .HasColumnType("integer");

                    b.Property<int>("PlayListId")
                        .HasColumnType("integer");

                    b.Property<int?>("UploadMusicId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PlayListId");

                    b.HasIndex("UploadMusicId");

                    b.ToTable("MusicPlaylist");
                });

            modelBuilder.Entity("MixerModels.Pattern", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("PatternData")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Pattern");
                });

            modelBuilder.Entity("MixerModels.PlayList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PlayList");
                });

            modelBuilder.Entity("MixerModels.Sample", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("SampleLink")
                        .HasColumnType("text");

                    b.Property<string>("SampleName")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Sample");
                });

            modelBuilder.Entity("MixerModels.SavedProject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("BPM")
                        .HasColumnType("integer");

                    b.Property<string>("ProjectName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SavedProject");
                });

            modelBuilder.Entity("MixerModels.Track", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("PatternId")
                        .HasColumnType("integer");

                    b.Property<int>("ProjectId")
                        .HasColumnType("integer");

                    b.Property<int>("SampleId")
                        .HasColumnType("integer");

                    b.Property<int?>("SavedProjectId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PatternId");

                    b.HasIndex("SampleId");

                    b.HasIndex("SavedProjectId");

                    b.ToTable("Track");
                });

            modelBuilder.Entity("MixerModels.UploadMusic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Likes")
                        .HasColumnType("integer");

                    b.Property<string>("MusicFilePath")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Plays")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UploadMusic");
                });

            modelBuilder.Entity("MixerModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("MixerModels.UserProject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Owner")
                        .HasColumnType("boolean");

                    b.Property<int>("ProjectId")
                        .HasColumnType("integer");

                    b.Property<int?>("SavedProjectId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SavedProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("UserProject");
                });

            modelBuilder.Entity("MixerModels.Comments", b =>
                {
                    b.HasOne("MixerModels.UploadMusic", "UploadedMusic")
                        .WithMany("Comments")
                        .HasForeignKey("UploadMusicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MixerModels.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UploadedMusic");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MixerModels.MusicPlaylist", b =>
                {
                    b.HasOne("MixerModels.PlayList", "PlayList")
                        .WithMany("MusicPlaylist")
                        .HasForeignKey("PlayListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MixerModels.UploadMusic", "UploadMusic")
                        .WithMany("MusicPlaylists")
                        .HasForeignKey("UploadMusicId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("PlayList");

                    b.Navigation("UploadMusic");
                });

            modelBuilder.Entity("MixerModels.PlayList", b =>
                {
                    b.HasOne("MixerModels.User", "User")
                        .WithMany("PlayLists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MixerModels.Sample", b =>
                {
                    b.HasOne("MixerModels.User", "User")
                        .WithMany("Sample")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MixerModels.Track", b =>
                {
                    b.HasOne("MixerModels.Pattern", "Pattern")
                        .WithMany("Tracks")
                        .HasForeignKey("PatternId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("MixerModels.Sample", "Sample")
                        .WithMany("Track")
                        .HasForeignKey("SampleId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("MixerModels.SavedProject", "SavedProject")
                        .WithMany("Tracks")
                        .HasForeignKey("SavedProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Pattern");

                    b.Navigation("Sample");

                    b.Navigation("SavedProject");
                });

            modelBuilder.Entity("MixerModels.UploadMusic", b =>
                {
                    b.HasOne("MixerModels.User", "User")
                        .WithMany("UploadMusics")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MixerModels.UserProject", b =>
                {
                    b.HasOne("MixerModels.SavedProject", "SavedProject")
                        .WithMany("UserProjects")
                        .HasForeignKey("SavedProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MixerModels.User", "User")
                        .WithMany("UserProjects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SavedProject");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MixerModels.Pattern", b =>
                {
                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("MixerModels.PlayList", b =>
                {
                    b.Navigation("MusicPlaylist");
                });

            modelBuilder.Entity("MixerModels.Sample", b =>
                {
                    b.Navigation("Track");
                });

            modelBuilder.Entity("MixerModels.SavedProject", b =>
                {
                    b.Navigation("Tracks");

                    b.Navigation("UserProjects");
                });

            modelBuilder.Entity("MixerModels.UploadMusic", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("MusicPlaylists");
                });

            modelBuilder.Entity("MixerModels.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("PlayLists");

                    b.Navigation("Sample");

                    b.Navigation("UploadMusics");

                    b.Navigation("UserProjects");
                });
#pragma warning restore 612, 618
        }
    }
}