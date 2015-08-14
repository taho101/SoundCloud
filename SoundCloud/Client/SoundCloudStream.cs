using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NAudio;
using NAudio.Wave;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace SoundCloud.Client
{
    class SoundCloudStream
    {

        private Stream ms = new MemoryStream();

        private WaveOut playback = Properties.Settings.Default.Playback;

        public void PlayMp3FromUrl(string url)
        {
            //stop the song that is currently playing
            if ( this.playback != null) this.StopPlayback();

            new Thread(delegate(object o)
            {
                var response = WebRequest.Create(url).GetResponse();
                using (var stream = response.GetResponseStream())
                {
                    byte[] buffer = new byte[65536]; // 64KB chunks
                    int read;
                    while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        var pos = ms.Position;
                        ms.Position = ms.Length;
                        ms.Write(buffer, 0, read);
                        ms.Position = pos;
                    }
                }
            }).Start();

            // Pre-buffering some data to allow NAudio to start playing
            while (ms.Length < 65536 * 10)
                Thread.Sleep(1000);

            ms.Position = 0;
            using (WaveStream blockAlignedStream = new BlockAlignReductionStream(WaveFormatConversionStream.CreatePcmStream(new Mp3FileReader(ms))))
            {
                using (WaveOut waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
                {
                    waveOut.Init(blockAlignedStream);
                    waveOut.Play();
                    
                    //set currently playing song
                    Properties.Settings.Default.Playback = waveOut;

                    while (waveOut.PlaybackState == PlaybackState.Playing)
                    {
                        System.Threading.Thread.Sleep(10);
                        Application.DoEvents();
                    }
                }
            }
        }

        public void StopPlayback()
        {
            this.playback.Stop();
        }

        public void PausePlayback()
        {
            this.playback.Pause();
        }
    }
}
