using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppSpotifyConsumer.Models
{
    [Flags]
    public enum Scope
    {
        [StringAttribute("")]
        NONE = 1,
        [StringAttribute("playlist-modify-public")]
        PLAYLIST_MODIFY_PUBLIC = 2,
        [StringAttribute("playlist-modify-private")]
        PLAYLIST_MODIFY_PRIVATE = 4,
        [StringAttribute("playlist-read-private")]
        PLAYLIST_READ_PRIVATE = 8,
        [StringAttribute("streaming")]
        STREAMING = 16,
        [StringAttribute("user-read-private")]
        USER_READ_PRIVATE = 32,
        [StringAttribute("user-read-email")]
        USER_READ_EMAIL = 64,
        [StringAttribute("user-library-read")]
        USER_LIBRARAY_READ = 128,
        [StringAttribute("user-library-modify")]
        USER_LIBRARY_MODIFY = 256,
        [StringAttribute("user-follow-modify")]
        USER_FOLLOW_MODIFY = 512,
        [StringAttribute("user-follow-read")]
        USER_FOLLOW_READ = 1024,
        [StringAttribute("user-read-birthdate")]
        USER_READ_BIRTHDATE = 2048
    }

    public static class ScopeUtil
    {
        public static string GetStringAttribute<T>(this T en, String separator) where T : struct, IConvertible
        {
            Enum e = (Enum)(object)en;
            IEnumerable<StringAttribute> attributes =
            Enum.GetValues(typeof(T))
            .Cast<T>()
            .Where(v => e.HasFlag((Enum)(object)v))
            .Select(v => typeof(T).GetField(v.ToString()))
            .Select(f => f.GetCustomAttributes(typeof(StringAttribute), false)[0])
            .Cast<StringAttribute>();

            List<String> list = new List<String>();
            attributes.ToList().ForEach((element) => list.Add(element.Text));
            return string.Join(" ", list);
        }
    }
}