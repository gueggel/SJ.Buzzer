/*!
 * ========================================================================
 * @project    SJ.Buzzer
 *
 * Eine Sounddatei abspielen.
 *
 * @file       Sound.cs
 * @author     Stefan Jahn <development@stefanjahn.de>
 * @copyright  Copyright (C) 2012-2021 Stefan Jahn
 * @link       https://stefanjahn.de
 *
 * @date       24.05.2021
 * @version    20210524
 * @license    http://www.gnu.org/copyleft/gpl.html
 * ------------------------------------------------------------------------
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 * ========================================================================
 */

using System;
using System.IO;

using SharpDX.Multimedia;
using SharpDX.XAudio2;

namespace SJ.App.Buzzer.Helper
{
    /// <summary>
    /// Eine Sounddatei abspielen.
    /// </summary>
    public class Sound : IDisposable
    {
        #region Properties

        /// <summary>
        /// Sound-Device
        /// </summary>
        private XAudio2 Device
        {
            get;
            set;
        }

        /// <summary>
        /// Format des Streams (Sounddatei)
        /// </summary>
        private WaveFormat Format
        {
            get;
            set;
        }

        /// <summary>
        /// Sounddatei
        /// </summary>
        private SoundStream Stream
        {
            get;
            set;
        }

        /// <summary>
        /// Audiobuffer
        /// </summary>
        private AudioBuffer Buffer
        {
            get;
            set;
        }

        /// <summary>
        /// Kanal/Stimme fuer die Ausgabe der Sounddatei.
        /// </summary>
        private SourceVoice Voice
        {
            get;
            set;
        }

        /// <summary>
        /// True = SOund wird gearde abgespielt
        /// </summary>
        public bool IsPlaying
        {
            get;
            private set;
        }

        #endregion

        #region Konstruktor

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="device">Sound-Device</param>
        /// <param name="stream">Sounddatei (Stream)</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Sound( XAudio2 device, Stream stream )
        {
            if( device == null )
            {
                throw new ArgumentNullException( nameof( device ) );
            }

            if( stream == null )
            {
                throw new ArgumentNullException( nameof( stream ) );
            }

            Device = device;

            IsPlaying = false;
            Stream = new SoundStream( stream );
            Format = Stream.Format;

            Buffer = new AudioBuffer
            {
                Stream = Stream.ToDataStream(),
                AudioBytes = (int)Stream.Length,
                Flags = BufferFlags.EndOfStream
            };

            Buffer.LoopCount = AudioBuffer.LoopInfinite;
        }

        #endregion


        #region Destruktor

        /// <summary>
        /// Destruktor
        /// </summary>
        ~Sound()
        {
            Dispose( false );
        }


        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            Dispose( true );
            GC.SuppressFinalize( this );
        }


        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing">True = Managed Resourcen freigeben</param>
        protected virtual void Dispose( bool disposing )
        {
            //Managed Resourcen freigeben
            if( disposing )
            {
                Voice?.Stop();
                Voice?.Dispose();
                Stream?.Close();
                Stream?.Dispose();
            }

            //Unmanaged Resourcen freigeben
        }


        #endregion


        #region Methoden

        /// <summary>
        /// Sound 1mal abspielen.
        /// </summary>
        public void Play() => Play( 0 );

        /// <summary>
        /// Sound in Endlosschleife abspielen.
        /// </summary>
        public void PlayLoop() => Play( AudioBuffer.LoopInfinite );

        /// <summary>
        /// Sound abspielen.
        /// </summary>
        private void Play( int loopCount )
        {
            if( IsPlaying )
            {
                Voice?.Stop();
            }

            Buffer.LoopCount = loopCount;
            Voice = new SourceVoice( Device, Format, true );
            Voice.SubmitSourceBuffer( Buffer, Stream.DecodedPacketsInfo );

            Voice.Start();
            IsPlaying = true;
        }


        /// <summary>
        /// Sound stoppen.
        /// </summary>
        public void Stop()
        {
            Voice?.Stop();
            IsPlaying = false;
        }

        #endregion
    }
}
