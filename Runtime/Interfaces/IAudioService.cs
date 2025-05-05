using ED.FMODWrapper.Enums;
using ED.FMODWrapper.Misc;
using FMODUnity;

namespace ED.FMODWrapper.Interfaces
{
    public interface IAudioService
    {
        void PlayOneShot(BaseAudioEventId id, AudioAttributes3D attributes3d, params (BaseAudioParameterId id, float value)[] parameters);
        void PlayOneShot(BaseAudioSnapshotId id, AudioAttributes3D attributes3d, params (BaseAudioParameterId id, float value)[] parameters);
        void PlayOneShot(EventReference reference, AudioAttributes3D attributes3d, params (BaseAudioParameterId id, float value)[] parameters);
        IAudioHandler CreateHandler(BaseAudioEventId id);
        IAudioHandler CreateHandler(BaseAudioSnapshotId id);
        IAudioHandler CreateHandler(EventReference reference);
        void SetVolume(BaseAudioBusId id, float value);
        void SetVolume(BaseAudioVcaId id, float value);
        void SetFloat(BaseAudioParameterId id, float value);
    }
}