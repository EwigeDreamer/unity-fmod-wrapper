using System;
using ED.FMODWrapper.Enums;
using ED.FMODWrapper.Misc;

namespace ED.FMODWrapper.Interfaces
{
    public interface IAudioHandler : IDisposable
    {
        float Volume { get; set; }
        float Pitch { get; set; }
        bool Paused { get; set; }
        void Play();
        void Stop(bool immediate = false);
        void SetLocation(AudioAttributes3D attributes);
        void SetFloat(BaseAudioParameterId id, float value);
    }
}