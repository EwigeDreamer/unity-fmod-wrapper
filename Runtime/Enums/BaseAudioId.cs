using ED.Additional.Utilities;
using FMOD;

namespace ED.FMODWrapper.Enums
{
    public class BaseAudioId : TypeSafeValueEnum<GUID>
    {
        protected BaseAudioId(string name, GUID value) : base(name, value) { }
    }
}