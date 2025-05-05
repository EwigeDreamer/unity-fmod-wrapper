using FMOD;

namespace ED.FMODWrapper.Enums
{
    public abstract class BaseAudioEventId : BaseAudioId
    {
        protected BaseAudioEventId(string name, GUID value) : base(name, value) { }
    }
}