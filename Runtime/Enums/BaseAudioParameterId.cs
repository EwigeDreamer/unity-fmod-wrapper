using FMOD;

namespace ED.FMODWrapper.Enums
{
    public abstract class BaseAudioParameterId : BaseAudioId
    {
        protected BaseAudioParameterId(string name, GUID value) : base(name, value) { }
    }
}