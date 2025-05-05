using FMOD;

namespace ED.FMODWrapper.Enums
{
    public abstract class BaseAudioBankId : BaseAudioId
    {
        protected BaseAudioBankId(string name, GUID value) : base(name, value) { }
    }
}