using System;
using System.Collections.Generic;
using ED.FMODWrapper.Enums;
using ED.FMODWrapper.Interfaces;
using ED.FMODWrapper.Misc;
using FMOD;
using FMOD.Studio;
using FMODUnity;

namespace ED.FMODWrapper
{
    public class AudioService : IAudioService, IDisposable
    {
        private readonly Dictionary<string, Bus> _busDict = new();
        private readonly Dictionary<string, VCA> _vcaDict = new();
        private readonly Dictionary<string, PARAMETER_DESCRIPTION> _parameters = new();
        
        public void PlayOneShot(BaseAudioEventId id, AudioAttributes3D attributes3d, params (BaseAudioParameterId id, float value)[] parameters) => PlayOneShotInternal((GUID)id, attributes3d, parameters);
        public void PlayOneShot(BaseAudioSnapshotId id, AudioAttributes3D attributes3d, params (BaseAudioParameterId id, float value)[] parameters) => PlayOneShotInternal((GUID)id, attributes3d, parameters);
        public void PlayOneShot(EventReference reference, AudioAttributes3D attributes3d, params (BaseAudioParameterId id, float value)[] parameters) => PlayOneShotInternal(reference.Guid, attributes3d, parameters);

        public IAudioHandler CreateHandler(BaseAudioEventId id) => new AudioHandler(id);
        public IAudioHandler CreateHandler(BaseAudioSnapshotId id) => new AudioHandler(id);
        public IAudioHandler CreateHandler(EventReference reference) => new AudioHandler(reference);

        public void SetVolume(BaseAudioBusId id, float value)
        {
            if (!_busDict.TryGetValue(id, out var bus))
                _busDict[id] = bus = RuntimeManager.GetBus(id);
            if (!bus.isValid()) return;
            bus.setVolume(value);
        }
        
        public void SetVolume(BaseAudioVcaId id, float value)
        {
            if (!_vcaDict.TryGetValue(id, out var vca))
                _vcaDict[id] = vca = RuntimeManager.GetVCA(id);
            if (!vca.isValid()) return;
            vca.setVolume(value);
        }

        public void SetFloat(BaseAudioParameterId id, float value)
        {
            if (!_parameters.TryGetValue(id, out var pDesc))
            {
                var res = RuntimeManager.StudioSystem.getParameterDescriptionByName(id, out pDesc);
                if (res != RESULT.OK) return;
                _parameters[id] = pDesc;
            }
            RuntimeManager.StudioSystem.setParameterByID(pDesc.id, value);
        }

        private void PlayOneShotInternal(GUID guid, AudioAttributes3D attributes3d, (BaseAudioParameterId id, float value)[] parameters)
        {
            var instance = RuntimeManager.CreateInstance(guid);
            instance.set3DAttributes(attributes3d);
            foreach (var pair in parameters)
                instance.setParameterByName(pair.id, pair.value);
            instance.start();
            instance.release();
            instance.clearHandle();
        }

        public void Dispose()
        {
            _busDict.Clear();
            _vcaDict.Clear();
            _parameters.Clear();
        }
    }
}