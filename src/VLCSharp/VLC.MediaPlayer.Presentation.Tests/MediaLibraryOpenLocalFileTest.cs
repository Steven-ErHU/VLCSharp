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
    public class MediaLibraryOpenLocalFileTest: IMediaLibraryView
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
        public void TestOpenFile_NotNull()
        {
            //Arrange
            MediaLibraryModel viewModel = new MediaLibraryModel(new LocalFileRepository());

            //Action
            viewModel.OpenFileCommand.Execute(this);

            //Assert
            var medias = viewModel.Medias as List<MediaFile>;
            Assert.AreNotEqual(medias, null);
        }


        [TestMethod]
        public void TestOpenFile_Count()
        {
            //Arrange
            MediaLibraryModel viewModel = new MediaLibraryModel(new LocalFileRepository());

            //Action
            viewModel.OpenFileCommand.Execute(this);
            viewModel.OpenFileCommand.Execute(this);
            //Assert
            var medias = viewModel.Medias as List<MediaFile>;
            Assert.AreEqual(medias.Count, 2);
        }

        [TestMethod]
        public void TestOpenFile_ClearWork()
        {
            //Arrange
            MediaLibraryModel viewModel = new MediaLibraryModel(new LocalFileRepository());

            //Action
            viewModel.OpenFileCommand.Execute(this);
            viewModel.OpenFileCommand.Execute(this);
            var medias = viewModel.Medias as List<MediaFile>;

            //Assert
            Assert.AreEqual(medias.Count, 2);

            //Action
            viewModel.ClearLibraryCommand.Execute(this);
            //Assert
            medias = viewModel.Medias as List<MediaFile>;
            Assert.AreEqual(medias.Count, 0);
        }

        [TestMethod]
        public void TestOpenFile_RightFile()
        {
            //Arrange
            MediaLibraryModel viewModel = new MediaLibraryModel(new LocalFileRepository());

            //Action
            viewModel.OpenFileCommand.Execute(this);

            //Assert
            var medias = viewModel.Medias as List<MediaFile>;
            Assert.AreEqual(medias[0].Source, MediaFilename);
        }
    }
}
