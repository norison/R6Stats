﻿namespace R6Stats.Contracts.Requests
{
    internal class LoginRequest : BaseRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsRememberMe { get; set; }
    }
}
