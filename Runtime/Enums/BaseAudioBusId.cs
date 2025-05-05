using FMOD;

namespace ED.FMODWrapper.Enums
{
    public abstract class BaseAudioBusId : BaseAudioId
    {
        protected BaseAudioBusId(string name, GUID value) : base(name, value) { }
    }
}