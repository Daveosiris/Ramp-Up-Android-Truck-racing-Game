#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class AppleTangle
    {
        private static byte[] data = System.Convert.FromBase64String("MFNRIJIRMiAdFhk6lliW5x0RERFyfHUwY2RxfnRxYnQwZHVifWMwcR+NLeM7WTgK2O7epakeyU4MxtstmwmZzulbfOUXuzIgEvgILuhAGcMjJkogciEbIBkWE0UUFgMSRUMhAw+Vk5ULiS1XJ+K5i1CePMShgALID4HLDldA+xX9TmmUPfsmskdcRfxgfHUwU3ViZHl2eXNxZHl/fjBRZWB8dTBCf39kMFNRIA4HHSAmICQiJolcPWin/ZyLzONni+JmwmcgX9E08vvBp2DPH1XxN9rhfWj996UHB5AEO8B5V4RmGe7ke50+ULbnV11vJSIhJCAjJkoHHSMlICIgKSIhJCAwcX50MHN1YmR5dnlzcWR5f34wYEJ1fHlxfnN1MH9+MGR4eWMwc3VidCUzBVsFSQ2jhOfmjI7fQKrRSEC4zG4yJdo1xckfxnvEsjQzAeexvKcLrYNSNAI61x8Npl2MTnPYW5AHfHUwWX5zPiE2IDQWE0UUGwMNUWAYOxYRFRUXEhEGDnhkZGBjKj8/Z0m3FRlsB1BGAQ5kw6ebMytXs8V/PlC251ddbxhOIA8WE0UNMxQIIAYX/G0pk5tDMMMo1KGvil8ae+877CABFhNFFBoDGlFgYHx1MFl+cz4hFRATkhEfECCSERoSkhEREPSBuRlvUbiI6cHadow0ewHAs6v0CzrTD1nIZo8jBHWxZ4TZPRITERARs5IR2Qli5U0exW9Pi+I1E6pFn11NHeF3nxikMOfbvDwwf2CmLxEgnKdT3xQWAxJFQyEDIAEWE0UUGgMaUWBgu7NhgldDRdG/P1Gj6OvzYN32s1xnZz5xYGB8dT5zf30/cWBgfHVzcdBzI2fnKhc8RvvKHzEeyqpjCV+lZHl2eXNxZHUwcmkwcX5pMGBxYmQYTiCSEQEWE0UNMBSSERggkhEUIKEgSPxKFCKceKOfDc51Y+93TnWsaTBxY2NlfXVjMHFzc3VgZHF+c3WfY5Fw1gtLGT+CouhUWOBwKI4F5ckmb9GXRcm3iakiUuvIxWGObrFCVW4PXHtAhlGZ1GRyGwCTUZcjmpF5dnlzcWR5f34wUWVkeH9ieWRpIQYgBBYTRRQTAx1RYGB8dTBCf39kfnQwc39+dHlkeX9+YzB/djBlY3U2IDQWE0UUGwMNUWBgfHUwU3ViZC02dzCaI3rnHZLfzvuzP+lDekt0PyCR0xYYOxYRFRUXEhIgkaYKkaMWIB8WE0UNAxER7xQVIBMREe8gDWR4f2J5ZGkhBiAEFhNFFBMDHVFgIJIUqyCSE7OwExIREhIREiAdFhlicXNkeXN1MGNkcWR1fXV+ZGM+IK7kY4v+wnQf22lfJMiyLulo73vYOpZYlucdEREVFRAgciEbIBkWE0WFjmoctFebS8QGJyPb1B9d3gR5wTwwc3ViZHl2eXNxZHUwYH98eXNpFhNFDR4UBhQEO8B5V4RmGe7ke52lKr3kHx4QghuhMQY+ZMUsHctyBpIREBYZOpZYludzdBURIJHiIDoWaiCSEWYgHhYTRQ0fERHvFBQTEhEwf3YwZHh1MGR4dX4wcWBgfHlzcR0WGTqWWJbnHRERFRUQE5IRERBMQLqaxcr07MAZFyegZWUx");
        private static int[] order = new int[] { 13,42,22,16,8,49,15,8,15,48,53,32,15,45,38,20,54,59,54,35,52,31,51,48,38,59,27,35,31,51,38,36,57,39,39,35,40,55,58,59,57,52,43,53,56,55,51,49,55,51,50,53,54,56,58,55,59,57,58,59,60 };
        private static int key = 16;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
