#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("AD5cXmwj9eQjULYy3myl+Ql+x4JLycMMe1T3ohAsHBcTWWw/8YCcXmjaWXpoVV5Rct4Q3q9VWVlZXVhbInY2JaG2IbvunzX4VgDEJ4ODyHbE8nNvaPrhkJC/Nf4PpNXrmqa0UNpZV1ho2llSWtpZWVj40zSSgjjGl8U6ZBgFyu/SOfj5uRYlGJTTTIniqj3otyVAffVygxGyJIrO0++lm2ftIOeCNqtR0VM2O6kSPiVaOG/m77afnu53wq9ZrldI4UoW/NsYFbkkbG7Kjd7ZSASH5FbCykKjACN3OSDePLytpifQkXXZE8l2pRysJbcEMtlo/B3VKcLgIEzcCd5HSWi3hNt5+ecazk6rRYMpa3dcGyOWHdQwBI4/5m9l5cAAp1pbWVhZ");
        private static int[] order = new int[] { 9,4,9,7,12,12,8,12,8,13,11,12,12,13,14 };
        private static int key = 88;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
