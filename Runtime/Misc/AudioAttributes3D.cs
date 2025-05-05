using FMOD;
using FMODUnity;
using UnityEngine;

namespace ED.FMODWrapper.Misc
{
    public struct AudioAttributes3D
    {
        public Vector3? position;
        public Vector3? velocity;
        public Vector3? forward;
        public Vector3? up;

        public static AudioAttributes3D Default => default;

        public static AudioAttributes3D FromPosition(Vector3 position)
        {
            return new AudioAttributes3D
            {
                position = position
            };
        }

        public static AudioAttributes3D FromPositionAndVelocity(Vector3 position, Vector3 velocity)
        {
            return new AudioAttributes3D
            {
                position = position,
                velocity = velocity
            };
        }

        public static AudioAttributes3D FromTransform(Transform transform)
        {
            return new AudioAttributes3D
            {
                position = transform.position,
                forward = transform.forward,
                up = transform.up
            };
        }

        public static AudioAttributes3D FromRigidbody(Rigidbody rigidbody)
        {
            return new AudioAttributes3D
            {
                position = rigidbody.position,
#if UNITY_6000_0_OR_NEWER
                velocity = rigidbody.linearVelocity,
#else
                velocity = rigidbody.velocity,
#endif
                forward = rigidbody.transform.forward,
                up = rigidbody.transform.up
            };
        }

        public static AudioAttributes3D FromRigidbody(Rigidbody2D rigidbody)
        {
            return new AudioAttributes3D
            {
                position = rigidbody.position,
#if UNITY_6000_0_OR_NEWER
                velocity = rigidbody.linearVelocity,
#else
                velocity = rigidbody.velocity,
#endif
                forward = rigidbody.transform.forward,
                up = rigidbody.transform.up
            };
        }

        public static implicit operator ATTRIBUTES_3D(AudioAttributes3D attributes)
        {
            return new ATTRIBUTES_3D
            {
                position = (attributes.position ?? Vector3.zero).ToFMODVector(),
                velocity = (attributes.velocity ?? Vector3.zero).ToFMODVector(),
                forward = (attributes.forward ?? Vector3.forward).ToFMODVector(),
                up = (attributes.up ?? Vector3.up).ToFMODVector(),
            };
        }
    }
}