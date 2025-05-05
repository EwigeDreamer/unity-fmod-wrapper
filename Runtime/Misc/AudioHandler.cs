using System.Collections.Generic;
using ED.FMODWrapper.Enums;
using ED.FMODWrapper.Interfaces;
using FMOD;
using FMOD.Studio;
using FMODUnity;

namespace ED.FMODWrapper.Misc
{
    public class AudioHandler : IAudioHandler
    {
        private EventInstance _instance;
        private readonly Dictionary<string, PARAMETER_DESCRIPTION> _parameters = new();

        public AudioHandler(BaseAudioEventId id)
        {
            _instance = RuntimeManager.CreateInstance((GUID)id);
        }
        public AudioHandler(BaseAudioSnapshotId id)
        {
            _instance = RuntimeManager.CreateInstance((GUID)id);
        }
        public AudioHandler(EventReference reference)
        {
            _instance = RuntimeManager.CreateInstance(reference);
        }

        public float Volume
        {
            get => _instance.isValid() && _instance.getVolume(out var result) == RESULT.OK ? result : default;
            set { if (_instance.isValid()) _instance.setVolume(value); }
        }

        public float Pitch
        {
            get => _instance.isValid() && _instance.getPitch(out var result) == RESULT.OK ? result : default;
            set { if (_instance.isValid()) _instance.setPitch(value); }
        }

        public bool Paused
        {
            get => _instance.isValid() && _instance.getPaused(out var result) == RESULT.OK ? result : default;
            set { if (_instance.isValid()) _instance.setPaused(value); }
        }

        public void Play()
        {
            if (_instance.isValid()) _instance.start();
        }

        public void Stop(bool immediate = false)
        {
            if (_instance.isValid()) _instance.stop(immediate ? STOP_MODE.IMMEDIATE : STOP_MODE.ALLOWFADEOUT);
        }

        public void SetLocation(AudioAttributes3D attributes)
        {
            if (!_instance.isValid()) return;
            _instance.set3DAttributes(attributes);
        }

        public void SetFloat(BaseAudioParameterId id, float value)
        {
            if (!_instance.isValid()) return;
            if (!_parameters.TryGetValue(id, out var pDesc))
            {
                var res = _instance.getDescription(out var eDesc);
                if (res != RESULT.OK) return;
                res = eDesc.getParameterDescriptionByName(id, out pDesc);
                if (res != RESULT.OK) return;
                _parameters[id] = pDesc;
            }
            _instance.setParameterByID(pDesc.id, value);
        }

        public void Dispose()
        {
            if (!_instance.isValid()) return;
            _instance.stop(STOP_MODE.IMMEDIATE);
            _instance.release();
            _instance.clearHandle();
            _parameters.Clear();
        }
    }
}