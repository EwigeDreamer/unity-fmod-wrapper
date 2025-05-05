using FMOD;

namespace ED.FMODWrapper.Enums
{
    public abstract class BaseAudioVcaId : BaseAudioId
    {
        protected BaseAudioVcaId(string name, GUID value) : base(name, value) { }
    }
}