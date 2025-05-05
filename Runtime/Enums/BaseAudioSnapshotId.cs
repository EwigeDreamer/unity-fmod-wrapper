using FMOD;

namespace ED.FMODWrapper.Enums
{
    public abstract class BaseAudioSnapshotId : BaseAudioId
    {
        protected BaseAudioSnapshotId(string name, GUID value) : base(name, value) { }
    }
}