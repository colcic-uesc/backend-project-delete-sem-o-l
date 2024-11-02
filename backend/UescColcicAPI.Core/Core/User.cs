using System;

namespace UescColcicAPI.Core;

public class User
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Rules { get; set; }

    public Professor? Professor { get; set; }
    public Student? Student { get; set; }
}