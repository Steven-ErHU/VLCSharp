using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VLC.MediaPlayer.Presentation;
using System.IO;
using VLC.MediaLibrary.Repository.LocalFile;
using System.Collections.Generic;
using VLC.Common;

namespace VLC.MediaPlayer.Presentation.Tests
{
    [TestClass]
    public class MediaLibraryOpenLocalFolderTest : IMediaLibraryView
    {
        public string MediaFilename
        {
            get
            {
                return Path.Combine(Directory.GetCurrentDirectory(), "VLC.MediaPlayer.Presentation.Tests.dll");
            }
        }

        public string MediaFolderName
        {
            get
            {
                return Directory.GetCurrentDirectory();
            }
        }

        [TestMethod]
        public void TestOpenFolder_NotNull()
        {
            //Arrange
            MediaLibraryModel viewModel = new MediaLibraryModel(new LocalFileRepository());

            //Action
            viewModel.OpenFolderCommand.Execute(this);

            //Assert
            var medias = viewModel.Medias as List<MediaFile>;
            Assert.AreNotEqual(medias, null);
        }


        [TestMethod]
        public void TestOpenFolder_NotEmpty()
        {
            //Arrange
            MediaLibraryModel viewModel = new MediaLibraryModel(new LocalFileRepository());

            //Action
            viewModel.OpenFolderCommand.Execute(this);

            //Assert
            var medias = viewModel.Medias as List<MediaFile>;
            Assert.AreNotEqual(medias.Count, 0);
        }

        [TestMethod]
        public void TestOpenFolder_Overrided()
        {
            //Arrange
            MediaLibraryModel viewModel = new MediaLibraryModel(new LocalFileRepository());

            //Action
            viewModel.OpenFolderCommand.Execute(this);
            var medias = viewModel.Medias as List<MediaFile>;
            int count1 = medias.Count;

            viewModel.OpenFolderCommand.Execute(this);
            medias = viewModel.Medias as List<MediaFile>;
            int count2 = medias.Count;

            //Assert
            Assert.AreNotEqual(count1 * 2, count2);
        }

        [TestMethod]
        public void TestOpenFolder_ClearWork()
        {
            //Arrange
            MediaLibraryModel viewModel = new MediaLibraryModel(new LocalFileRepository());

            //Action
            viewModel.OpenFolderCommand.Execute(this);
            viewModel.ClearLibraryCommand.Execute(this);
            //Assert
            var medias = viewModel.Medias as List<MediaFile>;
            Assert.AreEqual(medias.Count,0);
        }
    }
}
